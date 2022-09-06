using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class Game
    {
        private GameStatus status;

        public RoundContext RoundContext { get; }
        public TurnContext TurnContext { get; }
        public Deck Deck { get; }

        public Team CurrentTeam => TurnContext.CurrentTeam;

        public int SecondsPerTurn { get; }

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

        public Game(int totalRounds, int secondsPerTurn, IEnumerable<Character> characters, List<Team> teams)
        {
            RoundContext = new RoundContext(totalRounds);
            TurnContext = new TurnContext(teams);
            Deck = new Deck(characters);
            CreationDate = DateTime.Now;
            status = GameStatus.RoundStart;
            SecondsPerTurn = secondsPerTurn;
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
            CurrentTeam.AddPoint(deckItem, RoundContext.CurrentRoundNumber, TurnContext.Index);
            Deck.VisibleItem.Guess();

            if (Deck.IsFinished)
            {
                status = GameStatus.EndOfTurn;
            }
        }

        public void SkipToNextItem()
        {
            Deck.Skip();
        }

        public void OnTimesUp()
        {
            Deck.Skip();
            status = GameStatus.EndOfTurn;
        }

        public void EndTurn()
        {
            MoveToNextTurn();

            if (Deck.IsFinished)
            {
                if (!RoundContext.IsLastRound())
                {
                    status = GameStatus.EndOfRound;
                }
                else
                {
                    status = GameStatus.EndOfGame;
                }
            }
            else status = GameStatus.TeamPreparation;
        }

        public void EndRound()
        {
            MoveToNextRound();
            status = GameStatus.RoundStart;
        }

        public void StartTeamPreparation() => status = GameStatus.TeamPreparation;
        public void StartGuessing() => status = GameStatus.Guessing;

        public bool ShowRoundStart => status == GameStatus.RoundStart;
        public bool ShowTeamPreparation => status == GameStatus.TeamPreparation;
        public bool WeAreGusessing => status == GameStatus.Guessing;
        public bool ShowTurnEnd => status == GameStatus.EndOfTurn;
        public bool ShowRoundEnd => status == GameStatus.EndOfRound;
        public bool ShowGameEnd => status == GameStatus.EndOfGame;
    }
}
