using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using System.Linq;
using NewCelebrities.Core;
using NewCelebrities.Api.Services;

namespace NewCelebrities.Api
{
    [ApiController]
    [Route(Shared.CharacterEndpoints.Base)]
    public class CharacterController : ControllerBase
    {
        private readonly FileRepository repository;

        public CharacterController(FileRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public ActionResult<Shared.GetCharactersResponse> PostToGetCharacters(Shared.GetCharactersRequest request)
        {
            var allCharacters = repository.CharacterList().ToList();

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

            allCharacters = allCharacters.Where(x => request.RegionShouldBeIncluded(x.Location.Subregion)).ToList();
            allCharacters = allCharacters.Where(x => request.CategoriesShouldBeIncluded(x.Categories.CategoryList)).ToList();
            allCharacters = allCharacters.Where(x => request.AgeShouldBeIncluded(x.Time.Age)).ToList();
            
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
