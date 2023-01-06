using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Text;

namespace BindablePropsSG.Utils
{
    public static class SyntaxUtil
    {
        public static string? ExtractName(NameSyntax? name)
        {
            return name switch
            {
                SimpleNameSyntax ins => ins.Identifier.Text,
                QualifiedNameSyntax qns => qns.Right.Identifier.Text,
                _ => null
            };
        }

        /// <summary>
        /// https://stackoverflow.com/a/61409409
        /// </summary>
        public static string GetClassFullname(TypeDeclarationSyntax? source)
        {
            var namespaces = new LinkedList<BaseNamespaceDeclarationSyntax>();
            var types = new LinkedList<TypeDeclarationSyntax>();

            for (var parent = source.Parent; parent is not null; parent = parent.Parent)
            {
                switch (parent)
                {
                    case BaseNamespaceDeclarationSyntax @namespace:
                        namespaces.AddFirst(@namespace);
                        break;
                    case TypeDeclarationSyntax type:
                        types.AddFirst(type);
                        break;
                }
            }

            var result = new StringBuilder();

            for (var item = namespaces.First; item is not null; item = item.Next)
            {
                result.Append(item.Value.Name).Append(".");
            }

            for (var item = types.First; item is not null; item = item.Next)
            {
                var type = item.Value;
                AppendName(result, type);
                result.Append(".");
            }

            AppendName(result, source);

            return result.ToString();
        }

        private static void AppendName(StringBuilder builder, TypeDeclarationSyntax? type)
        {
            builder.Append(type.Identifier.Text);
            var typeArguments = type.TypeParameterList?.ChildNodes()
                .Count(node => node is TypeParameterSyntax) ?? 0;
            if (typeArguments != 0)
                builder.Append(".").Append(typeArguments);
        }

        public static SyntaxNode FindSyntaxBySymbol(SyntaxNode syntaxNode, ISymbol symbol)
        {
            var span = symbol.Locations.FirstOrDefault()!.SourceSpan;
            var syntax = syntaxNode.FindNode(span);

            return syntax;
        }
        
        public static AttributeSyntax? GetAttributeByName(FieldDeclarationSyntax fieldSyntax, string attributeName)
        {
            var attributeSyntax = fieldSyntax.AttributeLists
                .FirstOrDefault(attrList =>
                {
                    var attr = attrList.Attributes.FirstOrDefault();
                    return attr is not null && SyntaxUtil.ExtractName(attr.Name) == attributeName;
                })
                ?.Attributes
                .FirstOrDefault();

            return attributeSyntax;
        }
        
        public static string? GetFieldDefaultValue(FieldDeclarationSyntax fieldSyntax)
        {
            var variableDeclaration = fieldSyntax.DescendantNodesAndSelf()
                .OfType<VariableDeclarationSyntax>()
                .FirstOrDefault();
            var variableDeclarator = variableDeclaration?.Variables.FirstOrDefault();
            var initializer = variableDeclarator?.Initializer;
            return initializer?.Value.ToString();
        }
        
        public static string? GetAttributeParam(SeparatedSyntaxList<AttributeArgumentSyntax>? attributeArguments, string paramName)
        {
            var paramSyntax = attributeArguments?.FirstOrDefault(
                attrArg => attrArg?.NameEquals?.Name.Identifier.Text == paramName
            );

            return paramSyntax?.Expression switch
            {
                InvocationExpressionSyntax invocationExpressionSyntax => invocationExpressionSyntax.ArgumentList
                    .Arguments.FirstOrDefault()
                    ?.ToString(),
                LiteralExpressionSyntax literalExpressionSyntax => literalExpressionSyntax.Token.Value?.ToString(),
                _ => paramSyntax?.Expression.ToString()
            };
        }
    }
}
