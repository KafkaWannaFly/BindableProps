using BindableProps;
using System;

namespace MauiApp1;

public partial class MyControl : ContentView
{
    [BindableProp]
    string myName = "12345678";

    public MyControl()
    {
        InitializeComponent();
    }
}