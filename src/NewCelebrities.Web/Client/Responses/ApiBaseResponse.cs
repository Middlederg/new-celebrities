using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NewCelebrities.Web.Client
{
    public abstract class ApiBaseResponse : IResponse
    {
        private string url;
        private ProblemDetails problemDetails;
        public string Title => $"{problemDetails?.Title ?? ""}";
        public string Description => $"{problemDetails?.Detail ?? ""} at {url}";
        public bool HasError => problemDetails != null;
        public bool Success => !HasError;

        protected ApiBaseResponse() { }
        protected async Task<bool> ReadErrors(HttpResponseMessage response)
        {
            if (!response.IsSuccessStatusCode)
            {
                url = response.RequestMessage.RequestUri?.ToString() ?? "";
                problemDetails = await response.Content.ReadFromJsonAsync<ProblemDetails>();
                return true;
            }
            return false;
        }

        public override string ToString() => problemDetails?.Type?.ToString() ?? "";
    }
}
