using System.Globalization;

namespace NewCelebrities.Core
{
    public static class FloatExtensions
    {
        public static float? Parse(this string input)
        {
            if (!float.TryParse(input, NumberStyles.Number, CultureInfo.InvariantCulture, out float parsedResult))
            {
                return null;
            }
            return parsedResult;
        }

        public static string ToText(this float? value)
        {
            if (!value.HasValue)
            {
                return "";
            }
            return value.Value.ToText();
        }

        public static string ToText(this float value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }

}