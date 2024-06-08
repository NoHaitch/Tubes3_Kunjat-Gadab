using System;
using System.Collections.Generic;
using System.IO;

namespace src
{
    internal class Data
    {
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

            int limiter = 0;
            foreach (string bmpFile in bmpFiles)
            {
                // Get the image name without the full path
                string imageName = Path.GetFileName(bmpFile);

                // Convert BMP file to ASCII string
                string asciiString = ImageProcessing.ConvertImageToAscii(bmpFile);
                asciiMap.Add(imageName, asciiString);
                limiter++;

            }

            return asciiMap;
        }
    }
}
