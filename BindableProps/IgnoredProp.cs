namespace BindableProps
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class IgnoredProp : Attribute
    {
    }
}
