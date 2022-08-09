namespace NewCelebrities.Core
{
    public class Point
    {
        public string CharacterName { get;  }
        public int Round { get;  }
       
        public Point(DeckItem concept, int round)
        {
            CharacterName = concept.ToString();
            Round = round;
        }

        public override string ToString() => $"{CharacterName} (Round {Round})";
    }
}
