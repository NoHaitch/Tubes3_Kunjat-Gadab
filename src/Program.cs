﻿using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using src;
using src.database;
using src.gui;
using src.image;

class Program
{
    [STAThread]
    static void Main()
    {
        Console.WriteLine("\n==================== Program Started ====================\n");
        Database.Connect();
        Console.WriteLine("Connected to databases");
        //Database.ImportSQL(@"..\..\database\insert.sql");
        string folderPath = @"..\..\..\test";

        Stopwatch stopwatch0 = Stopwatch.StartNew();
        Data.ReadImagesConcurrent(folderPath);
        ConcurrentDictionary<string, string> asciiMapConcurrent = Data.getAsciiMap();
        Dictionary<string, string> asciiMap = new Dictionary<string, string>(asciiMapConcurrent);
        Console.WriteLine($"Number of ASCII converted images: {asciiMap.Count}");
        Console.WriteLine($"Time Taken to convert Source images: {stopwatch0.ElapsedMilliseconds} ms.");
        stopwatch0.Stop();

        Application.EnableVisualStyles();
        Application.Run(new Form1(asciiMap));
    }
}