using System;
using System.Collections.Generic;
using System.Text;

namespace Algs
{
    public static class Strings
    {
        /// <summary>
        /// String comparison.
        /// </summary>
        /// <param name="str1">The STR1.</param>
        /// <param name="str2">The STR2.</param>
        /// <returns></returns>
        public static bool EqualsNoLib(string? str1, string? str2)
        {
            if (str1 == null && str2 == null) return true;
            if (str1 == null || str2 == null) return false;
            if (str1.Length != str2.Length) return false;

            for (int i = 0; i <= str1.Length - 1; i++)
            {
                if (str1[i] != str2[i]) return false;
            }

            return true;
        }

        /// <summary>
        /// Gets the character frequency.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <returns></returns>
        public static Dictionary<char, int> GetCharacterFrequency(this string? str)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));

            Dictionary<char, int> counts = new Dictionary<char, int>();
            for (char letter = 'a'; letter <= 'z'; letter++)
            {
                counts.Add(letter, 0);
            }

            foreach (char c in str.ToLower().Where(char.IsLetter))
            {
                counts[c]++;
            }

            return counts;
        }
    }
}
