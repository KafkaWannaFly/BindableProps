using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Text.RegularExpressions;

namespace UnitTest
{
    internal static partial class TestHelper
    {
        public static string? GetGeneratedOutput(string sourceCode, IIncrementalGenerator generator)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
            var references = AppDomain.CurrentDomain.GetAssemblies()
                                      .Where(assembly => !assembly.IsDynamic)
                                      .Select(assembly => MetadataReference
                                                          .CreateFromFile(assembly.Location))
                                      .Cast<MetadataReference>();

            var compilation = CSharpCompilation.Create("SourceGeneratorTests",
                                                       [syntaxTree],
                          references,
                          new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            CSharpGeneratorDriver.Create(generator)
                                 .RunGeneratorsAndUpdateCompilation(compilation,
                                                                    out var outputCompilation,
                                                                    out var diagnostics);

            // optional
            diagnostics.Where(d => d.Severity == DiagnosticSeverity.Error)
                       .Should().BeEmpty();

            return outputCompilation.SyntaxTrees.Skip(1).LastOrDefault()?.ToString();
        }
        
        public static string RemoveAllWhiteSpace(string content)
        {
            return MyRegex().Replace(content, string.Empty);
        }

        [GeneratedRegex(@"\s+")]
        private static partial Regex MyRegex();
    }
}
