namespace NewCelebrities.Core
{
    public class Team
    {
        public Guid Id { get; }

        public string Name { get; private set; }

        public Color Color { get; private set; }

        private readonly List<Point> points;
        public void AddPoint(DeckItem concept, int round) => points.Add(new Point(concept, round));

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

        public IEnumerable<string> GuessedCharacters(Round round)
        {
            return points
                .Where(x => x.Round == round.Number)
                .Select(x => x.CharacterName);
        }

        public IEnumerable<string> TotalGuessedCharacters()
        {
            return points.Select(x => x.CharacterName);
        }

        public IEnumerable<RoundSummary> Summary(int totalRounds)
        {
            foreach (var round in new RoundFactory(totalRounds).Create())
            {
                var guessedCharacters = GuessedCharacters(round);
                yield return new RoundSummary(round.Number, guessedCharacters);
            }
        }

        public override string ToString() => Name.ToString();
    }

}
