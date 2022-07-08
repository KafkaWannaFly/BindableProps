namespace BindableProps
{
    /// <summary>
    /// If you just need the default setting for all of your props, try this:
    /// 
    /// <code>
    ///[AllBindableProps]
    ///public partial class TextInput : ContentView
    ///{
    ///    // Default field
    ///    string text;
    ///
    ///    // Support field with a default value
    ///    string placeHolder = "Do you trust me?";
    ///
    ///    // This field will be handled by BindableProp
    ///    [BindableProp(
    ///        DefaultBindingMode = (int)BindingMode.TwoWay,
    ///        ValidateValueDelegate = nameof(ValidateValue)
    ///        )]
    ///    string message = "With every cell in my body!";
    ///
    ///    [IgnoredProp]
    ///    bool isBusy; // Don't touch!
    ///
    ///    // If you have existing props, we don't touch them
    ///    public static readonly BindableProperty ErrorProperty = BindableProperty.Create(
    ///            nameof(Error),
    ///            typeof(string),
    ///            typeof(TextInput),
    ///            "Things just get out of hand",
    ///            (BindingMode)(int)BindingMode.OneWayToSource
    ///        );
    ///
    ///    // Also not touch this prop
    ///    public string Error
    ///    {
    ///        get => (string)GetValue(TextInput.ErrorProperty);
    ///        set
    ///        {
    ///            SetValue(TextInput.ErrorProperty, value);
    ///        }
    ///    }
    ///
    ///    static bool ValidateValue(BindableObject bindable, object value)
    ///    {
    ///        return true;
    ///    }
    ///
    ///    public TextInput()
    ///    {
    ///        InitializeComponent();
    ///    }
    ///}
    /// </code>
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class AllBindableProps : Attribute
    {
    }
}
