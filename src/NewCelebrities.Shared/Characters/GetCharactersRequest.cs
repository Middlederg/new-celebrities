using System;
using System.Collections.Generic;
using System.Linq;

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

        public bool CountryShouldBeIncluded(string country)
        {
            if (CountriesToInclude is null || !CountriesToInclude.Any())
            {
                return true;
            }
            return CountriesToInclude.Contains(country, StringComparer.InvariantCultureIgnoreCase);
        }

        public bool CategoriesShouldBeIncluded(IEnumerable<string> categories)
        {
            if (CategoriesToInclude is null || !CategoriesToInclude.Any())
            {
                return true;
            }
            return CategoriesToInclude.Any(x => categories.Contains(x, StringComparer.InvariantCultureIgnoreCase));
        }
    }
}
