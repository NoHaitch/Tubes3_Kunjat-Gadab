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

        string easyTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\SOCOFing\\Altered\\Altered-Easy\\592__M_Right_ring_finger_Zcut.BMP";
        string mediumTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\SOCOFing\\Altered\\Altered-Medium\\592__M_Right_ring_finger_Zcut.BMP";
        string hardTargetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\SOCOFing\\Altered\\Altered-Hard\\592__M_Right_ring_finger_Zcut.BMP";

        Stopwatch stopwatch0 = Stopwatch.StartNew();
        Data.ReadImagesConcurrent(folderPath);
        ConcurrentDictionary<string, string> asciiMapConcurrent = Data.getAsciiMap();
        Dictionary<string, string> asciiMap = new Dictionary<string, string>(asciiMapConcurrent);
   
        Stopwatch stopwatch1 = Stopwatch.StartNew();
        (string resultEasy1, float matchPercentageEasy1) = FingerprintMatching.FingerprintAnalysisBM(easyTargetPath, asciiMap);
        stopwatch1.Stop();

        Stopwatch stopwatch2 = Stopwatch.StartNew();
        (string resultEasy2, float matchPercentageEasy2) = FingerprintMatching.FingerprintAnalysisKMP(easyTargetPath, asciiMap);
        stopwatch2.Stop();

        (string resultMedium1, float matchPercentageMedium1) = FingerprintMatching.FingerprintAnalysisBM(mediumTargetPath, asciiMap);
        (string resultMedium2, float matchPercentageMedium2) = FingerprintMatching.FingerprintAnalysisKMP(mediumTargetPath, asciiMap);

        (string resultHard1, float matchPercentageHard1) = FingerprintMatching.FingerprintAnalysisBM(hardTargetPath, asciiMap);
        (string resultHard2, float matchPercentageHard2) = FingerprintMatching.FingerprintAnalysisKMP(hardTargetPath, asciiMap);

        Console.WriteLine($"Pattern Image: {easyTargetPath}");
        Console.WriteLine($"Source: {folderPath}");
        Console.WriteLine($"Time Taken to convert Source images: {stopwatch0.ElapsedMilliseconds} ms.");
        Console.WriteLine("Resulting Match: \n");

/*        Console.WriteLine($"\nFingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Result Easy BM: {resultEasy1}\n");
        Console.WriteLine($"Match Percentage: {matchPercentageEasy1}");

        Console.WriteLine($"\nFingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"Result Easy KMP: {resultEasy2}\n");
        Console.WriteLine($"Match Percentage: {matchPercentageEasy2}");*/

        Console.WriteLine($"Result Easy BM: {resultEasy1}");
        Console.WriteLine($"Match Percentage: {matchPercentageEasy1} \n");
        Console.WriteLine($"Result Easy KMP: {resultEasy2}");
        Console.WriteLine($"Match Percentage: {matchPercentageEasy2} \n");

        Console.WriteLine($"Result Medium BM: {resultMedium1}");
        Console.WriteLine($"Match Percentage: {matchPercentageMedium1} \n");
        Console.WriteLine($"Result Medium KMP: {resultMedium2}");
        Console.WriteLine($"Match Percentage: {matchPercentageMedium2} \n");

        Console.WriteLine($"Result Hard BM: {resultHard1}");
        Console.WriteLine($"Match Percentage: {matchPercentageHard1}\n");
        Console.WriteLine($"Result Hard KMP: {resultHard2}");
        Console.WriteLine($"Match Percentage: {matchPercentageHard2}\n");

    }
}
