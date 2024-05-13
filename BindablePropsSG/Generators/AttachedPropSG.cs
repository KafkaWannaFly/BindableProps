using System.Diagnostics.CodeAnalysis;
using System.Text;
using BindablePropsSG.Utils;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace BindablePropsSG.Generators;

[Generator]
[SuppressMessage("ReSharper", "InconsistentNaming")]
[SuppressMessage("ReSharper", "HeapView.BoxingAllocation")]
public class AttachedPropSG : BaseGenerator
{
    protected override IEnumerable<string> TargetAttributes => new[]
    {
        "AttachedProp",
        "AttachedPropAttribute"
    };

    protected override void ProcessField(StringBuilder source, TypeDeclarationSyntax typeDeclarationSyntax,
        SyntaxNode syntaxNode,
        ISymbol fieldSymbol)
    {
        var bindablePropParam =
            SyntaxUtil.ExtractCreateBindablePropertyParam(typeDeclarationSyntax, syntaxNode, fieldSymbol, "AttachedProp");

        var defaultOnChangedDelegate = SyntaxUtil.GetDefaultOnChangedDelegate(
            bindablePropParam.ClassType!,
            bindablePropParam.PropName!,
            bindablePropParam.FieldType!
        );

        // For AttachedProp, we don't create a default function for PropertyChangingDelegate
        if (defaultOnChangedDelegate == bindablePropParam.PropertyChangedDelegate)
        {
            bindablePropParam.PropertyChangedDelegate = "null";
        }

        source.Append($@"
        public {bindablePropParam.NewKeyWord} static readonly BindableProperty {bindablePropParam.PropName}Property = BindableProperty.CreateAttached(
            ""{bindablePropParam.PropName}"",
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

        public {bindablePropParam.NewKeyWord} static {bindablePropParam.FieldType} Get{bindablePropParam.PropName}(BindableObject view)
        {{
            return ({bindablePropParam.FieldType})view.GetValue({bindablePropParam.PropName}Property);
        }}

        {bindablePropParam.NewKeyWord} public static void Set{bindablePropParam.PropName}(BindableObject view, {bindablePropParam.FieldType} value)
        {{
            view.SetValue({bindablePropParam.PropName}Property, value);
        }}
");
    }
}