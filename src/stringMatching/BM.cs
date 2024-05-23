using System;
using System.Collections.Generic;

namespace src.stringMatching
{
    internal class BM
    {
        /// <summary>
        /// Boyer Moore Algorithm
        /// </summary>
        /// <param name="source">A full image ascii string</param>
        /// <param name="pattern">String pattern that will be searched</param>
        /// <returns></returns>
        public static int BMStringMatching(string source, string pattern)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(pattern))
            {
                Console.WriteLine("NULL");
                return 0;
            }

            int n = source.Length;
            int m = pattern.Length;
            int count = 0;

            Dictionary<char, int> badCharShift = BuildBadCharacterShift(pattern);

            int s = 0;
            while (s <= (n - m))
            {
                int j = m - 1;

                // Check from right to left if the pattern matches the text
                while (j >= 0 && pattern[j] == source[s + j])
                    j--;

                // If the pattern is found
                if (j < 0)
                {
                    count++;
                    // Move the pattern to align with the next character in the text
                    int shift;
                    if (s + m < n && badCharShift.TryGetValue(source[s + m], out shift))
                    {
                        s += m - shift;
                    }
                    else
                    {
                        s += 1;
                    }
                }
                else
                {
                    // Move the pattern according to the bad character rule
                    int shift;
                    if (badCharShift.TryGetValue(source[s + j], out shift))
                    {
                        s += Math.Max(1, j - shift);
                    }
                    else
                    {
                        s += Math.Max(1, j - m);
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// Preprocess the pattern to create the bad character shift dictionary
        /// </summary>
        /// <param name="pattern">Ascii String Pattern</param>
        private static Dictionary<char, int> BuildBadCharacterShift(string pattern)
        {
            int m = pattern.Length;
            Dictionary<char, int> badCharShift = new Dictionary<char, int>();

            for (int i = 0; i < m - 1; i++)
            {
                // calculate bad match shift
                badCharShift[pattern[i]] = m - 1 - i;
            }

            return badCharShift;
        }
    }
}
