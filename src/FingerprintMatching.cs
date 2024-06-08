using src.stringMatching;
using System;
using System.Collections.Generic;


namespace src
{
    internal class FingerprintMatching
    {
        public static string FingerprintAnalysisBM(string targetPath, Dictionary<string, string> asciiMap)
        {
            // result list
            string result = null;

            // image pattern
            string pattern = ImageProcessing.GetAsciiPattern(targetPath);

            

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }

            // Boyer Moore algorithm
            // string matching every image to try to find a match
            foreach (var entry in  asciiMap)
            {
                if(BM.BMStringMatching(entry.Value, pattern))
                {
                    result = entry.Key;
                    break;
                }
                
            }

            // if no image has exact match use Levenshtein Distance
            if (result is null)
            {
                int minDistance = int.MaxValue;
                string closestImage = null;

                foreach (var entry in asciiMap)
                {
                    int distance = LD.LevenshteinDistance(entry.Value, pattern);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestImage = entry.Key;
                    }
                }

                result = closestImage;
            }

            return result;
        }

        public static string FingerprintAnalysisKMP(string targetPath, Dictionary<string, string> asciiMap)
        {
            // result list
            string result = null;

            // image pattern
            string pattern = ImageProcessing.GetAsciiPattern(targetPath);

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }

            // Boyer Moore algorithm
            // string matching every image to try to find a match
            foreach (var entry in asciiMap)
            {
                if(KMP.KMPStringMatching(entry.Value, pattern))
                {
                    result = entry.Key;
                    break;
                }
            }

            // if no image has exact match use Levenshtein Distance
            if (result is null)
            {
                int minDistance = int.MaxValue;
                string closestImage = null;

                foreach (var entry in asciiMap)
                {
                    int distance = LD.LevenshteinDistance(entry.Value, pattern);
                    if (distance < minDistance)
                    {
                        minDistance = distance;
                        closestImage = entry.Key;
                    } else if(distance == minDistance)
                    {
                        Console.WriteLine($"found similar minDistance: {minDistance} - {entry.Key}");
                    }
                }

                result = closestImage;
            }

            return result;
        }
    }
}
