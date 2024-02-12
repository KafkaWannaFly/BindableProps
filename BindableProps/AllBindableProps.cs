namespace BindableProps
{
    /// <summary>
    /// Generate Bindable Property for all fields in the class
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    // ReSharper disable once UnusedType.Global
    public sealed class AllBindableProps : Attribute;
}
