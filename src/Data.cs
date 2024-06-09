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

        /*
        public static Dictionary<string, string> ReadImages(string folderPath)
        {
            Dictionary<string, string> asciiMap = new Dictionary<string, string>();

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                throw new Exception("Folder does not exist.");
            }
            else
            {
                Console.WriteLine($"{folderPath}");
            }

            // Get all BMP files in the folder
            string[] bmpFiles = Directory.GetFiles(folderPath, "*.bmp");

            if(bmpFiles.Length == 0)
            {
                throw new Exception("No Bitmap Image Found");
            }

            foreach (string bmpFile in bmpFiles)
            {
                // Get the image name without the full path
                string imageName = Path.GetFileName(bmpFile);

                // Convert BMP file to ASCII string
                string asciiString = ImageProcessing.ConvertImageToAscii(bmpFile);
                asciiMap.Add(imageName, asciiString);
            }

            return asciiMap;
        }
        */

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
                Console.WriteLine($"{folderPath} exist");
            }

            // Get all BMP files in the folder
            /*string[] bmpFiles = Directory.GetFiles(folderPath, "*.bmp");
            foreach (String b in bmpFiles) {
                Console.WriteLine(b);
            }*/
            List<String> bmpFiles = Database.SelectAllFingerprintImages();
            int fileCount = bmpFiles.Count();
            for ( int j = 0; j < fileCount; j++ )
            {
                bmpFiles[j] = Path.Combine(folderPath, bmpFiles[j].Trim());
                Console.WriteLine(bmpFiles[j]);
            }
            if (fileCount == 0)
            {
                throw new Exception("No Bitmap Image Found");
            }

            Task[] allTasks = new Task[fileCount-1];

            for (int i=0; i<fileCount-1; i++) 
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

            /*
            foreach (string bmpFile in bmpFiles)
            {
                // Get the image name without the full path
                string imageName = Path.GetFileName(bmpFile);

                // Convert BMP file to ASCII string
                string asciiString = ImageProcessing.ConvertImageToAscii(bmpFile);
                asciiMap.Add(imageName, asciiString);
            }
            */
        }
    }
}
