using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace Pedenko_UnitTest_Homework
{
    public class StringSplitTest //https://source.dot.net/#q=string.split / split has 10 overloads, and all of them are divided into 4 types depending on the separator
    {
        public static IEnumerable<object[]> StringSplitArgsChars_Data =>    //char and char[]? use the same SplitInternal function
        new List<object[]>
        {
            new object[] { "", new char[] {' '}, new string[] { "" } },
            new object[] { " ", new char[] {' '}, new string[] {"",""} },
            new object[] { "Hello World", new char[] {' '}, new string[] {"Hello","World"} },
            new object[] { "Hello World", new char[] { ' ', 'l' }, new string[] { "He","","o","Wor","d" } },
            new object[] { "Hello World", new char[] { ' ', 'l' }, new string[] { "He", "", "o World"}, 3 },
            new object[] { "Hello World", new char[] { ' ', 'l' }, new string[] { "He", "o", "World" }, 3, StringSplitOptions.RemoveEmptyEntries },
        };

        [Theory]
        [MemberData(nameof(StringSplitArgsChars_Data))]
        public void ArgsChars_IfValidParameters_WorkCorrect(string input, char[] separator, string[] expectedResult, int count = Int32.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            string[] result = input.Split(separator, count, options);
            Assert.True(Enumerable.SequenceEqual(result, expectedResult));
        }

        [Fact]
        public void ArgsChars_IfCountLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abcd".Split(new char[] { 'b' }, -1));
        }

        [Fact]
        public void ArgsChars_IfOptionsNotInStringSplitOptionsValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "abcd".Split(new char[] { 'b' }, options: (StringSplitOptions)100));
        }


        public static IEnumerable<object[]> StringSplitArgsString_Data =>
        new List<object[]>
        {
            new object[] { "", "", new string[] { "" } },
            new object[] { "abcd", "", new string[] { "abcd" } },
            new object[] { "abcd", null, new string[] { "abcd" } },
            new object[] { " ", " ", new string[] {"",""} },
            new object[] { "Hello World", "l", new string[] { "He", "", "o Wor", "d" } },
            new object[] { "Hello World", "l", new string[] { "He", "", "o World" }, 3 },
            new object[] { "Hello World", "l", new string[] { "He", "o Wor", "d" }, 3, StringSplitOptions.RemoveEmptyEntries },
        };

        [Theory]
        [MemberData(nameof(StringSplitArgsString_Data))]
        public void ArgsString_IfValidParameters_WorkCorrect(string input, string separator, string[] expectedResult, int count = Int32.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            string[] result = input.Split(separator, count, options);
            Assert.True(Enumerable.SequenceEqual(result, expectedResult));
        }

        [Fact]
        public void ArgsString_IfCountLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abcd".Split("b", -1));
        }

        [Fact]
        public void ArgsString_IfOptionsNotInStringSplitOptionsValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "abcd".Split("b", options: (StringSplitOptions)100));
        }


        public static IEnumerable<object[]> StringSplitArgsArrOfString_Data =>
        new List<object[]>
        {
            new object[] { "", new string[] {""}, new string[] { "" } },
            new object[] { "abcd", new string[] {""}, new string[] { "abcd" } },
            new object[] { "abcd", null, new string[] { "abcd" } },
            new object[] { " ", new string[] {" "}, new string[] {"",""} },
            new object[] { "Hello World", new string[] {" "}, new string[] {"Hello","World"} },
            new object[] { "Hello World", new string[] { " ", "l" }, new string[] { "He","","o","Wor","d" } },
            new object[] { "Hello World", new string[] { " ", "l" }, new string[] { "He", "", "o World"}, 3 },
            new object[] { "Hello World", new string[] { " ", "l" }, new string[] { "He", "o", "World" }, 3, StringSplitOptions.RemoveEmptyEntries },
        };

        [Theory]
        [MemberData(nameof(StringSplitArgsArrOfString_Data))]
        public void ArgsArrOfString_IfValidParameters_WorkCorrect(string input, string[] separator, string[] expectedResult, int count = Int32.MaxValue, StringSplitOptions options = StringSplitOptions.None)
        {
            string[] result = input.Split(separator, count, options);
            Assert.True(Enumerable.SequenceEqual(result, expectedResult));
        }

        [Fact]
        public void ArgsArrOfString_CountLessThanZero_ThrowArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => "abcd".Split(new string[] { "b" }, -1, StringSplitOptions.None));
        }

        [Fact]
        public void ArgsArrOfString_IfOptionsNotInStringSplitOptionsValues_ThrowArgumentException()
        {
            Assert.Throws<ArgumentException>(() => "abcd".Split(new string[] { "b" }, 1, (StringSplitOptions)100));
        }
    } 
}
