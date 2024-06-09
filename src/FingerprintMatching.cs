using System;
using System.Collections.Generic;
using src.stringMatching;
using src.image;
using System.Linq;
using MySqlX.XDevAPI.Common;

namespace src
{
    /// <summary>
    /// Class to compare the ASCII pattern of a target image with a set of images
    /// Uses KMP and BM algorithms to find the number of matching patterns
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
        public static (string, float) FingerprintAnalysisBM(string targetPath, Dictionary<string, string> asciiMap)
        {
            // Initialize result
            string result = null;

            // Initialize match percentage
            float matchPercent = 100;

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

            // For each image
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
                result = FindClosestImage(targetPath, asciiMap, out matchPercent);
            }
            else if (successfulMatches.Count == 1)
            {
                result = successfulMatches[0];
                Console.WriteLine($"Succesfull Pattern Match: {maxMatches}");
            }
            else
            {
                // Use Levenshtein distance for tie-breaking
                result = FindClosestImageByLevenshtein(successfulMatches, asciiMap, targetPath, out matchPercent);
            }

            // Check the match percentage threshold
            if (matchPercent < 73)
            {
                result = null;
            }

            return (result, matchPercent);
        }

        /// <summary>
        /// Compare the ASCII pattern of a target image with a set of images using KMP algorithm
        /// </summary>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <returns>Image name with the most matching patterns</returns>
        public static (string, float) FingerprintAnalysisKMP(string targetPath, Dictionary<string, string> asciiMap)
        {
            // Initialize result
            string result = null;

            // Initialize match percentage
            float matchPercent = 100;

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

            // For each image
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
                result = FindClosestImage(targetPath, asciiMap, out matchPercent);
            }
            else if (successfulMatches.Count == 1)
            {
                result = successfulMatches[0];
                Console.WriteLine($"Succesfull Pattern Match: {maxMatches}");
            }
            else
            {
                // Use Levenshtein distance for tie-breaking
                result = FindClosestImageByLevenshtein(successfulMatches, asciiMap, targetPath, out matchPercent);
            }

            // Check the match percentage threshold
            if (matchPercent < 73)
            {
                result = null;
            }

            return (result, matchPercent);
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
        /// Calculate the weight of a pattern based on its position
        /// The closer the pattern is to the center, the higher the weight
        /// </summary>
        /// <param name="patternIndex">Index of the pattern</param>
        /// <returns>Weight of the pattern</returns>
        private static int CalculateWeight(int patternIndex)
        {
            switch (patternIndex)
            {
                case 1: // fallthrough
                case 4: // fallthrough
                case 13: // fallthrough
                case 16:
                    return 1; // Smallest weight for outermost patterns
                case 2: // fallthrough
                case 3: // fallthrough
                case 5: // fallthrough
                case 8: // fallthrough
                case 9: // fallthrough
                case 12: // fallthrough
                case 14: // fallthrough
                case 15:
                    return 2; // Intermediate weight for next outer layer
                case 6: // fallthrough
                case 7: // fallthrough
                case 10: // fallthrough
                case 11:
                    return 3; // Higher weight for next inner layer
                default:
                    return 4; // Highest weight for the center pattern
            }
        }

        /// <summary>
        /// Find the closest image based on Levenshtein distance
        /// </summary>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <param name="matchPercent">Output match percentage</param>
        /// <returns>Closest image name</returns>
        private static string FindClosestImage(string targetPath, Dictionary<string, string> asciiMap, out float matchPercent)
        {
            // Initialize the minimum distance and the closest image
            float maxMatchPercent = 0;
            string closestImage = null;
            string[] targetPattern = ImageProcessing.GetAsciiPattern(targetPath);

            foreach (var entry in asciiMap)
            {
                float currentMatchPercent = LD.FindBestMatch(entry.Value, targetPattern[0]);
                if (currentMatchPercent > maxMatchPercent)
                {
                    maxMatchPercent = currentMatchPercent;
                    closestImage = entry.Key;
                }
            }
            
            matchPercent = maxMatchPercent;
            return closestImage;
        }

        /// <summary>
        /// Find the closest image based on Levenshtein distance for a list of images
        /// </summary>
        /// <param name="successfulMatches">List of image names with the most matching patterns</param>
        /// <param name="asciiMap">Dictionary of image name and its ASCII pattern</param>
        /// <param name="targetPath">Path to target image</param>
        /// <param name="matchPercent">Output match percentage</param>
        /// <returns>Closest image name</returns>
        private static string FindClosestImageByLevenshtein(List<string> successfulMatches, Dictionary<string, string> asciiMap, string targetPath, out float matchPercent)
        {
            // Initialize the maximum match percentage
            float maxMatchPercent = 0;

            // List to store images with the same Levenshtein match percentage
            List<string> closestImages = new List<string>();

            // Get the ASCII patterns of the target image
            string[] targetPatterns = ImageProcessing.GetAsciiPattern(targetPath);

            foreach (var imageName in successfulMatches)
            {
                string imageAscii = asciiMap[imageName];

                // Initialize cumulative match percentage
                float cumulativeMatchPercent = 0;

                // Calculate the cumulative match percentage using all patterns
                foreach (var targetPattern in targetPatterns)
                {
                    float currentMatchPercent = LD.FindBestMatch(imageAscii, targetPattern);
                    cumulativeMatchPercent += currentMatchPercent;
                }

                // Calculate average match percentage
                float averageMatchPercent = cumulativeMatchPercent / targetPatterns.Length;

                // Check if the current match percentage is greater than the maximum
                if (averageMatchPercent > maxMatchPercent)
                {
                    // Update the maximum match percentage
                    maxMatchPercent = averageMatchPercent;

                    // Clear the list and add the current image
                    closestImages.Clear();
                    closestImages.Add(imageName);
                }
                else if (averageMatchPercent == maxMatchPercent)
                {
                    // Add the image to the list with the same match percentage
                    closestImages.Add(imageName);
                }
            }

            // Print the count of images with the same Levenshtein match percentage
            Console.WriteLine($"Images with the same Levenshtein match percentage: {closestImages.Count}");

            matchPercent = maxMatchPercent;
            return closestImages[0];
        }
    }
}
