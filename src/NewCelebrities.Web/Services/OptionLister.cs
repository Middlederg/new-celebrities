using System.Net.Http.Json;
using SharedModel = NewCelebrities.Shared;

namespace NewCelebrities.Web.Services
{
    public class OptionLister
    {
        private readonly HttpClient httpClient;

        public OptionLister(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<IEnumerable<string>> ListCategories()
        {
            var response = await httpClient.GetFromJsonAsync<SharedModel.GetCategoriesResponse>("api/categories");
            return response.Categories;
        }

        public async Task<IEnumerable<string>> ListCountries()
        {
            var response = await httpClient.GetFromJsonAsync<SharedModel.GetRegionsResponse>("api/countries");
            return response.Regions;
        }
    }
}
