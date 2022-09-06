using FluentAssertions;
using NewCelebrities.Core.File;
using NewCelebrities.Core.OriginalFile;

namespace NewCelebrities.UnitTests
{
    public class FileWriterShould
    {
        [Fact]
        public void Write_small()
        {
            string sourcePath = "files/sample.csv";
            string destinyPath = "files/transformed.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.OriginalFile.Reader.Read(lines);
            characters.WriteToFile(destinyPath);
            var fileExists = File.Exists(destinyPath);
            fileExists.Should().BeTrue();
        }

        [Fact(Skip = "It is too large")]
        public void Write_huge()
        {
            string sourcePath = "C:\\Users\\Public\\repos\\cross-verified-database.csv";
            string destinyPath = "files/transformed_huge.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.OriginalFile.Reader.Read(lines);
            characters.WriteToFile(destinyPath);
            var fileExists = File.Exists(destinyPath);
            fileExists.Should().BeTrue();
        }

        [Fact(Skip = "It is too large")]
        public void Write_populars()
        {
            string sourcePath = "C:\\Users\\Public\\repos\\cross-verified-database.csv";
            var lines = File.ReadAllLines(sourcePath);
            var characters = Core.OriginalFile.Reader.Read(lines);

            var populars = characters.Where(x => x.Popularity.Stars >= 40).ToList();

            string destinyPath = "files/populars.csv";
            populars.WriteToFile(destinyPath);
        }
    }
}