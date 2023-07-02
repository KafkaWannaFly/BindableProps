﻿using System.Collections.Immutable;
using System.Diagnostics.CodeAnalysis;
using System.Text;
using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindablePropsSG.Generators;

[Generator]
[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
public class BaseGenerator : IIncrementalGenerator
{
    public virtual void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var syntaxSymbols = context.SyntaxProvider
            .CreateSyntaxProvider(
                predicate: Predicate,
                transform: Transform
            )
            .Where(item => item is not (null, null))
            .Collect();

        context.RegisterSourceOutput(syntaxSymbols, Execute);
    }

    protected virtual IEnumerable<string> TargetAttributes => Enumerable.Empty<string>();

    protected virtual bool Predicate(SyntaxNode node, CancellationToken cancellationToken)
    {
        if (node is not AttributeSyntax attributeSyntax)
        {
            return false;
        }

        var name = SyntaxUtil.ExtractName(attributeSyntax.Name);

        return name != null && TargetAttributes.Contains(name);
    }

    protected virtual (SyntaxNode?, ISymbol?) Transform(GeneratorSyntaxContext context,
        CancellationToken cancellationToken)
    {
        var attributeSyntax = (AttributeSyntax)context.Node;

        // Attribute --> AttributeList --> Field
        if (attributeSyntax.Parent?.Parent is not FieldDeclarationSyntax syntax)
            return default;

        var symbol =
            context.SemanticModel.GetDeclaredSymbol(syntax.Declaration.Variables.FirstOrDefault()!);

        return (syntax, symbol);
    }

    protected virtual void Execute(SourceProductionContext context,
        ImmutableArray<(SyntaxNode?, ISymbol?)> syntaxSymbols)
    {
        if (syntaxSymbols.IsDefaultOrEmpty)
            return;

        var groupList = syntaxSymbols.GroupBy<(SyntaxNode, ISymbol), ClassDeclarationSyntax>(
            fieldGroup => (ClassDeclarationSyntax)fieldGroup.Item1!.Parent!
        );

        foreach (var group in groupList)
        {
            var sourceCode = ProcessClass(group.Key, group.ToList()).Trim();
            var className = SyntaxUtil.GetClassFullname(group.Key);

            context.AddSource($"{className}.g.cs", sourceCode);
        }
    }

    protected virtual string ProcessClass(ClassDeclarationSyntax? classSyntax,
        List<(SyntaxNode, ISymbol)> syntaxSymbols)
    {
        if (classSyntax is null)
        {
            return string.Empty;
        }

        var usingDirectives = classSyntax.SyntaxTree.GetCompilationUnitRoot().Usings;

        var namespaceSyntax = classSyntax.Parent as BaseNamespaceDeclarationSyntax;
        var namespaceName = namespaceSyntax?.Name.ToString() ?? "global";

        var source = new StringBuilder($@"
#pragma warning disable

// <auto-generated/>
{usingDirectives}

namespace {namespaceName}
{{
    public partial class {classSyntax.Identifier}
    {{
");

        foreach (var (syntax, symbol) in syntaxSymbols)
        {
            ProcessField(source, classSyntax, syntax, symbol);
        }

        source.Append(@$"
    }}
}}
");

        return source.ToString();
    }

    protected virtual string ProcessClass((SyntaxNode, ISymbol) group)
    {
        return string.Empty;
    }

    protected virtual void ProcessField(StringBuilder source, ClassDeclarationSyntax classSyntax,
        SyntaxNode fieldSyntax, ISymbol fieldSymbol)
    {
    }
}