using System;

namespace src.stringMatching
{
    internal class LD
    {
        /// <summary>
        /// Levenshtein Distance Algorithm
        /// </summary>
        /// <param name="s1">string 1</param>
        /// <param name="s2">string 2</param>
        /// <returns>levenshtein distance</returns>
        public static int LevenshteinDistance(string s1, string s2)
        {
            int lenS1 = s1.Length;
            int lenS2 = s2.Length;

            // Dynamic Programming matrix to keep track of the cost needed to 
            // match both string to each other
            int[,] dp = new int[lenS1 + 1, lenS2 + 1];

            for (int i = 0; i <= lenS1; i++)
            {
                for (int j = 0; j <= lenS2; j++)
                {
                    if (i == 0)
                    {
                        dp[i, j] = j;
                    }
                    else if (j == 0)
                    {
                        dp[i, j] = i;
                    }
                    else if (s1[i - 1] == s2[j - 1])
                    {
                        dp[i, j] = dp[i - 1, j - 1];
                    }
                    else
                    {
                        dp[i, j] = 1 + Math.Min(dp[i - 1, j], Math.Min(dp[i, j - 1], dp[i - 1, j - 1]));
                    }
                }
            }

            return dp[lenS1, lenS2];
        }

        // Function to find the best match for the pattern in the long string
        /// <summary>
        /// Find the best match of pattern using sliding window
        /// </summary>
        /// <param name="pattern">string pattern</param>
        /// <param name="longString">base string</param>
        /// <returns>A pair value<br></br>- best index to do matching<br></br>- levenshetein distance</returns>
        public int FindBestMatch(string pattern, string longString)
        {
            int patternLength = pattern.Length;
            int minDistance = int.MaxValue;

            for (int i = 0; i <= longString.Length - patternLength; i++)
            {
                string window = longString.Substring(i, patternLength);
                int distance = LevenshteinDistance(pattern, window);
                if (distance < minDistance)
                {
                    minDistance = distance;
                }
            }

            return minDistance;
        }
    }
}
