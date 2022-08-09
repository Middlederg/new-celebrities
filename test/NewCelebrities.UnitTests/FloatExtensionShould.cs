using FluentAssertions;
using NewCelebrities.Core;

namespace NewCelebrities.UnitTests
{
    public class FloatExtensionShould
    {
        [Theory]
        [InlineData("20.254416108196", 20.2544155)]
        [InlineData("-87.62777777777799", -87.62778)]
        public void Convert_to_float(string input, float expected)
        {
            var result = input.Parse();
            result.Should().HaveValue();
            Latitude.IsValid(result).Should().BeTrue();
            result.Should().Be(expected);
        }

        [Theory]
        [InlineData(20.2544155, "20.254416")]
        [InlineData(-87.62778, "-87.62778")]
        public void Convert_from_float(float input, string expected)
        {
            var result = input.ToText();
            result.Should().Be(expected);
        }
    }
}