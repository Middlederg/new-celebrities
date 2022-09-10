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
        public IEnumerable<string> RegionsToInclude { get; set; }
        public IEnumerable<Age> AgesToInclude { get; set; }
        public int Count { get; set; }

        public bool RegionShouldBeIncluded(string country)
        {
            if (RegionsToInclude is null || !RegionsToInclude.Any())
            {
                return true;
            }
            return RegionsToInclude.Contains(country, StringComparer.InvariantCultureIgnoreCase);
        }

        public bool CategoriesShouldBeIncluded(IEnumerable<string> categories)
        {
            if (CategoriesToInclude is null || !CategoriesToInclude.Any())
            {
                return true;
            }
            return CategoriesToInclude.Any(x => categories.Contains(x, StringComparer.InvariantCultureIgnoreCase));
        }

        public bool AgeShouldBeIncluded(Age age)
        {
            if (AgesToInclude is null || !AgesToInclude.Any())
            {
                return true;
            }
            return AgesToInclude.Any(x => age == x);
        }
    }
}
