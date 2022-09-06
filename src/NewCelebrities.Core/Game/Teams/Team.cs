using System.Text;

namespace NewCelebrities.Core
{
    public class Team
    {
        public Guid Id { get; }

        public string Name { get; private set; }

        public Color Color { get; private set; }

        private readonly List<Point> points;
        public void AddPoint(DeckItem concept, int round, int turn) => points.Add(new Point(concept, round, turn));

        public int Fails { get; private set; }
        public void AddFailure() => Fails++;

        public Team(Color color, string name = null)
        {
            Id = Guid.NewGuid();
            Name = string.IsNullOrWhiteSpace(name) ? color.ToString() : name;
            Color = color;
            points = new List<Point>();
            Fails = 0;
        }

        public int Points => points.Count;
        public string TotalGuessedCharacters() => string.Join(", ", points.Select(x => x.CharacterName));

        public IEnumerable<RoundSummary> RoundSummary(int totalRounds)
        {
            foreach (var round in new RoundFactory(totalRounds).Create())
            {
                var guessedCharacters =  points
                        .Where(x => x.Round == round.Number)
                        .Select(x => x.CharacterName);
                yield return new RoundSummary(round.Number, guessedCharacters);
            }
        }

        public TurnSummary TurnSummary(int turn)
        {
            var guessedCharacters = points
                       .Where(x => x.Turn == turn)
                       .Select(x => x.CharacterName);
            return new TurnSummary(this, turn, guessedCharacters);
        }

        public override string ToString() => Name.ToString();
    }

}
