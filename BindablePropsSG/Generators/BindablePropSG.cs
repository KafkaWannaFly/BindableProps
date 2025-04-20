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
        protected override IEnumerable<string> TargetAttributes =>
        [
            "BindableProp",
            "BindablePropAttribute"
        ];

        protected override void ProcessField(StringBuilder source, TypeDeclarationSyntax typeDeclarationSyntax,
            SyntaxNode syntaxNode,
            ISymbol fieldSymbol)
        {
            var bindablePropParam =
                SyntaxUtil.ExtractCreateBindablePropertyParam(typeDeclarationSyntax, syntaxNode, fieldSymbol, "BindableProp");

            source.Append($$"""

                                    public {{bindablePropParam.NewKeyWord}} static readonly BindableProperty {{bindablePropParam.PropName}}Property = BindableProperty.Create(
                                        nameof({{bindablePropParam.PropName}}),
                                        typeof({{bindablePropParam.UnNullableFieldType}}),
                                        typeof({{bindablePropParam.ClassType}}),
                                        {{bindablePropParam.DefaultValue}},
                                        (BindingMode){{bindablePropParam.BindingMode}},
                                        {{bindablePropParam.ValidateValueDelegate}},
                                        {{bindablePropParam.PropertyChangedDelegate}},
                                        {{bindablePropParam.PropertyChangingDelegate}},
                                        {{bindablePropParam.CoerceValueDelegate}},
                                        {{bindablePropParam.CreateDefaultValueDelegate}}
                                    );

                                    public {{bindablePropParam.NewKeyWord}} {{bindablePropParam.FieldType}} {{bindablePropParam.PropName}}
                                    {
                                        get => {{bindablePropParam.FieldName}};
                                        set 
                                        { 
                                            OnPropertyChanging(nameof({{bindablePropParam.PropName}}));

                                            {{bindablePropParam.FieldName}} = value;
                                            SetValue({{bindablePropParam.ClassType}}.{{bindablePropParam.PropName}}Property, {{bindablePropParam.FieldName}});

                                            OnPropertyChanged(nameof({{bindablePropParam.PropName}}));
                                        }
                                    }

                            """);
        }
    }
}