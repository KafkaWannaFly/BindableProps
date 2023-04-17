using System.Diagnostics.CodeAnalysis;
using System.Text;
using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindablePropsSG.Generators
{
    [Generator]
    [SuppressMessage("ReSharper", "InconsistentNaming")]
    [SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
    public class BindablePropSG : BaseGenerator
    {
        protected override IEnumerable<string> TargetAttributes => new[]
        {
            "BindableProp",
            "BindablePropAttribute"
        };

        protected override void ProcessField(StringBuilder source, ClassDeclarationSyntax classSyntax,
            SyntaxNode syntaxNode,
            ISymbol fieldSymbol)
        {
            var fieldName = fieldSymbol.Name;
            var propName = StringUtil.PascalCaseOf(fieldName);

            if (propName.Length == 0 || propName == fieldName)
            {
                return;
            }

            var fieldSyntax = (FieldDeclarationSyntax)syntaxNode;
            var fieldType = fieldSyntax.Declaration.Type;
            
            // typeof operation doesn't accept nullable data type
            var unNullableDataType = fieldType.ToString();
            if (unNullableDataType[unNullableDataType.Length - 1] == '?')
            {
                unNullableDataType = unNullableDataType.Substring(0, unNullableDataType.Length - 1);
            }

            var newKeyword = fieldSyntax.Modifiers
                .FirstOrDefault(keyword => keyword.Text.Equals("new"));

            var className = classSyntax.Identifier;

            var defaultFieldValue = SyntaxUtil.GetFieldDefaultValue(fieldSyntax) ?? "default";

            var attributeSyntax = SyntaxUtil.GetAttributeByName(fieldSyntax, "BindableProp");

            var attributeArguments = attributeSyntax?.ArgumentList?.Arguments;

            var defaultBindingMode = SyntaxUtil.GetAttributeParam(attributeArguments, "DefaultBindingMode") ?? "0";

            var validateValueDelegate =
                SyntaxUtil.GetAttributeParam(attributeArguments, "ValidateValueDelegate") ?? "null";

            var propertyChangedDelegate = SyntaxUtil.GetAttributeParam(
                attributeArguments, "PropertyChangedDelegate"
            ) ?? @$"(bindable, oldValue, newValue) => 
                        (({className})bindable).{propName} = ({fieldType})newValue";

            var propertyChangingDelegate =
                SyntaxUtil.GetAttributeParam(attributeArguments, "PropertyChangingDelegate") ?? "null";

            var coerceValueDelegate = SyntaxUtil.GetAttributeParam(attributeArguments, "CoerceValueDelegate") ?? "null";

            var createDefaultValueDelegate =
                SyntaxUtil.GetAttributeParam(attributeArguments, "CreateDefaultValueDelegate") ?? "null";

            source.Append($@"
        public {newKeyword} static readonly BindableProperty {propName}Property = BindableProperty.Create(
            nameof({propName}),
            typeof({unNullableDataType}),
            typeof({className}),
            {defaultFieldValue},
            (BindingMode){defaultBindingMode},
            {validateValueDelegate},
            {propertyChangedDelegate},
            {propertyChangingDelegate},
            {coerceValueDelegate},
            {createDefaultValueDelegate}
        );

        public {newKeyword} {fieldType} {propName}
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
    }
}