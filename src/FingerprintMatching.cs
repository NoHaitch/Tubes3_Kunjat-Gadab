using System;
using System.Collections.Generic;

using src.stringMatching;
using src.image;

namespace src
{
    /// <summary>
    /// Class to compare the ASCII pattern of a target image with a set of images\n
    /// Uses KMP and BM algorithms to find the number of matching patterns\n
    /// Uses Levenshtein Distance to find the closest image if no pattern matches
    /// </summary>
    internal class FingerprintMatching
    {

        /// <summary>
        /// Compare the ASCII pattern of a target image with a set of images using BM algorithm
        /// </summary>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <returns>Image name with the most matching patterns</returns>
        public static string FingerprintAnalysisBM(string targetPath, Dictionary<string, string> asciiMap)
        {
            // Initialize result
            string result = null;

            // Get the ASCII pattern of the target image
            string[] patterns = ImageProcessing.GetAsciiPattern(targetPath);

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }

            // Store the maximum number of matches
            int maxMatches = 0;

            // Store the list of images with the same number of matches as the maximum
            List<string> successfulMatches = new List<string>();

            // for each image
            foreach (var entry in asciiMap)
            {
                // Count the number of matching patterns
                int matches = CountMatchingPatternsBM(entry.Value, patterns);

                // Update the maximum number of matches
                if (matches > maxMatches)
                {
                    maxMatches = matches;
                    successfulMatches.Clear();
                    successfulMatches.Add(entry.Key);
                }
                else if (matches == maxMatches)
                {
                    successfulMatches.Add(entry.Key);
                }
            }

            // No pattern matches
            if (maxMatches == 0)
            {
                // TODO: Implement tie-breaking mechanism
                result = "TODO:TIE BREAKER";
            }
            else if(successfulMatches.Count == 1)
            {
                result = successfulMatches[0];
            }
            else
            {
                // TODO: Implement tie-breaking mechanism
                result = "TODO:TIE BREAKER";
            }

            return result;
        }

        /// <summary>
        /// Compare the ASCII pattern of a target image with a set of images using KMP algorithm
        /// </summary>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <returns>Image name with the most matching patterns</returns>
        public static string FingerprintAnalysisKMP(string targetPath, Dictionary<string, string> asciiMap)
        {
            // Initialize result
            string result = null;

            // Get the ASCII pattern of the target image
            string[] patterns = ImageProcessing.GetAsciiPattern(targetPath);

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }

            // Store the maximum number of matches
            int maxMatches = 0;

            // Store the list of images with the same number of matches as the maximum
            List<string> successfulMatches = new List<string>();

            // for each image
            foreach (var entry in asciiMap)
            {
                // Count the number of matching patterns
                int matches = CountMatchingPatternsKMP(entry.Value, patterns);

                // Update the maximum number of matches
                if (matches > maxMatches)
                {
                    maxMatches = matches;
                    successfulMatches.Clear();
                    successfulMatches.Add(entry.Key);
                }
                else if (matches == maxMatches)
                {
                    successfulMatches.Add(entry.Key);
                }
            }

            // No pattern matches
            if (maxMatches == 0)
            {
                //TODO: Implement tie-breaking mechanism
                result = "TODO:TIE BREAKER";
            }
            else if (successfulMatches.Count == 1)
            {
                result = successfulMatches[0];
            }
            else
            {
                //TODO: Implement tie-breaking mechanism
                result = "TODO:TIE BREAKER";
            }

            return result;
        }

        /// <summary>
        /// Count the number of matching patterns between an image and a set of patterns using BM algorithm
        /// </summary>
        /// <param name="imageAscii">ASCII pattern of the image</param>
        /// <param name="patterns">Array of ASCII patterns</param>
        /// <returns>Number of matching patterns</returns>
        private static int CountMatchingPatternsBM(string imageAscii, string[] patterns)
        {
            int matches = 0;
            for (int i = 0; i < patterns.Length; i++)
            {
                if (BM.BMStringMatching(imageAscii, patterns[i]))
                {
                    matches += CalculateWeight(i + 1);
                }
            }
            return matches;
        }

        /// <summary>
        /// Count the number of matching patterns between an image and a set of patterns using KMP algorithm
        /// </summary>
        /// <param name="imageAscii">ASCII pattern of the image</param>
        /// <param name="patterns">Array of ASCII patterns</param>
        /// <returns>Number of matching patterns</returns>
        private static int CountMatchingPatternsKMP(string imageAscii, string[] patterns)
        {
            int matches = 0;
            for (int i = 0; i < patterns.Length; i++)
            {
                if (KMP.KMPStringMatching(imageAscii, patterns[i]))
                {
                    matches += CalculateWeight(i + 1);
                }
            }
            return matches;
        }

        /// <summary>
        /// Calculate the weight of a pattern based on its position\n
        /// The closer the pattern is to the center, the higher the weight
        /// </summary>
        /// <param name="patternIndex">Index of the pattern</param>
        /// <returns>Weight of the pattern</returns>
        private static int CalculateWeight(int patternIndex)
        {
            switch (patternIndex)
            {
                case 1: // fallthrough
                case 3: // fallthrough
                case 7: // fallthrough
                case 9:
                    return 1; // Smallest weight for outer patterns
                case 5:
                    return 3; // Largest weight for central pattern
                default:
                    return 2; // Intermediate weight for other patterns
            }
        }

        /// <summary>
        /// TODO: Implement tie-breaking mechanism
        /// Find the image with the closest ASCII pattern to the target image
        /// </summary>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="successfulMatches">List of images with the same number of matches</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <returns>Image name with the closest ASCII pattern</returns>
        private static string FindClosestImage(string targetPath, List<string> successfulMatches, Dictionary<string, string> asciiMap)
        {
            // Initialize the minimum distance and the closest image
            int minDistance = int.MaxValue;
            string closestImage = null;

            foreach (var imageName in successfulMatches)
            {
                int distance = LD.LevenshteinDistance(asciiMap[imageName], ImageProcessing.GetAsciiPattern(targetPath)[0]);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    closestImage = imageName;
                }
            }

            return closestImage;
        }
    }
}
