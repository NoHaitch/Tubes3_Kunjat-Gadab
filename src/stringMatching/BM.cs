using System;
using System.Collections.Generic;

namespace src.stringMatching
{
    internal class BM
    {
        /// <summary>
        /// Boyer Moore Algorithm using character jump
        /// </summary>
        /// <param name="source">A full image ascii string</param>
        /// <param name="pattern">String pattern that will be searched</param>
        /// <returns>True if the pattern exists in the source, otherwise false</returns>
        public static bool BMStringMatching(string source, string pattern)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(pattern))
            {
                Console.WriteLine("NULL");
                return false;
            }

            int sourceSize = source.Length;
            int patternSize = pattern.Length;

            // Get last occurrence map
            Dictionary<char, int> lastOccurrence = LastOccurrenceBuilder(pattern);

            int mainIndex = 0;

            while (mainIndex <= (sourceSize - patternSize))
            {
                // Looking glass Technique
                // Start the check from the end of the pattern
                int patternIndex = patternSize - 1;

                // Check from right to left if the pattern matches the text
                while (patternIndex >= 0 && pattern[patternIndex] == source[mainIndex + patternIndex])
                    patternIndex--;

                // If the pattern is found
                if (patternIndex < 0)
                {
                    // Pattern found, return true
                    return true;
                }
                else
                {
                    // Character Jump Technique
                    // Move the pattern according to the last occurrence map and rule
                    int charShift;
                    if (lastOccurrence.TryGetValue(source[mainIndex + patternIndex], out int shift))
                    {
                        charShift = Math.Max(1, patternIndex - shift);
                    }
                    else
                    {
                        charShift = patternIndex + 1;
                    }
                    mainIndex += charShift;
                }
            }

            // Pattern not found, return false
            return false;
        }

        /// <summary>
        /// Preprocess the pattern to create the a map of the last occurrence function
        /// </summary>
        /// <param name="pattern">Ascii String Pattern</param>
        private static Dictionary<char, int> LastOccurrenceBuilder(string pattern)
        {
            int size = pattern.Length;
            Dictionary<char, int> lastOccurrence = new Dictionary<char, int>();

            for (int i = 0; i < size; i++)
            {
                // Map each character to its last position in the pattern
                lastOccurrence[pattern[i]] = i;
            }

            return lastOccurrence;
        }
    }
}
