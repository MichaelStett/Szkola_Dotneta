using System.Collections.Generic;
using Xunit;

namespace CheckPower.Test
{
    public class Test
    {
        [Fact]
        public void Should_ReturnTrue_When_SquaredIsSquareOfNumbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var squares = new List<int> { 1, 4, 9, 16, 25 };

            var IsEqual = squares.IsSquareOf(numbers);

            Assert.True(IsEqual);
        }

        [Fact]
        public void Should_ReturnFalse_When_SquaredIsNotSquareOfNumbers()
        {
            var numbers = new List<int> { 1, 2, 3, 4, 5 };
            var squares = new List<int> { 2, 2, 9, 16, 25 };

            var IsEqual = squares.IsSquareOf(numbers);

            Assert.False(IsEqual);
        }
    }
}
