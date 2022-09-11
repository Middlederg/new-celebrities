using System.Globalization;
using Blazored.LocalStorage;

namespace NewCelebrities.Web.Services
{
    public class LanguageSelector
    {
        private const string key = "currentCulture";

        private readonly ILocalStorageService localStorage;

        public LanguageSelector(ILocalStorageService localStorage)
        {
            this.localStorage = localStorage;
        }

        public async Task SetCurrentCulture(string culture)
        {
            var currentCulture = new CultureInfo(culture);
            await localStorage.SetItemAsStringAsync(key, culture);
            CultureInfo.DefaultThreadCurrentCulture = currentCulture;
            CultureInfo.DefaultThreadCurrentUICulture = currentCulture;      
        }

        public async Task<CultureInfo> GetCurrentCulture()
        {
            var culture = await localStorage.GetItemAsync<string>(key);
            if (culture is null)
            {
                return null;
            }
            var currentCulture = new CultureInfo(culture);
            return currentCulture;
        }
    }
}
