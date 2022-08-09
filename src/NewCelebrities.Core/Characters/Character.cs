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

        public override string ToString() => $"{Name} {Popularity}";
    }
}