using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.IO;
using System.Threading.Tasks;
using src.database;
using src.image;
using System.Drawing;
using System.Linq;

namespace src
{
    internal class Data
    {

        private static ConcurrentDictionary<string, string> asciiMap;

        public static ConcurrentDictionary<string, string> getAsciiMap() { return asciiMap; }


        /* CONCURRENT */
        public static void ReadImagesConcurrent(string folderPath)
        {
            asciiMap = new ConcurrentDictionary<string, string>();

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Folder does not exist.");
            }
            else
            {
                // Console.WriteLine($"{folderPath} exist");
            }

            List<String> bmpFiles = Database.SelectAllFingerprintImages();
            int fileCount = bmpFiles.Count();
            for ( int j = 0; j < fileCount; j++ )
            {
                bmpFiles[j] = Path.Combine(folderPath, bmpFiles[j].Trim());
                // Console.WriteLine(bmpFiles[j]);
            }
            if (fileCount == 0)
            {
                throw new Exception("No Bitmap Image Found");
            }

            Task[] allTasks = new Task[fileCount];

            for (int i=0; i<fileCount; i++) 
            {
                int num = i;
                allTasks[i] = Task.Run(() => ImageProcessing.ConvertImageToAscii(bmpFiles[num], asciiMap));
            }
            try
            {
                Task.WhenAll(allTasks).Wait();
            }
            catch (AggregateException ex)
            {
                foreach (var e in ex.InnerExceptions)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }
    }
}
