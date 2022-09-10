using NewCelebrities.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;

namespace NewCelebrities.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class RegionsShould
    {
        private readonly ServerFixture Given;

        public RegionsShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_all_found()
        {
            var response = await Given
              .Server
              .CreateRequest(RegionEndpoints.GetAll)
              .GetAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var countriesReponse = await response.ReadJsonResponse<GetRegionsResponse>();

            countriesReponse.Regions.Should().Contain("Western Europe");
        }
    }
}
