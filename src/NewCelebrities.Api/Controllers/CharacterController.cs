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

            allCharacters = allCharacters.Where(x => request.CountryShouldBeIncluded(x.Location.Country)).ToList();
            allCharacters = allCharacters.Where(x => request.CategoriesShouldBeIncluded(x.Categories.CategoryList)).ToList();
            
            var characters = allCharacters.RandomizeList();

            var selectedCharacters = characters.Take(request.Count).Select(x => Map(x));

            return Ok(new Shared.GetCharactersResponse()
            {
                Characters = selectedCharacters,
            });
        }

        private static Shared.Character Map(Character character)
        {
            return new Shared.Character()
            {
                Categories = character.Categories.CategoryList,
                Gender = character.Gender,
                Name = character.Name,
                Profession = character.Profession,
                Time = character.Time.ToDto(),
                Location = character.Location.ToDto(),
                Popularity = (int?)character.Popularity
            };
        }
    }
}
