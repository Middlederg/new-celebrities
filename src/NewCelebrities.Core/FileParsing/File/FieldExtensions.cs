using NewCelebrities.Shared;

namespace NewCelebrities.Core.File
{
    public static class FieldExtensions
    {
        public static string GetString(this string[] line, Field field)
        {
            int index = (int)field;
            if (index >= line.Length)
            {
                return "";
            }
            return line[index];
        }

        public static int? GetInt(this string[] line, Field field)
        {
            string result = line.GetString(field);
            if (!int.TryParse(result, out int parsedResult))
            {
                return null;
            }
            return parsedResult;
        }

        public static float? GetFloat(this string[] line, Field field)
        {
            string result = line.GetString(field);
            return result.Parse();
        }

        public static Gender? GetGender(this string[] line, Field field)
        {
            string result = line.GetString(field);
            if (!Enum.TryParse(result, out Gender parsedResult))
            {
                return null;
            }
            return parsedResult;
        }

        public static Age? GetAge(this string[] line, Field field)
        {
            string result = line.GetString(field);
            if (!Enum.TryParse(result, out Age parsedResult))
            {
                return null;
            }
            return parsedResult;
        }

        public static string FromGender(this Gender? gender)
        {
            string result = gender.HasValue ? ((int)gender).ToString() : "";
            return result;
        }

        public static string FromEnum(this Age? age)
        {
            string result = age.HasValue ? ((int)age).ToString() : "";
            return result;
        }
    }
}