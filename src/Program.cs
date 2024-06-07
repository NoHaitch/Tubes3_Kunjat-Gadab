using System;
using System.Diagnostics;
using System.Windows.Forms;

using src;
using src.database;
using src.gui;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n==================== Program Started ====================\n");
        Database.connect();
        Console.WriteLine("Connected to databases");
        Application.EnableVisualStyles();
        Application.Run(new Form1());
        
        /*
        Console.WriteLine("Resulting Match: \n");
        string folderPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Medium";
        string targetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Easy\\100__M_Left_index_finger_CR.BMP";

        Stopwatch stopwatch1 = Stopwatch.StartNew();
        string result1 = FingerprintMatching.FingerprintAnalysisBM(targetPath, folderPath);
        stopwatch1.Stop();

        Stopwatch stopwatch2 = Stopwatch.StartNew();
        string result2 = FingerprintMatching.FingerprintAnalysisKMP(targetPath, folderPath);
        stopwatch2.Stop();


        Console.WriteLine($"\nFingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisBM took {stopwatch1.ElapsedMilliseconds / 1000} s.");
        Console.WriteLine($"Result BM: {result1}\n");

        Console.WriteLine($"\nFingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysisKMP took {stopwatch2.ElapsedMilliseconds / 1000} s.");
        Console.WriteLine($"Result KMP: {result2}\n");
        */
    }
}
