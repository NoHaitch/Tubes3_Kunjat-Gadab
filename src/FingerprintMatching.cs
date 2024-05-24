using src.stringMatching;
using System;
using System.Collections.Generic;


namespace src
{
    internal class FingerprintMatching
    {
        public static string FingerprintAnalysisBM(string targetPath, string datasetPath)
        {
            // result list
            string result = null;

            // image pattern
            string pattern = ImageProcessing.GetImageAsciiPart(targetPath);

            // get ascii of all images
            Dictionary<string, string> asciiMap = Data.ReadImages(datasetPath);

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }
            else
            {
                Console.WriteLine("Total Data: " + asciiMap.Count);
            }


            Console.WriteLine("Using Boyer Moore");

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
                Console.WriteLine("Using levenshteinDistance");

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
                Console.WriteLine("Distance: " + minDistance + "\n");
            }

            // print result
            Console.WriteLine("Solution Found: " + result);

            return result;
        }

        public static string FingerprintAnalysisKMP(string targetPath, string datasetPath)
        {
            // result list
            string result = null;

            // image pattern
            string pattern = ImageProcessing.GetImageAsciiPart(targetPath);

            // get ascii of all images
            Dictionary<string, string> asciiMap = Data.ReadImages(datasetPath);

            if (asciiMap.Count == 0)
            {
                throw new Exception("No Image Found");
            }
            else
            {
                Console.WriteLine("Total Data: " + asciiMap.Count);
            }


            Console.WriteLine("Using Knut");

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
                Console.WriteLine("Using levenshteinDistance");

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
                Console.WriteLine("Distance: " + minDistance + "\n");
            }

            // print result
            Console.WriteLine("Solution Found: " + result);

            return result;
        }
    }
}
