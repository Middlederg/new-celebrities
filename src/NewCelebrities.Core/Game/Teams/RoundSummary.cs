using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class RoundSummary
    {
        public int Round { get; }
        public IEnumerable<string> Characters { get; }
        public int Points => Characters.Count();
        public string CharacterNames => string.Join(", ", Characters);

        public RoundSummary(int round, IEnumerable<string> concepts)
        {
            Round = round;
            Characters = concepts;
        }

        public override string ToString() => $"Round {Round} - {Points} point{(Points == 1 ? "" : "s")}";
    }
}
