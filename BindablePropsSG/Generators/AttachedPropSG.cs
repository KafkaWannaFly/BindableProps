﻿using System.Diagnostics.CodeAnalysis;
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

    protected override void ProcessField(StringBuilder source, ClassDeclarationSyntax classSyntax,
        SyntaxNode syntaxNode,
        ISymbol fieldSymbol)
    {
        var fieldName = fieldSymbol.Name;
        var pascalCaseFieldName = StringUtil.PascalCaseOf(fieldName);
        var propName = $"{pascalCaseFieldName}Property";

        if (pascalCaseFieldName.Length == 0 || pascalCaseFieldName == fieldName)
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

        var attributeSyntax = SyntaxUtil.GetAttributeByName(fieldSyntax, "AttachedProp");

        var attributeArguments = attributeSyntax?.ArgumentList?.Arguments;

        var defaultBindingMode = SyntaxUtil.GetAttributeParam(attributeArguments, "DefaultBindingMode") ?? "0";

        var validateValueDelegate = SyntaxUtil.GetAttributeParam(attributeArguments, "ValidateValueDelegate") ?? "null";

        var propertyChangedDelegate =
            SyntaxUtil.GetAttributeParam(attributeArguments, "PropertyChangedDelegate") ?? "null";

        var propertyChangingDelegate =
            SyntaxUtil.GetAttributeParam(attributeArguments, "PropertyChangingDelegate") ?? "null";

        var coerceValueDelegate = SyntaxUtil.GetAttributeParam(attributeArguments, "CoerceValueDelegate") ?? "null";

        var createDefaultValueDelegate =
            SyntaxUtil.GetAttributeParam(attributeArguments, "CreateDefaultValueDelegate") ?? "null";

        source.Append($@"
        public {newKeyword} static readonly BindableProperty {propName} = BindableProperty.CreateAttached(
            ""{pascalCaseFieldName}"",
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

        public {newKeyword} static {fieldType} Get{pascalCaseFieldName}(BindableObject view)
        {{
            return ({fieldType})view.GetValue({propName});
        }}

        {newKeyword} public static void Set{pascalCaseFieldName}(BindableObject view, {fieldType} value)
        {{
            view.SetValue({propName}, value);
        }}
");
    }
}