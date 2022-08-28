using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.TestHost;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewCelebrities.FunctionalTests
{
    public static class RequestBuilderExtensions
    {
        public static Task<HttpResponseMessage> PutAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Put);
        }

        public static Task<HttpResponseMessage> PatchAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Patch);
        }

        public static Task<HttpResponseMessage> DeleteAsync(this RequestBuilder requestBuilder)
        {
            return requestBuilder.SendAsync(HttpMethods.Delete);
        }

        public static RequestBuilder WithJsonBody<TContent>(this RequestBuilder builder, TContent content, string contentType = "application/json")
        {
            var json = JsonConvert.SerializeObject(content);

            return builder.And(message =>
            {
                message.Content = new StringContent(json, Encoding.UTF8, contentType);
            });
        }

        public static async Task<TModel> ReadJsonResponse<TModel>(this HttpResponseMessage response)
        {
            var json = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<TModel>(json);
            return result;
        }

        public static async Task ShouldBe(this HttpResponseMessage response, int statusCode)
        {
            response.StatusCode.Should().Be(statusCode, await response.Content.ReadAsStringAsync());
        }
    }
}
