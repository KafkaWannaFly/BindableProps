using System;
using System.Collections.Generic;
using System.Text;

namespace BindablePropsSG.Utils
{
    public class StringUtil
    {
        public static string PascalCaseOf(string fieldName)
        {
            fieldName = fieldName.TrimStart('_');
            if (fieldName.Length == 0)
                return string.Empty;

            if (fieldName.Length == 1)
                return fieldName.ToUpper();

            return fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1);
        }
    }
}
