using System.Diagnostics.CodeAnalysis;
using System.Text;
using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindablePropsSG.Generators;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
public class BindableReadOnlyPropSG : BaseGenerator
{
    protected override IEnumerable<string> TargetAttributes => new[]
    {
        "BindableReadOnlyProp",
        "BindableReadOnlyPropAttribute"
    };

    protected override void ProcessField(
        StringBuilder source,
        ClassDeclarationSyntax classSyntax,
        SyntaxNode syntaxNode,
        ISymbol fieldSymbol
    )
    {
        var bindablePropParam =
            SyntaxUtil.ExtractCreateBindablePropertyParam(classSyntax, syntaxNode, fieldSymbol, "BindableReadOnlyProp");

        var fieldSyntax = (FieldDeclarationSyntax)syntaxNode;
        var attributeSyntax = SyntaxUtil.GetAttributeByName(fieldSyntax, "BindableReadOnlyProp");
        var attributeArguments = attributeSyntax?.ArgumentList?.Arguments;
        // Default BindingMode is OneWayToSource instead of OneWay as usual
        var defaultBindingMode = SyntaxUtil.GetAttributeParam(attributeArguments, "DefaultBindingMode") ?? "3";

        bindablePropParam.BindingMode = defaultBindingMode;

        source.Append($@"
        public {bindablePropParam.NewKeyWord} static readonly BindablePropertyKey {bindablePropParam.PropName}PropertyKey = BindableProperty.CreateReadOnly(
            nameof({bindablePropParam.PropName}),
            typeof({bindablePropParam.UnNullableFieldType}),
            typeof({bindablePropParam.ClassType}),
            {bindablePropParam.DefaultValue},
            (BindingMode){bindablePropParam.BindingMode},
            {bindablePropParam.ValidateValueDelegate},
            {bindablePropParam.PropertyChangedDelegate},
            {bindablePropParam.PropertyChangingDelegate},
            {bindablePropParam.CoerceValueDelegate},
            {bindablePropParam.CreateDefaultValueDelegate}
        );

        public {bindablePropParam.NewKeyWord} static readonly BindableProperty {bindablePropParam.PropName}Property = {bindablePropParam.PropName}PropertyKey.BindableProperty;

        public {bindablePropParam.NewKeyWord} {bindablePropParam.FieldType} {bindablePropParam.PropName}
        {{
            get => {bindablePropParam.FieldName};
            private set 
            {{ 
                OnPropertyChanging(nameof({bindablePropParam.PropName}));

                {bindablePropParam.FieldName} = value;
                SetValue({bindablePropParam.ClassType}.{bindablePropParam.PropName}PropertyKey, {bindablePropParam.FieldName});

                OnPropertyChanged(nameof({bindablePropParam.PropName}));
            }}
        }}
");
    }
}