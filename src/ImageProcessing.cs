using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace src
{
    /// <summary>
    /// Proses Image into Binary and Ascii
    /// </summary>
    internal class ImageProcessing
    {
        /// <summary>
        /// Threshold of when a pixel is a valley(binary 0) or a ridge(binary 1)
        /// </summary>
        private const int threshold = 100;

        /// <summary>
        /// Get a ascii part of an image used as the target for string matching
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>8-bit ascii</returns>
        public static string GetImageAsciiPart(string imgPath)
        {
            string imgAscii = ConvertImageToAscii(imgPath);

            // Find the center of the binary string
            int centerIndex = imgAscii.Length / 2;

            // Calculate the start index to extract 5 characters around the center
            int startIndex = Math.Max(0, centerIndex - 2);

            // Ensure we don't go beyond the string length
            int length = Math.Min(10, imgAscii.Length - startIndex);

            // Extract 5 characters from the center
            string asciiPart = imgAscii.Substring(startIndex, length);

            return asciiPart;
        }

        /// <summary>
        /// Convert a full image into a binary string with the same length as the total pixel in image
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>String of Binary 1 or 0</returns>
        public static string ConvertImageToBinary(string imgPath)
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
        public static string ConvertBinaryToAscii(string binaryString)
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
    
        /// <summary>
        /// Convert image to 8bit ascii string
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>ascii string</returns>
        public static string ConvertImageToAscii(string imgPath)
        {
            string binary = ConvertImageToBinary(imgPath);
            return ConvertBinaryToAscii(binary);
        }
    }
}
