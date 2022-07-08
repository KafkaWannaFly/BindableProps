﻿using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System.Collections.Immutable;
using System.Text;

namespace BindablePropsSG.Generators
{
    [Generator]
    public class AllBindablePropsSG : IIncrementalGenerator
    {
        readonly List<string> ignoredAttributes = new()
        {
            "IgnoredProp", "BindableProp", "IgnoredPropAttribute", "BindablePropAttribute"
        };

        public void Initialize(IncrementalGeneratorInitializationContext context)
        {
            var classGroups = context.SyntaxProvider
                .CreateSyntaxProvider(
                    predicate: IsAllBindableProps,
                    transform: Transform
                ).Where(group => group.Item1 is not null && group.Item2 is not null)
                .Collect();

            context.RegisterSourceOutput(classGroups, Execute);
        }

        private void Execute(SourceProductionContext context, ImmutableArray<(ClassDeclarationSyntax?, INamedTypeSymbol?)> classGroups)
        {
            if (classGroups.IsDefaultOrEmpty)
            {
                return;
            }

            foreach (var group in classGroups)
            {
                var sourceCode = ProcessClass(group!);
                var className = group.Item1?.Identifier;

                if (sourceCode is not null)
                    context.AddSource($"{className}.AllBindableProps.g.cs", sourceCode);
            }
        }

        private string? ProcessClass((ClassDeclarationSyntax, INamedTypeSymbol) group)
        {
            var (classSyntax, classSymbol) = group;

            var availableFieldSymbols = classSymbol.GetMembers()
                .Where(symbol => FieldNotIncludeAttributes(
                    symbol,
                    ignoredAttributes)
                )
                .Select(item => item as IFieldSymbol);

            if (availableFieldSymbols is null || availableFieldSymbols.Count() == 0)
            {
                return null;
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

            foreach (var fieldSymbol in availableFieldSymbols)
            {
                if (fieldSymbol is null)
                    continue;

                ProcessField(source, classSyntax, classSymbol, fieldSymbol);
            }

            source.Append(@$"
    }}
}}
");

            return source.ToString();
        }

        private void ProcessField(
            StringBuilder source,
            ClassDeclarationSyntax classDeclarationSyntax,
            INamedTypeSymbol classSymbol,
            IFieldSymbol fieldSymbol)
        {
            var fieldName = fieldSymbol.Name;
            var propName = StringUtil.PascalCaseOf(fieldName);
            var dataType = fieldSymbol.Type;
            var className = classSymbol.Name;

            var syntax = SyntaxUtil.FindSyntaxBySymbol(classDeclarationSyntax, fieldSymbol) as VariableDeclaratorSyntax;
            var defaultValue = syntax?.Initializer?
                .Value
                .ToString() ?? "default";

            source.Append($@"
        public static readonly BindableProperty {propName}Property = BindableProperty.Create(
                    nameof({propName}),
                    typeof({dataType}),
                    typeof({className}),
                    {defaultValue}
                );

        public {dataType} {propName}
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

        bool FieldNotIncludeAttributes(ISymbol symbol, List<string> attributeNames)
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

        private (ClassDeclarationSyntax?, INamedTypeSymbol?) Transform(GeneratorSyntaxContext context, CancellationToken cancellationToken)
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

        private bool IsAllBindableProps(SyntaxNode node, CancellationToken _)
        {
            if (node is not AttributeSyntax attributeSyntax)
            {
                return false;
            }

            var name = SyntaxUtil.ExtractName(attributeSyntax?.Name);

            return name is "AllBindableProps" or "AllBindablePropsAttribute";
        }
    }
}
