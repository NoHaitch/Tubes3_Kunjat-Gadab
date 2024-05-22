using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace src
{
    internal class ImageConverter
    {
        static void main(string[] args)
        {
            // Replace "image.bmp" with the path to your BMP image file
            string imagePath = "test.BMP";

            // Load the image
            Bitmap bmp = new Bitmap(imagePath);

            // Access image data
            int width = bmp.Width;
            int height = bmp.Height;

            // Example: Access pixel at position (x=100, y=50)
            Color pixelColor = bmp.GetPixel(100, 50);
            int red = pixelColor.R;
            int green = pixelColor.G;
            int blue = pixelColor.B;

            // Example: Iterate through all pixels and print their color
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    Color pixel = bmp.GetPixel(x, y);
                    Console.WriteLine($"Pixel at ({x}, {y}): R={pixel.R}, G={pixel.G}, B={pixel.B}");
                }
            }

            // Dispose the bitmap when done
            bmp.Dispose();
        }
    }
}
