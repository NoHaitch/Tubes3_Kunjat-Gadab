using src;
using src.stringMatching;
using System;
using System.Collections.Generic;
using System.Diagnostics;

class Program
{
    static void Main()
    {
        Console.WriteLine("\n==================== Program Started ====================\n");
        Console.WriteLine("Resulting Match: \n");
        string folderPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Hard";
        string targetPath = "D:\\Git_Repository\\Tubes3_Kunjat-Gadab\\test\\archive\\SOCOFing\\Altered\\Altered-Easy\\1__M_Left_index_finger_CR.BMP";

        Stopwatch stopwatch = Stopwatch.StartNew();
        string result = FingerprintMatching.FingerprintAnalysis(targetPath, folderPath);
        stopwatch.Stop();

        Console.WriteLine($"\nFingerprintAnalysis took {stopwatch.ElapsedMilliseconds} ms.");
        Console.WriteLine($"FingerprintAnalysis took {stopwatch.ElapsedMilliseconds / 1000} s.\n");

        Console.WriteLine("comparison:");
        Console.WriteLine(ImageProcessing.ConvertImageToAscii(folderPath + "\\"+ result));
        Console.WriteLine("Pattern: >>>'" + ImageProcessing.GetImageAsciiPart(targetPath) + "'<<<");
    }
}
