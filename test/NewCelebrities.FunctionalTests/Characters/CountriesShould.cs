using NewCelebrities.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace NewCelebrities.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class CountriesShould
    {
        private readonly ServerFixture Given;

        public CountriesShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_all_found()
        {
            var response = await Given
              .Server
              .CreateRequest(CountriesEndpoints.GetAll)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var countriesReponse = await response.ReadJsonResponse<GetCountriesResponse>();

            countriesReponse.Countries.Should().Contain("Spain");
        }
    }
}
