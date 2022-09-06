using NewCelebrities.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace NewCelebrities.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class CategoriesShould
    {
        private readonly ServerFixture Given;

        public CategoriesShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_all_found()
        {
            var response = await Given
              .Server
              .CreateRequest(CategoriesEndpoints.GetAll)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var countriesReponse = await response.ReadJsonResponse<GetCategoriesResponse>();

            countriesReponse.Categories.Should().Contain("Sports/Games");
        }
    }
}
