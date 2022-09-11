using System.Net.Http.Json;

namespace NewCelebrities.Web.Client
{
    public class ContentResponse<T> : ApiBaseResponse
    {
        public T Content { get; private set; }

        private ContentResponse() { }
        public static async Task<ContentResponse<T>> Build(HttpResponseMessage response)
        {
            var result = new ContentResponse<T>();
            await result.SetResponse(response);
            return result;
        }

        private async Task SetResponse(HttpResponseMessage response)
        {
            if (!await ReadErrors(response))
            {
                Content = await response.Content.ReadFromJsonAsync<T>();
            }
        }
    }
}
