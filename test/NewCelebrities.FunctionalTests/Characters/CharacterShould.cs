using NewCelebrities.Shared;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;
using Xunit;
using FluentAssertions;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.TestHost;

namespace NewCelebrities.FunctionalTests
{
    [Collection(nameof(ServerFixtureCollection))]
    public class CharacterShould
    {
        private readonly ServerFixture Given;

        public CharacterShould(ServerFixture fixture)
        {
            Given = fixture ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task Be_10_easy_found()
        {
            int count = 10;
            var request = new GetCharactersRequest()
            {
                Count = count,
                IncludeEasy = true
            };

            List<Core.Character> characters = await GetCharacters(request);

            characters.Should().HaveCount(count);
            characters.All(x => x.Popularity.Easy).Should().BeTrue();
        }

        [Fact]
        public async Task Be_6_intermediate_found()
        {
            int count = 6;
            var request = new GetCharactersRequest()
            {
                Count = count,
                IncludeIntermediate = true
            };

            List<Core.Character> characters = await GetCharacters(request);

            characters.Should().HaveCount(count);
            characters.All(x => x.Popularity.Intermediate).Should().BeTrue();
        }

        [Fact]
        public async Task Be_7_hard_found()
        {
            int count = 7;
            var request = new GetCharactersRequest()
            {
                Count = count,
                IncludeHard = true
            };

            List<Core.Character> characters = await GetCharacters(request);

            characters.Should().HaveCount(count);
            characters.All(x => x.Popularity.Hard).Should().BeTrue();
        }

        [Fact]
        public async Task Be_16_from_spain_found()
        {
            int count = 16;
            var request = new GetCharactersRequest()
            {
                Count = count,
                CountriesToInclude = new string[] { "Old regimes in / of Spain" },
                IncludeEasy = true,
                IncludeIntermediate = true,
                IncludeHard = true 
            };

            List<Core.Character> characters = await GetCharacters(request);

            characters.Should().HaveCount(count);
            characters.All(x => x.Location.ToString().Equals("Old regimes in / of Spain", StringComparison.OrdinalIgnoreCase)).Should().BeTrue();
        }

        [Fact]
        public async Task Be_11_from_sports_found()
        {
            int count = 11;
            var request = new GetCharactersRequest()
            {
                Count = count,
                CategoriesToInclude = new string[] { "sports/games" },
                IncludeEasy = true,
                IncludeIntermediate = true,
                IncludeHard = true
            };

            List<Core.Character> characters = await GetCharacters( request);

            characters.Should().HaveCount(count);
            characters.All(x => x.Categories.Has("sports/games")).Should().BeTrue();
        }

        private async Task<List<Core.Character>> GetCharacters(GetCharactersRequest request)
        {
            var response = await Given
               .Server
               .CreateRequest(CharacterEndpoints.PostToObtain)
               .WithJsonBody(request)
               .PostAsync();

            await response.ShouldBe(StatusCodes.Status200OK);
            var getCharactersResponse = await response.ReadJsonResponse<GetCharactersResponse>();

            var characters = getCharactersResponse.Characters.Select(x => Core.Character.FromDto(x)).ToList();
            return characters;
        }
    }
}
