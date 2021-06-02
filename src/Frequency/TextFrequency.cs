using System;
using System.Collections.Generic;

namespace Frequency
{
    /// <summary>
    /// Represents a text frequency map. Only counts numbers and letters.
    /// </summary>
    public class TextFrequency
    {
        /// <summary>
        /// Gets the character map as read only.
        /// </summary>
        /// <value>The read only character map.</value>
        public IReadOnlyDictionary<char, int> CharacterMap { get { return (IReadOnlyDictionary<char, int>)_charmap; } }

        /// <summary>
        /// Gets the total number of characters.
        /// </summary>
        /// <value>The character count.</value>
        public int CharacterCount { get; private set; } = 0;

        /// <summary>
        /// Gets or sets the character map.
        /// </summary>
        /// <value>The character map.</value>
        private IDictionary<char, int> _charmap { get; set; } = new Dictionary<char, int>();

        /// <summary>
        /// Constructs a new instance of <see cref="TextFrequency"/>.
        /// </summary>
        public TextFrequency() { }

        /// <summary>
        /// Constructs a new instance of <see cref="TextFrequency"/>.
        /// </summary>
        /// <param name="str">The string to populate the map.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="str"/> is <see langword="null"/>.</exception>
        public TextFrequency(string str)
        {
            AddString(str);
        }

        /// <summary>
        /// Adds another character into the frequency map.
        /// </summary>
        /// <param name="c">The character to add.</param>
        public void AddChar(char c)
        {
            _charmap[c]++;
            CharacterCount++;
        }

        /// <summary>
        /// Adds another string into the frequency map.
        /// </summary>
        /// <param name="str">The string to add.</param>
        /// <exception cref="ArgumentNullException">Thrown when <paramref name="str"/> is <see langword="null"/>.</exception>
        public void AddString(string str)
        {
            if (str is null)
                throw new ArgumentNullException(nameof(str));

            foreach (var c in str)
            {
                if (char.IsNumber(c) || char.IsLetter(c))
                {
                    _charmap[c] = _charmap.ContainsKey(c) ? _charmap[c] + 1 : 1;
                    CharacterCount++;
                }
            }
        }

        /// <summary>
        /// Computes the average appearance of the specified character.
        /// </summary>
        /// <param name="c">The character to compute.</param>
        /// <param name="total">The total number of characters.</param>
        /// <returns>The average appearance of <paramref name="c"/> in the map.</returns>
        public double Average(char c, int total)
        {
            return _charmap.ContainsKey(c) && total > 0 ? _charmap[c] / (double)total : 0.0;
        }
    }
}
