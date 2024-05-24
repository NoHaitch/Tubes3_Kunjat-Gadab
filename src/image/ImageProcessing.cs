using System;
using System.Drawing;
using System.Linq;
using System.Text;

namespace src.image
{
    /// <summary>
    /// Proses Image into Binary and Ascii
    /// </summary>
    internal class ImageProcessing
    {
        /// <summary>
        /// Threshold of when a pixel is a valley(binary 0) or a ridge(binary 1)
        /// </summary>
        private const int Threshold = 100;

        /// <summary>
        /// Get a 6-character ASCII pattern from the center box of the image.
        /// </summary>
        /// <param name="imgPath">Path to image.</param>
        /// <returns>6-character ASCII pattern.</returns>
        public static string GetAsciiPattern(string imgPath)
        {
            // Convert the image to binary
            string binaryString = ConvertImageToBinary(imgPath);

            // Calculate the center box position
            int centerIndex = binaryString.Length / 2 - 21; // 21 is half of 7 * 3

            // Extract 42 bits from the center box
            string asciiPattern = binaryString.Substring(centerIndex, 42);

            Console.WriteLine(asciiPattern);

            // Convert the binary pattern to ASCII
            return ConvertBinaryToAscii(asciiPattern);
        }

        /// <summary>
        /// Convert a full image into a binary string with the same length as the total pixel in image
        /// </summary>
        /// <param name="imgPath">path to image</param>
        /// <returns>String of Binary 1 or 0</returns>
        public static string ConvertImageToBinary(string imgPath)
        {
            Bitmap image = new Bitmap(imgPath);
            int width = image.Width;
            int height = image.Height;
            StringBuilder binaryStringBuilder = new StringBuilder();

            // Determine the number of full boxes needed in width and height
            int numFullBoxesX = width / 7;
            int numFullBoxesY = height / 2;

            // Determine the width and height of the last partial box
            int lastBoxWidth = width % 7;
            int lastBoxHeight = height % 2;

            // Group pixels into full boxes of size 7x2
            for (int y = 0; y < numFullBoxesY * 2; y += 2)
            {
                for (int x = 0; x < numFullBoxesX * 7; x += 7)
                {
                    AppendBoxBinary(image, x, y, 7, 2, binaryStringBuilder);
                }
            }

            // Handle the last partial box
            if (lastBoxWidth > 0 || lastBoxHeight > 0)
            {
                int lastBoxX = numFullBoxesX * 7;
                int lastBoxY = numFullBoxesY * 2;
                AppendBoxBinary(image, lastBoxX, lastBoxY, lastBoxWidth, lastBoxHeight, binaryStringBuilder);
            }

            return binaryStringBuilder.ToString();
        }

        private static void AppendBoxBinary(Bitmap image, int x, int y, int boxWidth, int boxHeight, StringBuilder binaryStringBuilder)
        {
            // Iterate over rows in the box
            for (int j = 0; j < boxHeight; j++)
            {
                StringBuilder rowStringBuilder = new StringBuilder();

                // Iterate over columns in the box
                for (int i = 0; i < boxWidth; i++)
                {
                    // Check if the pixel coordinate is within the image boundaries
                    if (x + i < image.Width && y + j < image.Height)
                    {
                        // Get pixel color value
                        Color pixelColor = image.GetPixel(x + i, y + j);
                        int pixelValue = pixelColor.R;
                        // Append '1' if pixel is a ridge, '0' otherwise
                        rowStringBuilder.Append(pixelValue < Threshold ? '1' : '0');
                    }
                    else
                    {
                        // Append '0' if the pixel is outside the image boundaries
                        rowStringBuilder.Append('0');
                    }
                }

                // Append the row's binary string to the full binary string
                binaryStringBuilder.AppendLine(rowStringBuilder.ToString());
            }
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
