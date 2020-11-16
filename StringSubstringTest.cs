using System;
using Xunit;

namespace Pedenko_UnitTest_Homework
{
    public class StringSubstringTest
    {
        [Theory]
        [InlineData("One Two Three Four Five", 0, "One Two Three Four Five")]
        [InlineData("One Two Three Four Five", 4, "Two Three Four Five")]
        [InlineData("One Two Three Four Five", 23, "")]
        public void ArgsInt_IfValidParameters_WorkCorrect(string input, int startIndex, string expectedResult)
        {
            string result = input.Substring(startIndex);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("One Two Three Four Five", 4, 9, "Two Three")]
        [InlineData("One Two Three Four Five", 19, 4, "Five")]
        [InlineData("One Two Three Four Five", 0, 23, "One Two Three Four Five")]
        [InlineData("One Two Three Four Five", 23, 0, "")]
        public void ArgsIntAndInt_IfValidParameters_WorkCorrect(string input, int startIndex, int length, string expectedResult)
        {
            string result = input.Substring(startIndex, length);
            Assert.Equal(result, expectedResult);
        }


        [Fact]
        public void IfStartIndexLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Hello world".Substring(-1));
        }

        [Fact]
        public void IfStartIndexGreaterThanTheLengthOfInstance_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Hello world".Substring(12));
        }

        [Fact]
        public void IfStartIndexPlusLengthGreaterThanTheLengthOfInstance_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Hello world".Substring(6,7));
        }

        [Fact]
        public void IfLengthLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "Hello world".Substring(0, -7));
        }
    }
}
