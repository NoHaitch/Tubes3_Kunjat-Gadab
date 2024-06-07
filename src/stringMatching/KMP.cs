using System;

using src.image;
using src.stringMatching;

namespace src.stringMatching
{
    internal class KMP
    {
        /// <summary>
        /// Knuth-Morris-Pratt (KMP) Algorithm for string matching
        /// </summary>
        /// <param name="source">The source string in which the pattern is to be searched</param>
        /// <param name="pattern">The pattern string to be searched in the source</param>
        /// <returns>True if the pattern exists in the source, otherwise false</returns>
        public static bool KMPStringMatching(string source, string pattern)
        {
            if (string.IsNullOrEmpty(source) || string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            int sourceSize = source.Length;
            int patternSize = pattern.Length;

            // Preprocess the pattern to get the lps array
            int[] lps = ComputeLPSArray(pattern);

            int i = 0; // Index for source
            int j = 0; // Index for pattern

            while (i < sourceSize)
            {
                if (pattern[j] == source[i])
                {
                    i++;
                    j++;
                }

                if (j == patternSize)
                {
                    // Pattern found at index i - j
                    return true;
                }
                else if (i < sourceSize && pattern[j] != source[i])
                {
                    // Mismatch after j matches
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Computes the longest prefix which is also suffix (lps) array for the pattern
        /// </summary>
        /// <param name="pattern">The pattern string</param>
        /// <returns>The lps array</returns>
        private static int[] ComputeLPSArray(string pattern)
        {
            int length = 0; // Length of the previous longest prefix suffix
            int i = 1;
            int patternSize = pattern.Length;
            int[] lps = new int[patternSize];
            lps[0] = 0; // lps[0] is always 0

            while (i < patternSize)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = 0;
                        i++;
                    }
                }
            }

            return lps;
        }
    }
}