using System;
using Xunit;

namespace Pedenko_UnitTest_Homework
{
    public class StringReplaceTest
    {
        [Theory]
        [InlineData("One Two Three Four Five", ' ', '<', "One<Two<Three<Four<Five")]
        [InlineData("S0me c0de 0123402", '0', 'O', "SOme cOde O1234O2")]
        public void ArgsCharAndChar_IfValidParameters_WorkCorrect(string input, char oldChar, char newChar, string expectedResult)
        {
            string result = input.Replace(oldChar, newChar);
            Assert.Equal(result, expectedResult);
        }

        [Theory]
        [InlineData("Veni, vidi, vici",",", " ->", "Veni -> vidi -> vici")]
        [InlineData("Veni, vidi, vici", "Veni", "Veni", "Veni, vidi, vici")]
        [InlineData("Veni, vidi, vici", ", vidi", "", "Veni, vici")]
        [InlineData("Veni, vidi, vici", ", vidi", null, "Veni, vici")]
        [InlineData("Dot Dash dot", "dot", "Dash", "Dot Dash Dash")]
        [InlineData("Dot Dash dot", "dot", "Dash", "Dash Dash Dash", true)]
        [InlineData("ABabBAba", "ab", "AB", "ABABBABa", true)]
        public void ArgsStringAndStringAndIgnoreCase_IfValidParameters_WorkCorrect(string input, string oldValue, string newValue, string expectedResult, bool ignoreCase = false)
        {
            string result = input.Replace(oldValue, newValue, ignoreCase, null);
            Assert.Equal(result, expectedResult);
        }//don't want to test with different cultures

        [Theory]
        [InlineData("Test _ String", "st", "tS", StringComparison.CurrentCulture, "TetS _ String")]
        [InlineData("Test _ String", "st", "tS", StringComparison.CurrentCultureIgnoreCase, "TetS _ tSring")]
        [InlineData("Test _ String", "st", "tS", StringComparison.Ordinal, "TetS _ String")]
        [InlineData("Test _ String", "st", "tS", StringComparison.OrdinalIgnoreCase, "TetS _ tSring")]
        public void ArgsStringsAndStringAndComparsion_IfValidParameters_WorkCorrect(string input, string oldValue, string newValue, StringComparison comparsionType, string expectedResult)
        {
            string result = input.Replace(oldValue, newValue, comparsionType);
            Assert.Equal(result, expectedResult);
        }

        [Fact]
        public void IfOldValueIsNull_ThrowArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => "Hello world".Replace(null, "null"));
        }

        [Fact]
        public void IfOldValueIsEmptyString_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "Hello world".Replace("", "Empty"));
        }
    }
}
