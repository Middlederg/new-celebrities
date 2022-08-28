using System.Collections.Generic;

namespace NewCelebrities.Shared
{
    public class Character
    {
        public string Name { get; init; }
        public Time Time { get; init; }
        public Gender? Gender { get; init; }
        public string Profession { get; init; }
        public Location Location { get; init; }
        public int? Popularity { get; init; }
        public IEnumerable<string> Categories { get; init; }
    }
}
