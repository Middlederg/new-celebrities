using NewCelebrities.Shared;

namespace NewCelebrities.Core.OriginalFile
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
            return line[index] != "Missing" ? line[index] : "";
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

        public static FileAge? GetAge(this string[] line, Field field)
        {
            string result = line.GetString(field);

            if (result == Ages.Ancient) return FileAge.Ancient;
            if (result == Ages.PostClasical) return FileAge.PostClasical;
            if (result == Ages.EarlyModern) return FileAge.EarlyModern;
            if (result == Ages.MidModern) return FileAge.MidModern;
            if (result == Ages.Contemporary) return FileAge.Contemporary;
            return null;
        }  
    }


}