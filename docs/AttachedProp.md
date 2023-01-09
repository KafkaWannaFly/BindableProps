---
layout: default
title: AttachedProp
nav_order: 4
---

# AttachedProp

You could expect this attribute to work similar to `BindableProp`

## Simple Usage

For example:

```c#
namespace MyMauiApp.Controls
{
    public partial class MyMauiControl : ContentView
    {
        [AttachedProp]
        private bool _hasShadow;
    
        public MyMauiControl()
        {
            // My logic
        }
    }
    
}
```

Result is:

```c#
// <auto-generated/>

namespace MyMauiApp.Controls
{
    public partial class MyMauiControl
    {
        public static readonly BindableProperty HasShadowProperty = BindableProperty.CreateAttached(
            "HasShadow",
            typeof(bool),
            typeof(MyMauiControl),
            default,
            (BindingMode)0,
            null,
            null,
            null,
            null,
            null
        );
        
        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }
    }
}
```

Then, you could use this in other page like:

```xml
<?xml version="1.0" encoding="utf-8" ?>
<ContentPage xmlns="http://schemas.microsoft.com/dotnet/2021/maui"
             xmlns:x="http://schemas.microsoft.com/winfx/2009/xaml"
             xmlns:vm="clr-namespace:MyMauiApp.ViewModels"
             xmlns:controls="clr-namespace:MyMauiApp.Controls"
             x:Class="MyMauiApp.MainPage"
             x:DataType="vm:MainPageViewModel">
    
    <controls:TextInput PlaceHolder="Say you do"
                        Text="{Binding MyLoveStory, Mode=TwoWay}" />
    <Button
                        Grid.Column="1"
                        Padding="12"
                        Command="{Binding SearchVideoCommand}"
                        CommandParameter="{x:Reference mainPage}"
                        FontFamily="Segoe MDL2 Assets"
                        FontSize="20"
                        IsEnabled="{Binding IsValidUrl}"
                        Text="&#xE721;"
                        controls:TextInput.HasShadow="False"
                    />
</ContentPage>
```

## Full Usage

```c#
namespace MyMauiApp.Controls
{
    public partial class MyMauiControl : ContentView
    {
        [AttachedProp(
            DefaultBindingMode = ((int)BindingMode.OneWay),
            ValidateValueDelegate = nameof(ValidateValue),
            PropertyChangedDelegate = nameof(PropertyChangedDelegate),
            PropertyChangingDelegate = nameof(PropertyChangingDelegate),
            CoerceValueDelegate = nameof(CoerceValueDelegate),
            CreateDefaultValueDelegate = nameof(CreateDefaultValueDelegate)
        )]
        private bool _hasShadow = false;
    
        public MyMauiControl()
        {
            // My logic
        }
        
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
    
}
```

Result:

```c#
// <auto-generated/>

namespace MyMauiApp.Controls
{
    public partial class MyMauiControl
    {
        public static readonly BindableProperty HasShadowProperty = BindableProperty.CreateAttached(
            "HasShadow",
            typeof(bool),
            typeof(MyMauiControl),
            false,
            (BindingMode)((int)BindingMode.OneWay),
            ValidateValue,
            PropertyChangedDelegate,
            PropertyChangingDelegate,
            CoerceValueDelegate,
            CreateDefaultValueDelegate
        );
        
        public static bool GetHasShadow(BindableObject view)
        {
            return (bool)view.GetValue(HasShadowProperty);
        }

        public static void SetHasShadow(BindableObject view, bool value)
        {
            view.SetValue(HasShadowProperty, value);
        }
    }
}
```
