namespace NewCelebrities.Shared
{
    public record Time
    {
        public int? BornYear { get; init; }
        public int? DeathYear { get; init; }
        public int? BirthMin { get; init; }
        public int? BirthMax { get; init; }
        public int? DeathMin { get; init; }
        public int? DeathMax { get; init; }
        public FileAge? AgeBirth { get; init; }
        public FileAge? AgeDeath { get; init; }
    }
}
