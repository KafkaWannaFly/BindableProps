using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System;
using System.Collections.Generic;
using System.Text;

namespace BindablePropsSG.Utils
{
    public class SyntaxUtil
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
        /// <returns></returns>
        public static string GetClassFullname(TypeDeclarationSyntax source)
        {
            var namespaces = new LinkedList<BaseNamespaceDeclarationSyntax>();
            var types = new LinkedList<TypeDeclarationSyntax>();

            for (var parent = source.Parent; parent is object; parent = parent.Parent)
            {
                if (parent is BaseNamespaceDeclarationSyntax @namespace)
                {
                    namespaces.AddFirst(@namespace);
                }
                else if (parent is TypeDeclarationSyntax type)
                {
                    types.AddFirst(type);
                }
            }

            var result = new StringBuilder();

            for (var item = namespaces.First; item is object; item = item.Next)
            {
                result.Append(item.Value.Name).Append(".");
            }

            for (var item = types.First; item is object; item = item.Next)
            {
                var type = item.Value;
                AppendName(result, type);
                result.Append(".");
            }

            AppendName(result, source);

            return result.ToString();
        }

        static void AppendName(StringBuilder builder, TypeDeclarationSyntax type)
        {
            builder.Append(type.Identifier.Text);
            var typeArguments = type.TypeParameterList?.ChildNodes()
                .Count(node => node is TypeParameterSyntax) ?? 0;
            if (typeArguments != 0)
                builder.Append(".").Append(typeArguments);
        }

        public static SyntaxNode? FindSyntaxBySymbol(SyntaxNode syntaxNode, ISymbol symbol)
        {
            var span = symbol.Locations.FirstOrDefault()!.SourceSpan;
            var syntax = syntaxNode.FindNode(span);

            return syntax;
        }
    }
}
