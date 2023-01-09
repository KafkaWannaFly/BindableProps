---
layout: default
title: AllBindableProps and IgnoredProp
nav_order: 3
---

# AllBindableProps and IgnoredProp

If you just need the default setting for many of your props, try this:

```c#
[AllBindableProps]
public partial class TextInput : ContentView
{
    // Default field
    string text;

    // Support field with a default value
    string placeHolder = "Do you trust me?";

    // This field will be handled by BindableProp
    [BindableProp(
        DefaultBindingMode = (int)BindingMode.TwoWay,
        ValidateValueDelegate = nameof(ValidateValue)
        )]
    string message = "With every cell in my body!";

    [IgnoredProp]
    bool isBusy; // Don't touch!

    // If you have existing props, we don't touch them
    public static readonly BindableProperty ErrorProperty = BindableProperty.Create(
            nameof(Error),
            typeof(string),
            typeof(TextInput),
            "Things just get out of hand",
            (BindingMode)(int)BindingMode.OneWayToSource
        );

    // Also not touch this prop
    public string Error
    {
        get => (string)GetValue(TextInput.ErrorProperty);
        set
        {
            SetValue(TextInput.ErrorProperty, value);
        }
    }

    static bool ValidateValue(BindableObject bindable, object value)
    {
        return true;
    }
    
    public TextInput()
    {
        InitializeComponent();
    }
}
```

And the result is:

```c#
namespace WibuTube.Controls
{
    public partial class TextInput
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
                    nameof(Text),
                    typeof(string),
                    typeof(TextInput),
                    default,
                    propertyChanged: (bindable, oldValue, newValue) =>
                                    ((TextInput)bindable).Text = (string)newValue
                );

        public string Text
        {
            get => text;
            set 
            { 
                OnPropertyChanging(nameof(Text));

                text = value;
                SetValue(TextInput.TextProperty, text);

                OnPropertyChanged(nameof(Text));
            }
        }

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
                    nameof(PlaceHolder),
                    typeof(string),
                    typeof(TextInput),
                    "Do you trust me?",
                    propertyChanged: (bindable, oldValue, newValue) =>
                                    ((TextInput)bindable).PlaceHolder = (string)newValue
                );

        public string PlaceHolder
        {
            get => placeHolder;
            set 
            { 
                OnPropertyChanging(nameof(PlaceHolder));

                placeHolder = value;
                SetValue(TextInput.PlaceHolderProperty, placeHolder);

                OnPropertyChanged(nameof(PlaceHolder));
            }
        }

    }
}
```