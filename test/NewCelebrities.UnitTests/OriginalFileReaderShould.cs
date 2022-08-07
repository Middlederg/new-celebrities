using FluentAssertions;
using NewCelebrities.Core.OriginalFile;
using System.Globalization;

namespace NewCelebrities.UnitTests
{
    public class OriginalFileReaderShould
    {
        [Fact]
        public void Read_small()
        {
            var lines = File.ReadAllLines("files/sample.csv");
            var characters = Reader.Read(lines);
            characters.Should().HaveCount(31);
        }

        [Fact]
        public void Read_huge()
        {
            var lines = File.ReadAllLines("C:\\Users\\Public\\repos\\cross-verified-database.csv");
            var characters = Reader.Read(lines);
            characters.Should().HaveCount(2291817);
        }
    }
}