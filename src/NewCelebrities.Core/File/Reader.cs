namespace NewCelebrities.Core.File
{
    public class Reader
    {
        public static IEnumerable<Character> Read(string[] lines)
        {
            var characters = lines.Skip(1).Select(x =>
            {
                var line = x.Split(Writer.Separator);

                int itemsToSkip = ((int)Field.Categories) - 1;
                var categories = line.Skip(itemsToSkip).ToArray();
                
                return new Character()
                {
                    Name = line.GetString(Field.Name),
                    Gender = line.GetGender(Field.Gender),
                    Time = new Time(bornYear: line.GetInt(Field.BornYear),
                         deathYear: line.GetInt(Field.DeathYear),
                         birthMin: line.GetInt(Field.BirthMin),
                         birthMax: line.GetInt(Field.BirthMax),
                         deathMin: line.GetInt(Field.DeathMin),
                         deathMax: line.GetInt(Field.DeathMax),
                         ageBirth: line.GetAge(Field.AgeBirth),
                         ageDeath: line.GetAge(Field.AgeDeath)),
                    Profession = line.GetString(Field.Profession),
                    Location = new Location(country: line.GetString(Field.Country),
                        citizenship: line.GetString(Field.Citizenship),
                        place: line.GetString(Field.Place),
                        subregion: line.GetString(Field.Subregion),
                        birthplaceLatitude: line.GetFloat(Field.BirthPlaceCoordinatesLat),
                        birthplaceLongitude: line.GetFloat(Field.BirthPlaceCoordinatesLong),
                        deathPlaceLatitude: line.GetFloat(Field.DeathPlaceCoordinatesLat),
                        deathPlaceLongitude: line.GetFloat(Field.DeathPlaceCoordinatesLong)),
                    Popularity = new Popularity(line.GetInt(Field.WikipediaReaders)),
                    Categories = new Categories(categories)
                };
            }).ToList();
            return characters;
        }
    }
}