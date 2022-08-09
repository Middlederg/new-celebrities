using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class Ranking
    {
        public IEnumerable<Team> Teams { get; }

        public Ranking(IEnumerable<Team> teams)
        {
            Teams = teams;
        }

        public IEnumerable<Team> GetRanking()
        {
            return Teams
                .OrderByDescending(x => x.TotalGuessedCharacters())
                .ToList();
        }

        public Team Winner()
        {
            return GetRanking().First();
        }
    }
}
