namespace BindablePropsSG.Utils;

public class BindablePropertyParam
{
    public string? NewKeyWord { get; set; }
    public string? PropName { get; set; }
    public string? FieldType { get; set; }

    public string? UnNullableFieldType
    {
        get
        {
            var unNullableDataType = FieldType;
            if (unNullableDataType != null && unNullableDataType[unNullableDataType.Length - 1] == '?')
            {
                unNullableDataType = unNullableDataType.Substring(0, unNullableDataType.Length - 1);
            }

            return unNullableDataType;
        }
    }

    public string? FieldName { get; set; }
    public string? ClassType { get; set; }
    public string? DefaultValue { get; set; }
    public string? BindingMode { get; set; }
    public string? PropertyChangingDelegate { get; set; }
    public string? PropertyChangedDelegate { get; set; }
    public string? ValidateValueDelegate { get; set; }
    public string? CoerceValueDelegate { get; set; }
    public string? CreateDefaultValueDelegate { get; set; }
}