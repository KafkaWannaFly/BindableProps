namespace BindableProps
{
    /// <summary>
    /// Generate BindableProperty for the field
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    // ReSharper disable once UnusedType.Global
    public class BindableProp : Attribute
    {
        public int DefaultBindingMode { get; set; }

        public string? ValidateValueDelegate { get; set; }

        public string? PropertyChangedDelegate { get; set; }

        public string? PropertyChangingDelegate { get; set; }

        public string? CoerceValueDelegate { get; set; }

        public string? CreateDefaultValueDelegate { get; set; }
    }
}