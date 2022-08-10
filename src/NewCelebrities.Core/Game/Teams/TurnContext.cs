using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class TurnContext
    {
        public List<Team> Teams { get; }
        private int currentTeamIndex;
        public int TotalTeams => Teams.Count;

        public TurnContext(List<Team> teams)
        {
            Teams = teams;
            currentTeamIndex = 0;
        }

        private int NextTeamIndex => currentTeamIndex >= TotalTeams - 1 ? 0 : currentTeamIndex + 1;
        
        public Team NextTeam => Teams.ElementAt(NextTeamIndex);
        public Team CurrentTeam => Teams.ElementAt(currentTeamIndex);

        public void MoveToNextTurn()
        {
            currentTeamIndex = NextTeamIndex;
        }

        public IEnumerable<Team> GetRanking()
        {
            return Teams
                .OrderByDescending(x => x.TotalGuessedCharacters())
                .ToList();
        }
 
        public Team Winner() => GetRanking().First();
        
    }
}