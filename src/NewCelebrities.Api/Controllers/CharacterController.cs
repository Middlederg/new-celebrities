using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Linq;
using NewCelebrities.Core;

namespace NewCelebrities.Api
{
    [ApiController]
    [Route(Shared.CharacterEndpoints.Base)]
    public class CharacterController : ControllerBase
    {
        [HttpPost]
        public ActionResult<Shared.GetCharactersResponse> PostToGetCharacters(Shared.GetCharactersRequest request)
        {
            var lines = System.IO.File.ReadLines("data/populars.csv").ToArray();
            var allCharacters = Core.File.Reader.Read(lines).ToList();

            if (!request.IncludeEasy)
            {
                allCharacters = allCharacters.Where(x => !x.Popularity.Easy).ToList();
            }

            if (!request.IncludeIntermediate)
            {
                allCharacters = allCharacters.Where(x => !x.Popularity.Intermediate).ToList();
            }

            if (!request.IncludeHard)
            {
                allCharacters = allCharacters.Where(x => !x.Popularity.Hard).ToList();
            }

            if (request.CountriesToInclude is not null && request.CountriesToInclude.Any(x => !string.IsNullOrWhiteSpace(x)))
            {
                allCharacters = allCharacters.Where(x => request.CountriesToInclude.Contains(x.Location.Country, StringComparer.InvariantCultureIgnoreCase)).ToList();
            }

            if (request.CategoriesToInclude is not null && request.CategoriesToInclude.Any(x => !string.IsNullOrWhiteSpace(x)))
            {
                allCharacters = allCharacters.Where(x => request.CategoriesToInclude.Contains(x.Categories.Has()).ToList();
            }

            var characters = allCharacters.RandomizeList();

            var selectedCharacters = characters.Take(request.Count);
            //map characters
            return Ok(selectedCharacters);
        }
    }
}
