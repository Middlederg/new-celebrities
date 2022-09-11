using NewCelebrities.Core;
using NewCelebrities.Web.Client;
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

        public async Task<(IResponse response, Game game)> Create()
        {
            var options = await gameOptionsService.GetOptions();

            var request = new SharedModel.GetCharactersRequest()
            {
                Count = options.CardCount,
                CategoriesToInclude = options.CategoriesToInclude,
                RegionsToInclude = options.RegionsToInclude,
                IncludeHard = options.IncludeHard,
                IncludeIntermediate = options.IncludeIntermediate,
                IncludeEasy = options.IncludeEasy,
                AgesToInclude = options.AgesToInclude,
            };

            var characterResponse = await GetCharacters(request);

            if (characterResponse.HasError)
            {
                return (characterResponse, null);
            }

            try
            {
                var characters = characterResponse.Content.Characters.Select(character => Character.FromDto(character));
                var game = new Game(options.RoundCount, options.SecondsPerTurn, options.HeroMode, characters, options.Teams.Select(x => new Team(Color.GetByIndex(x.ColorIndex), x.Name)).ToList());

                return (OkResponse.Build(), game);
            }
            catch (Exception ex)
            {
                return (MessageResponse.Build(ex.Message), null);
            }
        }

        private async Task<ContentResponse<SharedModel.GetCharactersResponse>> GetCharacters(SharedModel.GetCharactersRequest request)
        {
            var response = await httpClient.PostAsJsonAsync("api/characters", request);
            return await ContentResponse<SharedModel.GetCharactersResponse>.Build(response);
        }
    }
}
