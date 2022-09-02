using NewCelebrities.Core;
using System.Net.Http.Json;
using SharedModel = NewCelebrities.Shared;

namespace NewCelebrities.Web.Services
{
    public class GameCreator
    {
        private readonly HttpClient httpClient;

        public GameCreator(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<Game> Create(int rounds, int cardCount, params Color[] teamColors)
        {
            var request = new SharedModel.GetCharactersRequest()
            {
                Count = cardCount,
                IncludeEasy = true,
            };

            var characters = await GetCharacters(request);
            var game = new Game(rounds, characters, teamColors.Select(x => new Team(x)).ToList());
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
