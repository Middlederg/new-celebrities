namespace NewCelebrities.Core.OriginalFile
{
    public class Reader
    {
        public static IEnumerable<Character> Read(string[] lines)
        {
            var characters = lines.Skip(1).Select(x =>
            {
                var line = x.Split(",");
                return new Character()
                {
                    Categories = new Categories(line.GetString(Field.level1_main_occ), line.GetString(Field.level2_main_occ), line.GetString(Field.level2_second_occ)),
                    Name = line.GetString(Field.name),
                    Gender = line.GetGender(Field.gender),
                    Time = new Time(bornYear: line.GetInt(Field.birth),
                         deathYear: line.GetInt(Field.death),
                         birthMin: line.GetInt(Field.birth_min),
                         birthMax: line.GetInt(Field.birth_max),
                         deathMin: line.GetInt(Field.death_min),
                         deathMax: line.GetInt(Field.death_max),
                         ageBirth: line.GetAge(Field.bigperiod_birth),
                         ageDeath: line.GetAge(Field.bigperiod_death)),
                    Profession = line.GetString(Field.level2_second_occ),
                    Location = new Location(country: line.GetString(Field.all_geography_groups),
                        citizenship: line.GetString(Field.citizenship_1_b),
                        place: line.GetString(Field.area1_of_rattachment),
                        subregion: line.GetString(Field.un_subregion),
                        birthplaceLatitude: line.GetFloat(Field.bpla1),
                        birthplaceLongitude: line.GetFloat(Field.bplo1),
                        deathPlaceLatitude: line.GetFloat(Field.dpla1),
                        deathPlaceLongitude: line.GetFloat(Field.dplo1)),
                    Popularity = new Popularity(line.GetInt(Field.wiki_readers_2015_2018))
                };
            }).ToList();
            return characters;
        }
    }
}