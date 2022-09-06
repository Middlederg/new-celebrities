using NewCelebrities.Core;
using System.ComponentModel.DataAnnotations;

namespace NewCelebrities.Web.Models
{
    public class GameOptionsModel
    {        
        [Range(Deck.Min, Deck.Max, ErrorMessage = $"Card count must be between 5 and 40")]
        public int CardCount { get; set; }

        [Range(RoundFactory.MinimunRounds, RoundFactory.MaximunRounds, ErrorMessage = $"Rounds must be between 1 and 4")]
        public int RoundCount { get; set; }
        
        [Range(10, 120, ErrorMessage = $"Time must be between 10 seconds and 2 minutes")]
        public int Seconds { get; set; }

        public bool IncludeEasy { get; set; }
        public bool IncludeIntermediate { get; set; }
        public bool IncludeHard { get; set; }

        public IEnumerable<string> CategoriesToInclude { get; set; }
        public IEnumerable<string> CountriesToInclude { get; set; }

        public IEnumerable<Team> Teams { get; set; }

        public class Team
        {
            public int ColorIndex { get; set; }
            public string Name { get; set; }
        }
    }

}
