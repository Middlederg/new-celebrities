using NewCelebrities.Core;
using System.Net.Http.Json;
using SharedModel = NewCelebrities.Shared;

namespace NewCelebrities.Web.Services
{
    public class GameCreator
    {
        private readonly HttpClient httpClient;
        private readonly GameOptionsService gameOptionsService;

        public GameCreator(HttpClient httpClient, GameOptionsService gameOptionsService)
        {
            this.httpClient = httpClient;
            this.gameOptionsService = gameOptionsService;
        }

        public async Task<Game> Create()
        {
            var options = await gameOptionsService.GetOptions();
            
            var request = new SharedModel.GetCharactersRequest()
            {
                Count = options.CardCount,
                CategoriesToInclude = options.CategoriesToInclude,
                CountriesToInclude = options.CountriesToInclude,
                IncludeHard = options.IncludeHard,
                IncludeIntermediate = options.IncludeIntermediate,
                IncludeEasy = options.IncludeEasy
            };

            var characters = await GetCharacters(request);
            var game = new Game(options.RoundCount, options.SecondsPerTurn, characters, options.Teams.Select(x => new Team(Color.GetByIndex(x.ColorIndex), x.Name)).ToList());
            return game;
        }

        private async Task<IEnumerable<Character>> GetCharacters(SharedModel.GetCharactersRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/characters", request);
            var result = await response.Content.ReadFromJsonAsync<SharedModel.GetCharactersResponse>();
            return result.Characters.Select(character => Character.FromDto(character));
        }
    }
}
