using System;

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

            // Preprocess the pattern to get the border function array
            int[] borderFunction = ComputeBorderFunction(pattern);

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
                    return true;
                }
                else if (i < sourceSize && pattern[j] != source[i])
                {
                    if (j != 0)
                    {
                        j = borderFunction[j - 1];
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
        /// Computes the border function array for the pattern
        /// </summary>
        /// <param name="pattern">The pattern string</param>
        /// <returns>The border function array</returns>
        private static int[] ComputeBorderFunction(string pattern)
        {
            // Length of the previous longest prefix suffix
            int length = 0;

            int i = 1;
            int patternSize = pattern.Length;
            int[] borderFunction = new int[patternSize];
            borderFunction[0] = 0;

            while (i < patternSize)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    borderFunction[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = borderFunction[length - 1];
                    }
                    else
                    {
                        borderFunction[i] = 0;
                        i++;
                    }
                }
            }

            return borderFunction;
        }
    }
}
