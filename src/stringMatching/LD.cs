using System;

namespace src.stringMatching
{
    internal class LD
    {
        /// <summary>
        /// Levenshtein Distance Algorithm with optimized space complexity
        /// </summary>
        /// <param name="s1">string 1</param>
        /// <param name="s2">string 2</param>
        /// <returns>levenshtein distance</returns>
        public static int LevenshteinDistance(string s1, string s2)
        {
            int lenS1 = s1.Length;
            int lenS2 = s2.Length;

            if (lenS1 == 0) return lenS2;
            if (lenS2 == 0) return lenS1;

            int[] previousRow = new int[lenS2 + 1];
            int[] currentRow = new int[lenS2 + 1];

            for (int j = 0; j <= lenS2; j++)
            {
                previousRow[j] = j;
            }

            for (int i = 1; i <= lenS1; i++)
            {
                currentRow[0] = i;

                for (int j = 1; j <= lenS2; j++)
                {
                    int cost = (s1[i - 1] == s2[j - 1]) ? 0 : 1;
                    currentRow[j] = Math.Min(Math.Min(currentRow[j - 1] + 1, previousRow[j] + 1), previousRow[j - 1] + cost);
                }

                // Swap rows
                var temp = previousRow;
                previousRow = currentRow;
                currentRow = temp;
            }

            return previousRow[lenS2];
        }

        /// <summary>
        /// Find the best match of pattern using sliding window
        /// </summary>
        /// <param name="imageAscii">base string</param>
        /// <param name="pattern">string pattern</param>
        /// <returns>match percentage</returns>
        public static float FindBestMatch(string imageAscii, string pattern)
        {
            int patternLength = pattern.Length;
            int minDistance = int.MaxValue;

            for (int i = 0; i <= imageAscii.Length - patternLength; i++)
            {
                int distance = LevenshteinDistance(pattern, imageAscii.Substring(i, patternLength));
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            // Calculate match percentage
            float matchPercentage = (1.0f - ((float)minDistance / patternLength)) * 100;
            return matchPercentage;
        }
    }
}
