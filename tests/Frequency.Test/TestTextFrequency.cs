using Xunit;

namespace Frequency.Test
{
    /// <summary>
    /// Tests <see cref="TextFrequency"/>.
    /// </summary>
    public class TestTextFrequency
    {
        /// <summary>
        /// Tests <see cref="TextFrequency.CharacterCount"/>.
        /// </summary>
        [Fact]
        public void TestCharacterCount()
        {
            Assert.Equal(3, new TextFrequency("abc").CharacterCount);
            Assert.Equal(4, new TextFrequency("a b c d").CharacterCount);
            Assert.Equal(0, new TextFrequency("+ - * /").CharacterCount);
            Assert.Equal(0, new TextFrequency("").CharacterCount);
        }

        /// <summary>
        /// Tests <see cref="TextFrequency.Average(char, int)"/>.
        /// </summary>
        [Fact]
        public void TestAverage()
        {
            Assert.Equal(0.0, new TextFrequency("   ").Average('a', 3));
            Assert.Equal(0.25, new TextFrequency("a   ").Average('a', 4));
        }

        /// <summary>
        /// Tests <see cref="TextFrequency.AddString(string)"/>.
        /// </summary>
        [Fact]
        public void TestAddString()
        {
            var freq = new TextFrequency("a");
            freq.AddString("aa");
            Assert.Equal(3, freq.CharacterMap['a']);
            freq.AddString("  ");
            Assert.Equal(3, freq.CharacterMap['a']);
            freq.AddString("  b  ");
            Assert.Equal(1, freq.CharacterMap['b']);
            freq.AddString("c * d + e - a");
            Assert.Equal(5, freq.CharacterMap.Count);
            Assert.Equal(8, freq.CharacterCount);
        }
    }
}
