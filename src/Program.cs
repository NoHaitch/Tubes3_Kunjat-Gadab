using src;
using src.stringMatching;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using src;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n==================== Program Started ====================\n");
        string folderPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Real";
        string easyTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Easy\\50__M_Left_index_finger_Obl.BMP";
        string mediumTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Medium\\50__M_Left_index_finger_Obl.BMP";
        string hardTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Hard\\50__M_Left_index_finger_Obl.BMP";

        // get ascii of all images

        Stopwatch stopwatch0 = Stopwatch.StartNew();
        Dictionary<string, string> asciiMap = Data.ReadImages(folderPath);
        stopwatch0.Stop();

        Stopwatch stopwatch1 = Stopwatch.StartNew();
        string resultEasy1 = FingerprintMatching.FingerprintAnalysisBM(easyTargetPath, asciiMap);
        stopwatch1.Stop();

        Stopwatch stopwatch2 = Stopwatch.StartNew();
        string resultEasy2 = FingerprintMatching.FingerprintAnalysisKMP(easyTargetPath, asciiMap);
        stopwatch2.Stop();

        string resultMedium1 = FingerprintMatching.FingerprintAnalysisBM(mediumTargetPath, asciiMap);
        string resultMedium2 = FingerprintMatching.FingerprintAnalysisKMP(mediumTargetPath, asciiMap);

        string resultHard1 = FingerprintMatching.FingerprintAnalysisBM(hardTargetPath, asciiMap);
        string resultHard2 = FingerprintMatching.FingerprintAnalysisKMP(hardTargetPath, asciiMap);

        Console.WriteLine($"Pattern Image: {easyTargetPath}");
        Console.WriteLine($"Source: {folderPath}");
        Console.WriteLine($"Time Taken to convert Source images: {stopwatch0.ElapsedMilliseconds} ms.");
        Console.WriteLine("Resulting Match: \n");

        /*Console.WriteLine($"\nFingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");*/
        Console.WriteLine($"Result Easy BM: {resultEasy1}\n");

        /*Console.WriteLine($"\nFingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");*/
        Console.WriteLine($"Result Easy KMP: {resultEasy2}\n");
        
        Console.WriteLine($"Result Medium BM: {resultMedium1}\n");
        Console.WriteLine($"Result Medium KMP: {resultMedium2}\n");
        
        Console.WriteLine($"Result Hard BM: {resultHard1}\n");
        Console.WriteLine($"Result Hard KMP: {resultHard2}\n");
    }
}
