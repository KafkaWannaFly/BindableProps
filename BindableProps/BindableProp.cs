using System;

namespace BindableProps
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    public sealed class BindableProp : Attribute
    {
        public BindingMode? DefaultBindingMode { get; set; }

        public string? ValidateValueDelegate { get; set; }

        public string? PropertyChangedDelegate { get; set; }

        public string? PropertyChangingDelegate { get; set; }

        public string? CoerceValueDelegate { get; set; }

        public string? CreateDefaultValueDelegate { get; set; }

        public BindableProp()
        {

        }
    }
}
