namespace BindablePropsSG.Utils
{
    public static class StringUtil
    {
        public static string PascalCaseOf(string fieldName)
        {
            fieldName = fieldName.TrimStart('_');
            return fieldName.Length switch
            {
                0 => string.Empty,
                1 => fieldName.ToUpper(),
                _ => fieldName.Substring(0, 1).ToUpper() + fieldName.Substring(1)
            };
        }
    }
}
