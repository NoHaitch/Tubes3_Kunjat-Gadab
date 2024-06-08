using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using src;
using src.database;
using src.gui;

class Program
{
    [STAThread]
    static void Main()
    {
        Console.WriteLine("\n==================== Program Started ====================\n");
        Database.Connect();
        Console.WriteLine("Connected to databases");

        string folderPath = @"..\..\..\test\SOCOFing\Real";
        /*
        string easyTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Easy\\431__M_Left_little_finger_CR.BMP";
        string mediumTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Medium\\431__M_Left_little_finger_CR.BMP";
        string hardTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Hard\\431__M_Left_little_finger_CR.BMP";
        */

        Stopwatch stopwatch0 = Stopwatch.StartNew();
        Data.ReadImagesConcurrent(folderPath);
        ConcurrentDictionary<string, string> asciiMapConcurrent = Data.getAsciiMap();
        Dictionary<string, string> asciiMap = new Dictionary<string, string>(asciiMapConcurrent);
        Console.WriteLine($"Number of ASCII converted images: {asciiMap.Count}");
        Console.WriteLine($"Time Taken to convert Source images: {stopwatch0.ElapsedMilliseconds} ms.");
        stopwatch0.Stop();

        /*
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
        Console.WriteLine("Resulting Match: \n");

        Console.WriteLine($"\nFingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Result Easy BM: {resultEasy1}\n");

        Console.WriteLine($"\nFingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Result Easy KMP: {resultEasy2}\n");

        Console.WriteLine($"Result Medium BM: {resultMedium1}\n");
        Console.WriteLine($"Result Medium KMP: {resultMedium2}\n");

        Console.WriteLine($"Result Hard BM: {resultHard1}\n");
        Console.WriteLine($"Result Hard KMP: {resultHard2}\n");
        */
    }
}
