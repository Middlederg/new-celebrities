using System.Net.Http.Json;
using System.Reflection.Metadata;
using Microsoft.JSInterop;
using NewCelebrities.Web.Client;
using NewCelebrities.Web.Models;
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

        public async Task<ContentResponse<SharedModel.GetCategoriesResponse>> ListCategories()
        {
            var response = await httpClient.GetAsync("api/categories");
            var result = await ContentResponse<SharedModel.GetCategoriesResponse>.Build(response);
            return result;
        }

        public async Task<ContentResponse<SharedModel.GetRegionsResponse>> ListRegions()
        {
            var response = await httpClient.GetAsync("api/regions");
            var result = await ContentResponse<SharedModel.GetRegionsResponse>.Build(response);
            return result;
        }
    }
}
