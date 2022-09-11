using System.Net.Http;
using System.Threading.Tasks;

namespace NewCelebrities.Web.Client
{
    public class EmptyResponse : ApiBaseResponse
    {
        private EmptyResponse() { }
        public static async Task<EmptyResponse> Build(HttpResponseMessage response)
        {
            var result = new EmptyResponse();
            await result.SetResponse(response);
            return result;
        }

        private async Task SetResponse(HttpResponseMessage response)
        {
            await ReadErrors(response);
        }
    }
}
