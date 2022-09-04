using NewCelebrities.Shared;

namespace NewCelebrities.Core
{
    public class Character
    {
        public string Name { get; init; }
        public Time Time { get; init; }
        public Gender? Gender { get; init; }
        public string Profession { get; init; }
        public Location Location { get; init; }
        public Popularity Popularity { get; init; }
        public Categories Categories { get; init; }

        public override string ToString() => Name.Replace("_", " ");

        public static Character FromDto(Shared.Character dto)
        {
            return new Character()
            {
                Name = dto.Name,
                Gender = dto.Gender,
                Time = Time.FromDto(dto.Time),
                Profession = dto.Profession,
                Location = Location.FromDto(dto.Location),
                Popularity = new Popularity(dto.Popularity),
                Categories = new Categories(dto.Categories.ToArray())
            };
        }
    }
}