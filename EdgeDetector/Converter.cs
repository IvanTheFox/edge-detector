using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    internal class Converter
    {
        const int channelSize = 255;

        public class ConvolutionError : Exception
        {
            public ConvolutionError()
                : base("There was a mismatch between inner and outer matrix sizes for the provided arrays")
            { }
            public ConvolutionError(string message)
                : base(message)
            { }
        }
        
        public static Bitmap GetEdgeMap(Bitmap image, Operator op)
        {            
            (int[,], int[,], int[,]) result = SplitByChannels(image);
            double[,] red = Int2DArrayToDouble(result.Item1);
            double[,] green = Int2DArrayToDouble(result.Item2);
            double[,] blue = Int2DArrayToDouble(result.Item3);

            double[,] redX = Convolve(red, op.X);
            double[,] redY = Convolve(red, op.Y);

            double[,] greenX = Convolve(green, op.X);
            double[,] greenY = Convolve(green, op.Y);

            double[,] blueX = Convolve(blue, op.X);
            double[,] blueY = Convolve(blue, op.Y);

            int mapWidth = redX.GetLength(0);
            int mapHeight = redX.GetLength(1);

            double[,] dx = new double[mapWidth, mapHeight];
            double[,] dy = new double[mapWidth, mapHeight];
            double[,] magnitude = new double[mapWidth, mapHeight];

            for (int x =  0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    dx[x, y] = Math.Abs(redX[x, y]) + Math.Abs(greenX[x, y]) + Math.Abs(blueX[x, y]);
                    dy[x, y] = Math.Abs(redY[x, y]) + Math.Abs(greenY[x, y]) + Math.Abs(blueY[x, y]);
                    magnitude[x, y] = Math.Sqrt(dx[x, y] * dx[x, y] + dy[x, y] * dy[x, y]);
                }
            }

            double maxValue = 0;
            for (int x = 0; x < mapWidth; x++)
                for (int y = mapHeight; y < mapHeight; y++)
                    if (maxValue < magnitude[x, y])
                        maxValue = magnitude[x, y];
            Bitmap edgeMap = Double2DArrayToBitmap(magnitude);

            return edgeMap;
        }

        public static void ApplyThresholding(Bitmap bitmap, int threshold)
        {
            int mapWidth = bitmap.Width;
            int mapHeight = bitmap.Height;

            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    if (bitmap.GetPixel(x, y).R > threshold)
                        bitmap.SetPixel(x, y, Color.White);
                    else
                        bitmap.SetPixel(x, y, Color.Black);
                }
            }
        }

        private static (int[,], int[,], int[,]) SplitByChannels(Bitmap image)
        {
            int width = image.Width;
            int height = image.Height;

            int[,] red = new int[width, height];
            int[,] green = new int[width, height];
            int[,] blue = new int[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = image.GetPixel(x, y);
                    red[x, y] = pixel.R;
                    green[x, y] = pixel.G;
                    blue[x, y] = pixel.B;
                }
            }

            return (red, green, blue);
        }

        private static double[,] Convolve(double[,] outer, double[,] inner)
        {
            int outerWidth = outer.GetLength(0);
            int outerHeight = outer.GetLength(1);
            int innerWidth = inner.GetLength(0);
            int innerHeight = inner.GetLength(1);
            if (outerWidth < innerWidth || outerHeight < innerHeight)
                throw new ConvolutionError();
            
            int maxX = outerWidth - innerWidth;
            int maxY = outerHeight - innerHeight;
            double[,] result = new double[maxX + 1, maxY + 1];

            for (int x = 0; x < maxX; x++)
                for (int y = 0; y < maxY; y++)
                {
                    for (int x2 = 0; x2 < innerWidth; x2++)
                        for (int y2 = 0; y2 < innerHeight; y2++)
                            result[x, y] += outer[x + x2, y + y2] * inner[x2, y2];
                    result[x, y] /= innerWidth;
                }

            return result;
        }

        private static double[,] Int2DArrayToDouble(int[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            double[,] result = new double[width, height];
            for (int x = 0; x <  width; x++)
                for (int y = 0; y < height; y++)
                    result[x, y] = array[x, y];

            return result;
        }

        private static Bitmap Double2DArrayToBitmap(double[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            double maxMagnitude = GetMaxMagnitude(3);
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    bitmap.SetPixel(x, y, Color.FromArgb(
                        (int)(array[x, y] / maxMagnitude * channelSize),
                        (int)(array[x, y] / maxMagnitude * channelSize),
                        (int)(array[x, y] / maxMagnitude * channelSize)
                    ));

            return bitmap;
        }

        private static double GetMaxMagnitude(int channels)
        {
            return Math.Sqrt(2 * channels * channels * channelSize * channelSize);
        }
    }
}
