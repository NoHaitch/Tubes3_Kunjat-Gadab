using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class Data
    {            
        public List<String> readImages(string folderPath) 
        {
            List<string> asciiList = new List<string>();

            // Check if the folder exists
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine("Folder does not exist.");
                return asciiList;
            }
            else
            {
                Console.WriteLine($"{folderPath}");
            }

            // Get all BMP files in the folder
            string[] bmpFiles = Directory.GetFiles(folderPath, "*.bmp");
            foreach (string bmpFile in bmpFiles)
            {
                // Convert BMP file to ASCII string
                string asciiString = ImageProcessing.convertImageToAscii(bmpFile);
                asciiList.Add(asciiString);
              
            }

            return asciiList;
        }
        
    }
}
