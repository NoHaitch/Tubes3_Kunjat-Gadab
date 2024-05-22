using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class ImageProcessing
    {
        /// <summary>
        /// Threshold of when a pixel is a valley(binary 0) or a ridge(binary 1)
        /// </summary>
        private const int threshold = 100;

        /// <summary>
        /// Get a binary part of an image used as the target for string matching
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>String of Binary 1 or 0</returns>
        public static string getImageBinaryPart(string imgPath)
        {
            // Load image
            Bitmap grayscaleImage = new Bitmap(imgPath);

            // Get the width and height of the image
            int width = grayscaleImage.Width;
            int height = grayscaleImage.Height;

            // Get the center of the image
            int centerX = width / 2;
            int centerY = height / 2;

            // Extract 35 pixels around the center
            // Amount of pixel must be a multiplication of 7
            // This is because 8-bit ascii efficiently only uses 7 bit 

            // a list of boolean is used as the representation of a binary string
            // true = 1, false = 0
            List<bool> binaryPixels = new List<bool>();
            int pixel_taken = 35;

            // If the img is to small, get max of multiplication of 7 
            if(width * height < pixel_taken)
            {
                // Get the highest multiplication of 7
                while(width * height < pixel_taken)
                {
                    pixel_taken -= 7;
                }

                // If pixel_taken is 0 or negatif
                while(pixel_taken <= 0)
                {
                    pixel_taken += 7;
                }
            }

            // Define the radius around the center to extract pixels from
            int radius = (int) Math.Ceiling(Math.Sqrt(pixel_taken));

            // Get the pixel from the center of the image going out
            for (int y = centerY - radius; y <= centerY + radius && binaryPixels.Count < pixel_taken; y++)
            {
                for (int x = centerX - radius; x <= centerX + radius && binaryPixels.Count < pixel_taken; x++)
                {
                    if (x >= 0 && x < width && y >= 0 && y < height)
                    {
                        Color pixelColor = grayscaleImage.GetPixel(x, y);
                        int pixelValue = pixelColor.R;
                        bool isRidge = pixelValue < threshold;
                        binaryPixels.Add(isRidge);
                    }
                }
            }

            // Ensure we have exactly have the same amount of pixels
            while (binaryPixels.Count < pixel_taken)
            {
                binaryPixels.Add(false); 
            }

            // Build the binary string
            StringBuilder binaryStringBuilder = new StringBuilder();
            foreach (bool binaryPixel in binaryPixels)
            {
                binaryStringBuilder.Append(binaryPixel ? '1' : '0');
            }

            // Return the binary string
            return binaryStringBuilder.ToString();
        }


        /// <summary>
        /// Convert a full image into a binary string with the same length as the total pixel in image
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>String of Binary 1 or 0</returns>
        public static string convertImageToBinary(string imgPath)
        {
            // Load image
            Bitmap image = new Bitmap(imgPath);

            // Get the width and height of the image
            int width = image.Width;
            int height = image.Height;

            // Create a StringBuilder to hold the binary representation
            StringBuilder binaryStringBuilder = new StringBuilder();

            // convert every pixel in image into a binary string
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);
                    int pixelValue = pixelColor.R;
                    bool isRidge = pixelValue < threshold;
                    binaryStringBuilder.Append(isRidge ? '1' : '0');
                }
            }

            // Return the binary string
            return binaryStringBuilder.ToString();
        }

        /// <summary>
        /// Convert a Binary String to 8-bit Ascii <br></br>
        /// Every 7 bit is converted to an Ascii character <br></br>
        /// 8-bit Ascii only have 7-bit thats is significant, 1 bit is not used
        /// </summary>
        /// <param name="binaryString">String of Binary 1 or 0</param>
        /// <returns>String of Ascii characters</returns>
        public static string convertBinaryToAscii(string binaryString)
        {
            StringBuilder asciiStringBuilder = new StringBuilder();

            // Iterate over the binary string in groups of 7 bits
            for (int i = 0; i < binaryString.Length; i += 7)
            {
                // Get a 7 bit binary group
                string binaryGroup = binaryString.Substring(i, Math.Min(7, binaryString.Length - i));

                // Convert the binary group to an 
                int asciiValue = Convert.ToInt32(binaryGroup, 2);

                // Convert the integer ASCII value to a character
                char asciiChar = Convert.ToChar(asciiValue);

                // Append the ASCII character to the result string
                asciiStringBuilder.Append(asciiChar);
            }

            // Return the ASCII string
            return asciiStringBuilder.ToString();
        }
    }
}
