using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Text;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace BindablePropsSG
{

    [Generator]
    public class BindablePropSG : ISourceGenerator
    {
        public void Initialize(GeneratorInitializationContext context)
        {
            //#if DEBUG
            //            if (!Debugger.IsAttached)
            //            {
            //                Debugger.Launch();
            //            }
            //#endif

            // Register a syntax receiver that will be created for each generation pass
            context.RegisterForSyntaxNotifications(() => new SyntaxReceiver());
        }

        public void Execute(GeneratorExecutionContext context)
        {
            if (!(context.SyntaxContextReceiver is SyntaxReceiver receiver))
                return;

            INamedTypeSymbol attributeSymbol = context.Compilation.GetTypeByMetadataName("BindableProps.BindableProp")!;

            // group the fields by class, and generate the source
            var groupList = receiver.Fields.GroupBy<IFieldSymbol, INamedTypeSymbol>(f => f.ContainingType, SymbolEqualityComparer.Default);
            foreach (IGrouping<INamedTypeSymbol, IFieldSymbol> group in groupList)
            {
                string classSource = ProcessClass(group.Key, group.ToList(), attributeSymbol, context);
                context.AddSource($"{group.Key.Name}.g.cs", SourceText.From(classSource, Encoding.UTF8));

            }
        }

        private string ProcessClass(INamedTypeSymbol classSymbol, List<IFieldSymbol> fields, ISymbol attributeSymbol, GeneratorExecutionContext context)
        {
            if (!classSymbol.ContainingSymbol.Equals(classSymbol.ContainingNamespace, SymbolEqualityComparer.Default))
            {
                return String.Empty; //TODO: issue a diagnostic that it must be top level
            }

            string namespaceName = classSymbol.ContainingNamespace.ToDisplayString();

            // begin building the generated source
            StringBuilder source = new StringBuilder($@"
namespace {namespaceName}
{{
    public partial class {classSymbol.Name}
    {{
");

            // create properties for each field 
            foreach (IFieldSymbol fieldSymbol in fields)
            {
                ProcessField(source, fieldSymbol, attributeSymbol, classSymbol);
            }

            source.Append(@"
    }
}
");
            return source.ToString();
        }

        private void ProcessField(StringBuilder source, IFieldSymbol fieldSymbol, ISymbol attributeSymbol, INamedTypeSymbol classSymbol)
        {
            // get the name and type of the field
            string fieldName = fieldSymbol.Name;
            var propName = PascalCaseOf(fieldName);

            if (propName.Length == 0 || propName == fieldName)
            {
                return;
            }

            ITypeSymbol fieldType = fieldSymbol.Type;

            var attributeParamGroups = fieldSymbol.GetAttributes()
                .Single(ad => ad?.AttributeClass?.Equals(attributeSymbol, SymbolEqualityComparer.Default) ?? false)
                .NamedArguments;

            var defaultBindingMode = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "DefaultBindingMode").Value;
            var validateValueDelegate = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "ValidateValueDelegate").Value;
            var propertyChangedDelegate = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "PropertyChangedDelegate").Value;
            var propertyChangingDelegate = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "PropertyChangingDelegate").Value;
            var coerceValueDelegate = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "CoerceValueDelegate").Value;
            var createDefaultValueDelegate = attributeParamGroups.SingleOrDefault(kvp => kvp.Key == "CreateDefaultValueDelegate").Value;


            source.Append($@"
        public static readonly BindableProperty {propName}Property = BindableProperty.Create(
            nameof({propName}),
            typeof({fieldType.ToDisplayString()}),
            typeof({classSymbol.Name}),
			{GetFieldInitValue(fieldSymbol) ?? "default"},
            (BindingMode){(!defaultBindingMode.IsNull ? defaultBindingMode.Value!.ToString() : "0")},
            {(!validateValueDelegate.IsNull ? validateValueDelegate.Value!.ToString() : "null")},
            {(!propertyChangedDelegate.IsNull ? propertyChangedDelegate.Value!.ToString() : "null")},         
            {(!propertyChangingDelegate.IsNull ? propertyChangingDelegate.Value!.ToString() : "null")},
            {(!coerceValueDelegate.IsNull ? coerceValueDelegate.Value!.ToString() : "null")},
            {(!createDefaultValueDelegate.IsNull ? createDefaultValueDelegate.Value!.ToString() : "null")}
        );

        public {fieldType.ToDisplayString()} {propName}
        {{
            get => {fieldName};
            set 
            {{ 
                {fieldName} = value;
                SetValue({classSymbol.Name}.{propName}Property, {fieldName});
            }}
        }}
");
        }

        SyntaxNode GetNode(SyntaxTree tree, int lineNumber)
        {
            var lineSpan = tree.GetText().Lines[lineNumber].Span;
            return tree.GetRoot().DescendantNodes(lineSpan)
                .First(n => lineSpan.Contains(n.Span));
        }

        string GetFieldInitValue(IFieldSymbol fieldSymbol)
        {
            return GetNode(
                    fieldSymbol.DeclaringSyntaxReferences.FirstOrDefault()!.SyntaxTree,
                    fieldSymbol.Locations.FirstOrDefault()!.GetLineSpan().StartLinePosition.Line
                )
                ?.DescendantNodesAndSelf()
                ?.OfType<VariableDeclarationSyntax>()
                ?.FirstOrDefault()
                ?.Variables
                .FirstOrDefault()
                ?.Initializer
                ?.Value
                ?.ToString() ?? String.Empty;
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
    }

    class SyntaxReceiver : ISyntaxContextReceiver
    {
        public List<IFieldSymbol> Fields { get; } = new List<IFieldSymbol>();

        /// <summary>
        /// Called for every syntax node in the compilation, we can inspect the nodes and save any information useful for generation
        /// </summary>
        public void OnVisitSyntaxNode(GeneratorSyntaxContext context)
        {
            // any field with at least one attribute is a candidate for property generation
            if (context.Node is FieldDeclarationSyntax fieldDeclarationSyntax
                && fieldDeclarationSyntax.AttributeLists.Count > 0)
            {
                foreach (VariableDeclaratorSyntax variable in fieldDeclarationSyntax.Declaration.Variables)
                {
                    // Get the symbol being declared by the field, and keep it if its annotated
                    IFieldSymbol? fieldSymbol = context.SemanticModel.GetDeclaredSymbol(variable) as IFieldSymbol;
                    if (fieldSymbol?.GetAttributes().Any(ad => ad.AttributeClass?.ToDisplayString() == "BindableProps.BindableProp") ?? false)
                    {
                        Fields.Add(fieldSymbol);
                    }
                }
            }
        }
    }
}
