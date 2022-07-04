# BindableProps

[![NuGet](https://buildstats.info/nuget/BindableProps?includePreReleases=true)](https://www.nuget.org/packages/BindableProps/) ![Build Status](https://github.com/KafkaWannaFly/BindableProps/actions/workflows/publish-to-nuget.yaml/badge.svg)

> I spend hours to save your moments.

This library helps you to reduce writing boilerplate code when creating your custom UI components.

## Example Usage

Let say you want to create your own text input. Here's how it looks:

```c#
namespace MyMauiApp.Controls;

public class TextInput : ContentView
{
    public string Text
    {
        get => (string)GetValue(TextInput.TextProperty);
        set => SetValue(TextInput.TextProperty, value);
    }

    public static readonly BindableProperty TextProperty = BindableProperty.Create(
        nameof(Text), typeof(string), typeof(TextInput), string.Empty
        );

    public string PlaceHolder
    {
        get => (string)GetValue(TextInput.PlaceHolderProperty);
        set => SetValue(TextInput.PlaceHolderProperty, value);
    }

    public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
        nameof(PlaceHolder), typeof(string), typeof(TextInput), string.Empty
        );


    public TextInput()
    {
        // Implement your logic
    }
}
```



With `BindableProps`, your code will become like this:

```c#
using BindableProps;

namespace MyMauiApp.Controls;

// Notice: Your class must be partial class
public partial class TextInput : ContentView
{
    [BindableProp]
    string text;

    [BindableProp]
    string placeHolder;


    public TextInput()
    {
        // This piece is same as above
    }
}
```

The real magic happens at Solution Explorer > Dependencies > Analyzers > BindablePropsSG

![image-20220704231041505](README.assets/image-20220704231041505.png)

What you would see in `TextInput.g.cs` is the boilerplate code which you had to write. I'll write them for you!

```c#
using BindableProps;

namespace MyMauiApp.Controls
{
    public partial class TextInput
    {

        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TextInput),
            default,
            BindingMode.Default,
            null,
            null,
            null,
            null,
            null
        );

        public string Text
        {
            get => text;
            set 
            { 
                text = value;
                SetValue(TextInput.TextProperty, text);
            }
        }

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
            nameof(PlaceHolder),
            typeof(string),
            typeof(TextInput),
            default,
            BindingMode.Default,
            null,
            null,
            null,
            null,
            null
        );

        public string PlaceHolder
        {
            get => placeHolder;
            set 
            { 
                placeHolder = value;
                SetValue(TextInput.PlaceHolderProperty, placeHolder);
            }
        }

    }
}
```



The above example is the minimal amount of code to work. Here is the complete features:

```c#
public partial class TextInput : ContentView
{
    // Create prop with a few settings
    [BindableProp(DefaultBindingMode = ((int)BindingMode.TwoWay))]
    string text = "From every time";

    // Full setting
    [BindableProp(
        DefaultBindingMode = ((int)BindingMode.OneWay),
        ValidateValueDelegate = nameof(ValidateValue),
        PropertyChangedDelegate = nameof(PropertyChangedDelegate),
        PropertyChangingDelegate = nameof(PropertyChangingDelegate),
        CoerceValueDelegate = nameof(CoerceValueDelegate),
        CreateDefaultValueDelegate = nameof(CreateDefaultValueDelegate)
        )]
    string placeHolder = "Always!";

    static bool ValidateValue(BindableObject bindable, object value)
    {
        return true;
    }

    static void PropertyChangedDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        // Do something
    }

    static void PropertyChangingDelegate(BindableObject bindable, object oldValue, object newValue)
    {
        // Do something
    }

    static object CoerceValueDelegate(BindableObject bindable, object value)
    {
        // Do something
        return 0;
    }

    static object CreateDefaultValueDelegate(BindableObject bindable)
    {
        // Do something
        return string.Empty;
    }
}
```



And the corresponding result would like:

```c#
public partial class TextInput
    {
        public static readonly BindableProperty TextProperty = BindableProperty.Create(
            nameof(Text),
            typeof(string),
            typeof(TextInput),
            "From every time",
            ((int)BindingMode.TwoWay),
            null,
            null,
            null,
            null,
            null
        );

        public string Text
        {
            get => text;
            set 
            { 
                text = value;
                SetValue(TextInput.TextProperty, text);
            }
        }

        public static readonly BindableProperty PlaceHolderProperty = BindableProperty.Create(
            nameof(PlaceHolder),
            typeof(string),
            typeof(TextInput),
            "Always!",
            ((int)BindingMode.OneWay),
            ValidateValue,
            PropertyChangedDelegate,
            PropertyChangingDelegate,
            CoerceValueDelegate,
            CreateDefaultValueDelegate
        );

        public string PlaceHolder
        {
            get => placeHolder;
            set 
            { 
                placeHolder = value;
                SetValue(TextInput.PlaceHolderProperty, placeHolder);
            }
        }

    }
```



## Roadmap

The `BindableProp` along is just not enough for covering all use-cases of `BindableProperty`. Planning features:

| Attribute                      | Equivalent/Description                                       |
| ------------------------------ | ------------------------------------------------------------ |
| `BindableAttachedProp`         | `BindableProperty.CreateAttached`                            |
| `BindableAttachedReadOnlyProp` | `BindablePropertyKey.CreateAttachedReadOnly`                 |
| `BindableReadOnlyProp`         | `BindablePropertyKey.CreateReadOnly`                         |
| `AllBindableProps`             | Put this to your class,<br />Default `BindableProp` to all field members |
| `IgnoredProp`                  | `AllBindableProps` should ignore this field                  |

