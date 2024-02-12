namespace BindableProps
{
    /// <summary>
    /// Use together with <c>AllBindableProps</c>. This will ignore the field from being generated as a BindableProperty
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    // ReSharper disable once UnusedType.Global
    public sealed class IgnoredProp : Attribute;
}
