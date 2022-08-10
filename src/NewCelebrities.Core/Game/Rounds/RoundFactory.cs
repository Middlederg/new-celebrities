using System;
using System.Collections.Generic;

namespace NewCelebrities.Core
{
    public class RoundFactory
    {
        public const int MinimunRounds = 1;
        public const int MaximunRounds = 4;
        public const int DefaultTotalRounds = 3;

        private readonly int totalRounds;

        public RoundFactory(int totalRounds)
        {
            if (totalRounds < MinimunRounds || totalRounds > MaximunRounds)
            {
                throw new ArgumentException($"Can not create {totalRounds} in a game");
            }
            this.totalRounds = totalRounds;
        }

        public IEnumerable<Round> Create()
        {
            yield return new FirstRound();
            if (totalRounds >= 2) yield return new SecondRound();
            if (totalRounds >= 3) yield return new ThirdRound();
            if (totalRounds >= 4) yield return new FourthRound();
        }
    }
}
