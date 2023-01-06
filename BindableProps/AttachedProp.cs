namespace BindableProps;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
public sealed class AttachedProp : Attribute
{
    public int DefaultBindingMode { get; set; }

    public string? ValidateValueDelegate { get; set; }

    public string? PropertyChangedDelegate { get; set; }

    public string? PropertyChangingDelegate { get; set; }

    public string? CoerceValueDelegate { get; set; }

    public string? CreateDefaultValueDelegate { get; set; }
}