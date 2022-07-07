#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
namespace BindableProps
{
    /// <summary>
    /// Auto generate code for <c>BindableProperty.Create</c>
    /// 
    /// <example>
    /// Let say you want to create your own text input. Here's how it looks:
    /// <code>
    /// public partial class TextInput : ContentView
    /// {
    ///     // Create prop with a few settings
    ///     [BindableProp(DefaultBindingMode = ((int)BindingMode.TwoWay))]
    ///     string text = "From every time";
    ///     
    ///     // Full setting
    ///     [BindableProp(
    ///         DefaultBindingMode = ((int)BindingMode.OneWay),
    ///         ValidateValueDelegate = nameof(ValidateValue),
    ///         PropertyChangedDelegate = nameof(PropertyChangedDelegate),
    ///         PropertyChangingDelegate = nameof(PropertyChangingDelegate),
    ///         CoerceValueDelegate = nameof(CoerceValueDelegate),
    ///         CreateDefaultValueDelegate = nameof(CreateDefaultValueDelegate)
    ///         )]
    ///     string placeHolder = "Always!";
    ///     
    ///     static bool ValidateValue(BindableObject bindable, object value)
    ///     {
    ///         return true;
    ///     }
    /// 
    ///     static void PropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    ///     {
    ///         // Do something
    ///     }
    ///     
    ///     static void PropertyChangingDelegate(BindableObject bindable, object oldValue, object newValue)
    ///     {
    ///        // Do something
    ///     }
    ///     
    ///     static object CoerceValueDelegate(BindableObject bindable, object value)
    ///     {
    ///         // Do something
    ///         return 0;
    ///     }
    /// 
    ///     static object CreateDefaultValueDelegate(BindableObject bindable)
    ///     {
    ///         // Do something
    ///         return string.Empty;
    ///     }
    /// }
    /// </code>
    /// </example>
    /// </summary>
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class BindableProp : Attribute
    {
        public int DefaultBindingMode { get; set; }

        public string ValidateValueDelegate { get; set; }

        public string PropertyChangedDelegate { get; set; }

        public string PropertyChangingDelegate { get; set; }

        public string CoerceValueDelegate { get; set; }

        public string CreateDefaultValueDelegate { get; set; }


        public BindableProp()
        {

        }
    }
}
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
