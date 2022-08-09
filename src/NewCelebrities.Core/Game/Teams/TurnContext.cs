using System.Collections.Generic;
using System.Linq;

namespace NewCelebrities.Core
{
    public class TurnContext
    {
        public List<Team> Teams { get; }
        private readonly int currentTeamIndex;
        public int TotalTeams => Teams.Count;

        public TurnContext(List<Team> teams)
        {
            this.teams = teams;
            this.currentTeamIndex = 0;
        }

        private int NextTeamIndex => currentTeam >= TotalTeams - 1 ? 0 : currentTeam + 1;
        
        public Team NextTeam => Teams.ElementAt(NextTeamIndex);
        public Team CurrentTeam => Teams.ElementAt(currentTeam);

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