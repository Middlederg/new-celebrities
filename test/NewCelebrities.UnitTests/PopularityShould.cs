using FluentAssertions;
using NewCelebrities.Core;

namespace NewCelebrities.UnitTests
{
    public class PopularityShould
    {
        [Fact]
        public void Render_0_stars()
        {
            var popularity = Popularity.FromStars(0);
            popularity.Stars.Should().Be(0);
            popularity.FullStars().Should().Be(0);
            popularity.HalfStars().Should().Be(0);
            popularity.EmptyStars().Should().Be(5);
        }

        [Fact]
        public void Render_2_stars()
        {
            var popularity = Popularity.FromStars(20);
            popularity.Stars.Should().Be(20);
            popularity.FullStars().Should().Be(2);
            popularity.HalfStars().Should().Be(0);
            popularity.EmptyStars().Should().Be(3);
        }

        [Fact]
        public void Render_2_and_a_half_stars()
        {
            var popularity = Popularity.FromStars(25);
            popularity.Stars.Should().Be(25);
            popularity.FullStars().Should().Be(2);
            popularity.HalfStars().Should().Be(1);
            popularity.EmptyStars().Should().Be(2);
        }

        [Fact]
        public void Render_4_and_a_half_stars()
        {
            var popularity = Popularity.FromStars(45);
            popularity.Stars.Should().Be(45);
            popularity.FullStars().Should().Be(4);
            popularity.HalfStars().Should().Be(1);
            popularity.EmptyStars().Should().Be(0);
        }

        [Fact]
        public void Render_5__stars()
        {
            var popularity = Popularity.FromStars(50);
            popularity.Stars.Should().Be(50);
            popularity.FullStars().Should().Be(5);
            popularity.HalfStars().Should().Be(0);
            popularity.EmptyStars().Should().Be(0);
        }
    }
}