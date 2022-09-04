namespace NewCelebrities.Core
{
    public class TurnSummary
    {
        public int Round { get; }
        public Team Team { get; }
        public int Turn { get; }
        public IEnumerable<string> Characters { get; }
        public int Points => Characters.Count();
        public string CharacterNames => string.Join(", ", Characters);

        public TurnSummary(Team team, int turn, IEnumerable<string> characters)
        {
            Team = team;
            Turn = turn;
            Characters = characters;
        }

        public override string ToString() => $"{Team} - {Points} point{(Points == 1 ? "" : "s")}";
    }
}
