using System.Linq;
using NewCelebrities.Core;
using System.Collections.Generic;
using Microsoft.Extensions.Caching.Memory;

namespace NewCelebrities.Api.Services
{
    public class FileRepository
    {
        private readonly IMemoryCache memoryCache;

        public FileRepository(IMemoryCache memoryCache)
        {
            this.memoryCache = memoryCache;
        }

        public IEnumerable<Character> CharacterList()
        {
            var characters = memoryCache.GetOrCreate("characters", (cacheEntry) =>
            {
                var lines = System.IO.File.ReadLines("data/populars.csv").ToArray();
                var allCharacters = Core.File.Reader.Read(lines).ToList();
                return allCharacters;
            });
            return characters;
        }

        public IEnumerable<string> CategoryList()
        {
            var categories = memoryCache.GetOrCreate("categories", (cacheEntry) =>
            {
                var characters = CharacterList();
                var allCategories = characters
                    .SelectMany(x => x.Categories.CategoryList)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
                return allCategories;
            });
            return categories;
        }

        public IEnumerable<string> CountryList()
        {
            var countries = memoryCache.GetOrCreate("countries", (cacheEntry) =>
            {
                var characters = CharacterList();

                var allCountries = characters
                    .Where(x => x.Location is not null & x.Location.HasCountry())
                    .Select(x => x.Location.Country)
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();

                return allCountries;
            });
            return countries;
        }
    }
}
