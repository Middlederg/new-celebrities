using FluentAssertions;
using NewCelebrities.Core;

namespace NewCelebrities.UnitTests
{
    public class GameCreatorShould
    {
        [Fact]
        public void Create_game()
        {
            string sourcePath = "files/populars.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.File.Reader.Read(lines).ToList();
            var selectedCharacters = characters.RandomizeList().Take(40);
            var game = new Game(3, selectedCharacters, 
                new[] { Color.DarkParty, Color.Lemon }.Select(x => new Team(x)).ToList());

            game.Deck.Count.Should().Be(40);
        }
    }
}