// See https://aka.ms/new-console-template for more information
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis;
using System.Collections.Immutable;
using System.Reflection.Emit;
using System.Reflection;
using BindablePropsSG;
using BindableProps;


string source = @"
using BindableProps;

namespace WibuTube.Controls;

public partial class TextInput : ContentView
{
    [BindableProp]
    string text = String.Empty;

    [BindableProp]
    string placeHolder = String.Empty;


    public TextInput()
    {
        InitializeComponent();

        Content = new Border()
        {
            BindingContext = this,
            Content = new Entry()
            {
                ClearButtonVisibility = ClearButtonVisibility.WhileEditing,
                VerticalTextAlignment = TextAlignment.Center,
            }
            .Bind(Entry.TextProperty, nameof(Text))
            .Bind(Entry.PlaceholderProperty, nameof(PlaceHolder))
        };
    }
}
";

var (diagnostics, output) = GetGeneratedOutput(source);

if (diagnostics.Length > 0)
{
    Console.WriteLine("Diagnostics:");
    foreach (var diag in diagnostics)
    {
        Console.WriteLine("   " + diag.ToString());
    }
    Console.WriteLine();
    Console.WriteLine("Output:");
}

Console.WriteLine(output);


static (ImmutableArray<Diagnostic>, string) GetGeneratedOutput(string source)
{
    var syntaxTree = CSharpSyntaxTree.ParseText(source);

    var references = new List<MetadataReference>();
    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
    foreach (var assembly in assemblies)
    {
        if (!assembly.IsDynamic)
        {
            references.Add(MetadataReference.CreateFromFile(assembly.Location));
        }
    }

    var compilation = CSharpCompilation.Create("foo", new SyntaxTree[] { syntaxTree }, references, new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

// TODO: Uncomment these lines if you want to return immediately if the injected program isn't valid _before_ running generators
//
// ImmutableArray<Diagnostic> compilationDiagnostics = compilation.GetDiagnostics();
//
// if (diagnostics.Any())
// {
//     return (diagnostics, "");
// }

    var generator = new BindablePropSG();

    var driver = CSharpGeneratorDriver.Create(generator);
    driver.RunGeneratorsAndUpdateCompilation(compilation, out var outputCompilation, out var generateDiagnostics);

    return (generateDiagnostics, outputCompilation.SyntaxTrees.Last().ToString());
}