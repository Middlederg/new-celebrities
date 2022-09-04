using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class RoundContext
    {
        public int CurrentRoundIndex { get; private set; }
        public void MoveToNextRound() => CurrentRoundIndex++;
        public bool IsLastRound() => CurrentRoundIndex >= rounds.Count() - 1;

        private readonly IEnumerable<Round> rounds;
        public Round CurrentRound => rounds.ElementAt(CurrentRoundIndex - 1);
        public int CurrentRoundNumber => CurrentRound.Number;
        public int TotalRounds => rounds.Count();

        private RoundContext() { }
        public RoundContext(int totalRounds)
        {
            rounds = new RoundFactory(totalRounds).Create();
            CurrentRoundIndex = 1;
        }
    }
}
