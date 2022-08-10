using NewCelebrities.Core;

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
            var response = await httpClient.GetAsync("data/populars.csv");
            var result = await response.Content.ReadAsStringAsync();
            var lines = result.Split(Environment.NewLine);
            var characters = Core.File.Reader.Read(lines).ToList();
            var selectedCharacters = characters.RandomizeList().Take(cardCount);
            var game = new Game(rounds, selectedCharacters, teamColors.Select(x => new Team(x)).ToList());
            return game;
        }
    }
}
