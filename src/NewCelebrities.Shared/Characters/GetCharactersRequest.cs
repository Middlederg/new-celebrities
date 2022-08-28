using System.Collections.Generic;

namespace NewCelebrities.Shared
{
    public class GetCharactersRequest
    {
        public bool IncludeEasy { get; set; }
        public bool IncludeIntermediate { get; set; }
        public bool IncludeHard { get; set; }
        public IEnumerable<string> CategoriesToInclude { get; set; }
        public IEnumerable<string> CountriesToInclude { get; set; }
        public int Count { get; set; }
    }
}
