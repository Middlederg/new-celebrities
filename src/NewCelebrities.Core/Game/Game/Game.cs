using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class Game
    {
        public RoundContext RoundContext { get; }
        public TurnContext TurnContext { get; }
        public Deck Deck { get; }

        public Team CurrentTeam => TurnContext.CurrentTeam;

        public void MoveToNextTurn()
        {
            TurnContext.MoveToNextTurn();
        }

        public void MoveToNextRound()
        {
            RoundContext.MoveToNextRound();
            Deck.Reset();
        }

        public DateTime CreationDate { get; }

        public Game(int totalRounds, IEnumerable<Character> characters, List<Team> teams)
        {
            RoundContext = new RoundContext(totalRounds);
            TurnContext = new TurnContext(teams);
            Deck = new Deck(characters);
            CreationDate = DateTime.Now;
        }

        public Percentage GetPercentage()
        {
            var numerator = Deck.Count * (RoundContext.CurrentRoundNumber - 1);
            numerator += Deck.GuessedCount;
            var denominator = Deck.Count * RoundContext.TotalRounds;
            return new Percentage(numerator, denominator);
        }

        public void GuessVisibleItem()
        {
            var deckItem = Deck.VisibleItem;
            CurrentTeam.AddPoint(deckItem, RoundContext.CurrentRoundNumber);
            Deck.VisibleItem.Guess();
        }

        public void FailVisibleItem()
        {
            CurrentTeam.AddFailure();
        }

        public void OnTimesUp()
        {
           MoveToNextTurn();
           if (Deck.IsFinished)
           {
                MoveToNextRound();
               //Deck.NextConcept();
           }
        }
    }
}
