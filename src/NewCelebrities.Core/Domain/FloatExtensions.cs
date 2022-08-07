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
    }

}