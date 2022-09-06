using Blazored.LocalStorage;
using NewCelebrities.Core;
using NewCelebrities.Web.Models;
using System.Net.Http.Json;

namespace NewCelebrities.Web.Services
{
    public class GameOptionsService
    {
        private readonly ILocalStorageService localStorage;

        public GameOptionsService(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task<GameOptionsModel> GetOptions()
        {
            var options = await localStorage.GetItemAsync<GameOptionsModel>("options");
            return options;
        }

        public async Task Save(GameOptionsModel options)
        {
            await localStorage.SetItemAsync("options", options);
        }
    }
}
