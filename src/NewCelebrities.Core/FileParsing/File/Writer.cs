namespace NewCelebrities.Core.File
{
    public static class Writer
    {
        public const char Separator = ',';

        public static void WriteToFile(this IEnumerable<Character> character, string filePath)
        {
            var lines = character.Select(character =>
            {
                var items = new string[]
                {
                    character.Name,
                    character.Time.ToPrimitive(),
                    character.Gender.FromGender(),
                    character.Profession ?? "",
                    character.Location.ToPrimitive(),
                    character.Popularity.ToPrimitive(),
                    character.Categories.ToPrimitive()
                };
                var gender = character.Gender.FromGender();

                return string.Join(Separator, items);
            }).ToList();

            System.IO.File.WriteAllLines(filePath, lines);
        }
    }
}