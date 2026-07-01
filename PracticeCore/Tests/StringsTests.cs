using FluentAssertions;

namespace Algs.Tests
{
    public class StringsTests
    {
        [Test]
        [TestCase(null, null)]
        [TestCase("string", null)]
        [TestCase("string", "")]
        [TestCase("string", "string")]
        [TestCase("string2", "strrrr")]
        [TestCase("string2", "string1")]
        public void EqualsNoLib_ShouldCorrectlyCompareStringsForEquality(string? str1, string? str2)
        {
            // Arrange


            // Act
            var result = Strings.EqualsNoLib(str1, str2);

            // Assert
            result.Should().Be(str1 == str2);
        }

        [Test]
        public void GetCharacterFrequency_ShouldCorrectlyCount()
        {
            // Arrange
            var str = "This is an exquisite string";
            var expected = new Dictionary<char, int>
            {
                {'a',1},{'b',0},{'c',0},{'d',0},{'e',2},{'f',0},{'g',1},{'h',1},{'i',5},{'j',0},{'k',0},{'l',0},{'m',0},{'n',2},{'o',0},{'p',0},{'q',1},{'r',1},{'s',4},{'t',3},{'u',1},{'v',0},{'w',0},{'x',1},{'y',0},{'z',0}
            };

            // Act
            var actual = str.GetCharacterFrequency();

            // Assert
            actual.Should().BeEquivalentTo(expected);
        }
    }
}
