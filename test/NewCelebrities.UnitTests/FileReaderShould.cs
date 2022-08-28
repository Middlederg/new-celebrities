using FluentAssertions;
using NewCelebrities.Core.File;

namespace NewCelebrities.UnitTests
{
    public class FileReaderShould
    {
        [Fact]
        public void Read_small()
        {
            string sourcePath = "files/sample.csv";
            string destinyPath = "files/transformed.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.OriginalFile.Reader.Read(lines);
            characters.WriteToFile(destinyPath);
            var fileExists = File.Exists(destinyPath);
            fileExists.Should().BeTrue();

            lines = File.ReadAllLines(destinyPath);
            var newCharacters = Reader.Read(lines);
            newCharacters.Should().BeEquivalentTo(characters);
        }


        [Fact(Skip = "Its huge")]
        public void Read_huge()
        {
            string sourcePath = "C:\\Users\\Public\\repos\\cross-verified-database.csv";
            string destinyPath = "files/transformed_huge.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.OriginalFile.Reader.Read(lines);
            characters.WriteToFile(destinyPath);
            var fileExists = File.Exists(destinyPath);
            fileExists.Should().BeTrue();

            lines = File.ReadAllLines(destinyPath);
            characters = Reader.Read(lines);
            characters.Should().HaveCount(2291817);
        }

        [Fact]
        public void Read_populars()
        {
            string sourcePath = "files/populars.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Reader.Read(lines);
            characters.Should().HaveCount(23754);
        }

        [Fact(Skip ="just for test")]
        public void Separate()
        {
            string sourcePath = "C:\\Users\\Public\\repos\\transformed-database.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Reader.Read(lines);
            characters.Should().HaveCount(2291817);

            var popularity = characters.GroupBy(x => x.Popularity.Stars)
                .ToDictionary(x => x.Key, x => x.Count());

            var proffesion = characters.GroupBy(x => x.Profession)
             .ToDictionary(x => x.Key, x => x.Count());

            var countries = characters.GroupBy(x => x.Location.Country)
                .ToDictionary(x => x.Key, x => x.Count());

            var age = characters.GroupBy(x => x.Time.Age)
               .ToDictionary(x => x.Key, x => x.Count());

            var cats = characters.SelectMany(x => x.Categories.CategoryList).Distinct();
        }

       
    }
}