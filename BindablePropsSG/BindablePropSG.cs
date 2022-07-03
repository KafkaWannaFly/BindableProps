﻿using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Collections.Immutable;
using System.Text;

namespace BindablePropsSG
{
    [Generator]
    public class BindablePropSG : IIncrementalGenerator
    {
        public void Initialize(IncrementalGeneratorInitializationContext context)
        {

            var fieldTypes = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: IsBindableProp,
                    transform: Transform
                )
                .Where(item => item is not (null, null))
                .Collect();

            context.RegisterSourceOutput(fieldTypes, Execute);
        }

        private bool IsBindableProp(SyntaxNode node, CancellationToken _)
        {
            if (node is not AttributeSyntax attributeSyntax)
            {
                return false;
            }

            var name = ExtractName(attributeSyntax?.Name);

            return name is "BindableProp" or "BindablePropAttribute";
        }

        private (FieldDeclarationSyntax?, IFieldSymbol?) Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
        {
            var attributeSyntax = (AttributeSyntax)context.Node;

            // Attribute --> AttributeList --> Field
            if (attributeSyntax.Parent?.Parent is not FieldDeclarationSyntax fieldSyntax)
                return (null, null);
            
            var fieldSymbol = context.SemanticModel.GetDeclaredSymbol(fieldSyntax.Declaration.Variables.FirstOrDefault()!) as IFieldSymbol;

            return (fieldSyntax, fieldSymbol);
        }

        private void Execute(SourceProductionContext context, ImmutableArray<(FieldDeclarationSyntax?, IFieldSymbol?)> fieldSyntaxesAndSymbols)
        {
            if (fieldSyntaxesAndSymbols.IsDefaultOrEmpty)
                return;

            var groupList = fieldSyntaxesAndSymbols.GroupBy<(FieldDeclarationSyntax, IFieldSymbol), ClassDeclarationSyntax>(
                    fieldGroup => (ClassDeclarationSyntax)fieldGroup.Item1!.Parent!
                );

            foreach (var group in groupList)
            {
                string sourceCode = ProcessClass(group.Key, group.ToList());
                var className = group.Key.Identifier;

                context.AddSource($"{className}.g.cs", sourceCode);
            }
        }

        private string ProcessClass(ClassDeclarationSyntax classSyntax, List<(FieldDeclarationSyntax, IFieldSymbol)> fieldGroup)
        {
            if (classSyntax is null)
            {
                return String.Empty;
            }

            var usingDirectives = classSyntax.SyntaxTree.GetCompilationUnitRoot().Usings;
            
            var namespaceSyntax = classSyntax.Parent as BaseNamespaceDeclarationSyntax;
            var namespaceName = namespaceSyntax?.Name?.ToString() ?? "global";
            
            var source = new StringBuilder($@"
{usingDirectives}

namespace {namespaceName}
{{
    public partial class {classSyntax.Identifier}
    {{
");

            // create properties for each field 
            foreach (var (fieldSynTax, fieldSymbol) in fieldGroup)
            {
                ProcessField(source, classSyntax, fieldSynTax, fieldSymbol);
            }

            source.Append(@$"
    }}
}}
");
            return source.ToString();
        }

        private void ProcessField(StringBuilder source, ClassDeclarationSyntax classSyntax, FieldDeclarationSyntax fieldSyntax, IFieldSymbol fieldSymbol)
        {
            var fieldName = fieldSymbol.Name;
            var propName = PascalCaseOf(fieldName);

            if (propName.Length == 0 || propName == fieldName)
            {
                return;
            }

            var fieldType = fieldSyntax.Declaration.Type;

            var className = classSyntax.Identifier;

            var defaultFieldValue = GetFieldDefaultValue(fieldSyntax) ?? "default";

            var attributeSyntax = GetAttributeByName(fieldSyntax, "BindableProp");

            var attributeArguments = attributeSyntax?.ArgumentList?.Arguments;

            var defaultBindingMode = GetAttributeParam(attributeArguments, "DefaultBindingMode") ?? "BindingMode.Default";

            var validateValueDelegate = GetAttributeParam(attributeArguments, "ValidateValueDelegate") ?? "null";

            var propertyChangedDelegate = GetAttributeParam(attributeArguments, "PropertyChangedDelegate") ?? "null";

            var propertyChangingDelegate = GetAttributeParam(attributeArguments, "PropertyChangingDelegate") ?? "null";

            var coerceValueDelegate = GetAttributeParam(attributeArguments, "CoerceValueDelegate") ?? "null";

            var createDefaultValueDelegate = GetAttributeParam(attributeArguments, "CreateDefaultValueDelegate") ?? "null";

            source.Append($@"
        public static readonly BindableProperty {propName}Property = BindableProperty.Create(
            nameof({propName}),
            typeof({fieldType}),
            typeof({className}),
            {defaultFieldValue},
            {defaultBindingMode},
            {validateValueDelegate},
            {propertyChangedDelegate},
            {propertyChangingDelegate},
            {coerceValueDelegate},
            {createDefaultValueDelegate}
        );

        public {fieldType} {propName}
        {{
            get => {fieldName};
            set 
            {{ 
                {fieldName} = value;
                SetValue({className}.{propName}Property, {fieldName});
            }}
        }}
");
        }

        string PascalCaseOf(string fieldName)
        {
            fieldName = fieldName.TrimStart('_');
            if (fieldName.Length == 0)
                return string.Empty;

            if (fieldName.Length == 1)
                return fieldName.ToUpper();

            return fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);
        }

        string? ExtractName(NameSyntax? name)
        {
            return name switch
            {
                SimpleNameSyntax ins => ins.Identifier.Text,
                QualifiedNameSyntax qns => qns.Right.Identifier.Text,
                _ => null
            };
        }

        string? GetAttributeParam(SeparatedSyntaxList<AttributeArgumentSyntax>? attributeArguments, string paramName)
        {
            var paramSyntax = attributeArguments?.FirstOrDefault(
                attrArg => attrArg?.NameEquals?.Name.Identifier.Text == paramName
            );

            if (paramSyntax?.Expression is InvocationExpressionSyntax invocationExpressionSyntax)
            {
                return invocationExpressionSyntax.ArgumentList.Arguments.FirstOrDefault()?.ToString();
            }
            else if (paramSyntax?.Expression is LiteralExpressionSyntax literalExpressionSyntax)
            {
                return literalExpressionSyntax.Token.Value?.ToString();
            }
            
            return paramSyntax?.Expression.ToString();
        }

        string? GetFieldDefaultValue(FieldDeclarationSyntax fieldSyntax)
        {
            var variableDeclaration = fieldSyntax.DescendantNodesAndSelf()
                .OfType<VariableDeclarationSyntax>()
                .FirstOrDefault();
            var variableDeclarator = variableDeclaration?.Variables.FirstOrDefault();
            var initializer = variableDeclarator?.Initializer;
            return initializer?.Value?.ToString();
        }

        AttributeSyntax? GetAttributeByName(FieldDeclarationSyntax fieldSyntax, string attributeName)
        {
            var attributeSyntax = fieldSyntax.AttributeLists
                .FirstOrDefault(attrList =>
                {
                    var attr = attrList.Attributes.FirstOrDefault();
                    return attr is not null && ExtractName(attr.Name) == attributeName;
                })
                ?.Attributes
                .FirstOrDefault();

            return attributeSyntax;
        }
    }
}
