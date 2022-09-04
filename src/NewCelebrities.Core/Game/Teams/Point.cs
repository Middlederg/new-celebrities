namespace NewCelebrities.Core
{
    public class Point
    {
        public string CharacterName { get;  }
        public int Round { get;  }
        public int Turn { get; }

        public Point(DeckItem concept, int round, int turn)
        {
            CharacterName = concept.ToString();
            Round = round;
            Turn = turn;
        }

        public override string ToString() => $"{CharacterName} (Round {Round})";
    }
}
