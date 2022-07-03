using BindableProps;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1;

public partial class MyComponent
{
    [BindableProp(ValidateValueDelegate = nameof(doSomething))]
    string title = "Thou hast made me endless";

    void doSomething() { }
}
