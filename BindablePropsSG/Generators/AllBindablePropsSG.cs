﻿using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindablePropsSG.Generators
{
    [Generator]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
    public class AllBindablePropsSG : BaseGenerator
    {
        private readonly List<string> ignoredAttributes = new()
        {
            "IgnoredProp",
            "BindableProp",
            "IgnoredPropAttribute",
            "BindablePropAttribute",
            "AttachedProp",
            "AttachedPropAttribute"
        };

        protected override IEnumerable<string> TargetAttributes => new[]
        {
            "AllBindableProps",
            "AllBindablePropsAttribute"
        };

        protected override (SyntaxNode?, ISymbol?) Transform(GeneratorSyntaxContext context,
            CancellationToken cancellationToken)
        {
            var attributeSyntax = (AttributeSyntax)context.Node;

            // Attribute --> AttributeList --> Class
            if (attributeSyntax.Parent?.Parent is not ClassDeclarationSyntax classDeclarationSyntax)
                return (null, null);

            var classSymbol = context.SemanticModel
                .Compilation
                .GetTypeByMetadataName(
                    SyntaxUtil.GetClassFullname(classDeclarationSyntax)
                );

            return (classDeclarationSyntax, classSymbol);
        }

        protected override void Execute(SourceProductionContext context,
            ImmutableArray<(SyntaxNode?, ISymbol?)> classGroups)
        {
            if (classGroups.IsDefaultOrEmpty)
            {
                return;
            }

            foreach (var group in classGroups)
            {
                var (classSyntax, classSymbol) = ((ClassDeclarationSyntax?, INamedTypeSymbol?))group;
                if (classSyntax is null || classSymbol is null)
                    continue;

                var fieldTuples = classSymbol.GetMembers()
                    .Where(symbol => FieldNotIncludeAttributes(
                        symbol,
                        ignoredAttributes)
                    )
                    .Where(item => item is not null && !item.IsStatic)
                    .Select(fieldSymbol =>
                    {
                        var variableDeclaratorSyntax = SyntaxUtil.FindSyntaxBySymbol(classSyntax, fieldSymbol!);
                        return (variableDeclaratorSyntax, fieldSymbol);
                    })
                    .ToList();

                var sourceCode = ProcessClass(classSyntax, fieldTuples);
                var className = SyntaxUtil.GetClassFullname(classSyntax);

                context.AddSource($"{className}.g.cs", sourceCode);
            }
        }

        protected override string ProcessClass(ClassDeclarationSyntax? classSyntax,
            List<(SyntaxNode, ISymbol)> syntaxSymbols)
        {
            if (classSyntax is null || !syntaxSymbols.Any())
                return string.Empty;

            var usingDirectives = classSyntax.SyntaxTree.GetCompilationUnitRoot().Usings;

            var namespaceSyntax = classSyntax.Parent as BaseNamespaceDeclarationSyntax;
            var namespaceName = namespaceSyntax?.Name.ToString() ?? "global";

            var source = new StringBuilder($@"
// <auto-generated/>
{usingDirectives}

namespace {namespaceName}
{{
    public partial class {classSyntax.Identifier}
    {{
");

            foreach (var (syntax, symbol) in syntaxSymbols)
            {
                // variableDeclaratorSyntax --> variableDeclarationSyntax --> fieldDeclarationSyntax
                var fieldDeclarationSyntax = syntax.Parent?.Parent!;
                ProcessField(source, classSyntax, fieldDeclarationSyntax, symbol);
            }

            source.Append(@$"
    }}
}}
");

            return source.ToString();
        }

        protected override void ProcessField(StringBuilder source, ClassDeclarationSyntax classDeclarationSyntax,
            SyntaxNode syntaxNode, ISymbol fieldSymbol)
        {
            var fieldSyntax = (FieldDeclarationSyntax)syntaxNode;

            var fieldName = fieldSymbol.Name;
            var propName = StringUtil.PascalCaseOf(fieldName);
            var dataType = fieldSyntax.Declaration.Type;

            // typeof operation doesn't accept nullable data type
            var unNullableDataType = dataType.ToString();
            if (unNullableDataType[unNullableDataType.Length - 1] == '?')
            {
                unNullableDataType = unNullableDataType.Substring(0, unNullableDataType.Length - 1);
            }
            
            var newKeyword = fieldSyntax.Modifiers
                .FirstOrDefault(keyword => keyword.Text.Equals("new"));

            var className = classDeclarationSyntax.Identifier.ToString();

            var variableDeclaratorSyntax = fieldSyntax.ChildNodes().OfType<VariableDeclarationSyntax>().FirstOrDefault()
                ?.Variables
                .FirstOrDefault();
            var defaultValue = variableDeclaratorSyntax?.Initializer?
                .Value
                .ToString() ?? "default";

            source.Append($@"
        {newKeyword} public static readonly BindableProperty {propName}Property = BindableProperty.Create(
                    nameof({propName}),
                    typeof({unNullableDataType}),
                    typeof({className}),
                    {defaultValue},
                    propertyChanged: (bindable, oldValue, newValue) =>
                                    (({className})bindable).{propName} = ({dataType})newValue
                );

        {newKeyword} public {dataType} {propName}
        {{
            get => {fieldName};
            set 
            {{ 
                OnPropertyChanging(nameof({propName}));

                {fieldName} = value;
                SetValue({className}.{propName}Property, {fieldName});

                OnPropertyChanged(nameof({propName}));
            }}
        }}
");
        }

        private bool FieldNotIncludeAttributes(ISymbol symbol, ICollection<string> attributeNames)
        {
            if (symbol is IFieldSymbol fieldSymbol)
            {
                return fieldSymbol.GetAttributes().Any(
                    attribute =>
                    {
                        var name = attribute?.AttributeClass?.Name;
                        return attributeNames.Contains(name!);
                    }
                ) is not true;
            }

            return false;
        }
    }
}