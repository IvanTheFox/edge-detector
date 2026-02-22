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
        public class ConvolutionError : Exception
        {
            public ConvolutionError()
                : base("There was a mismatch between inner and outer matrix sizes for the provided arrays")
            { }
            public ConvolutionError(string message)
                : base(message)
            { }
        }
        
        public static Bitmap GetEdgeMap(Bitmap image, double[,] xOperator, double[,] yOperator)
        {
            (int[,], int[,], int[,]) result = SplitByChannels(image);
            double[,] red = Int2DArrayToDouble(result.Item1);
            double[,] green = Int2DArrayToDouble(result.Item2);
            double[,] blue = Int2DArrayToDouble(result.Item3);

            double[,] redX = Convolute(red, xOperator);
            double[,] redY = Convolute(red, yOperator);

            double[,] greenX = Convolute(green, xOperator);
            double[,] greenY = Convolute(green, yOperator);

            double[,] blueX = Convolute(blue, xOperator);
            double[,] blueY = Convolute(blue, yOperator);

            int mapWidth = redX.GetLength(0);
            int mapHeight = redX.GetLength(0);
            double[,] dx = new double[mapWidth, mapHeight];
            double[,] dy = new double[mapWidth, mapHeight];

            AddArray(dx, redX);
            AddArray(dx, greenX);
            AddArray(dx, blueX);

            AddArray(dy, redX);
            AddArray(dy, greenX);
            AddArray(dy, blueX);

            double[,] magnitude = new double[mapWidth, mapHeight];
            for (int x = 0; x < mapWidth; x++)
                for (int y = 0; y < mapHeight; y++)
                    magnitude[x, y] = Math.Pow(dx[x, y] * dx[x, y] + dy[x, y] * dy[x, y], 0.5);

            double maxDerivative = GetMaxDerivative(3);

        }
        public static (int[,], int[,], int[,]) SplitByChannels(Bitmap image)
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

        public static double[,] Convolute(double[,] outer, double[,] inner)
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

            for (int x = 0; x <= maxX; x++)
                for (int y = 0; y <= maxY; y++)
                    for (int x2 = 0; x2 < innerWidth; x2++)
                        for (int y2 = 0; y2 < innerHeight; y2++)
                            result[x, y] += outer[x + x2, y + y2] * inner[x, y];

            return result;
        }

        public static double[,] Int2DArrayToDouble(int[,] array)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);

            double[,] result = new double[width, height];
            for (int x = 0; x <  width; x++)
                for (int y = 0; y < height; y++)
                    result[x, y] = array[x, y];

            return result;
        }

        public static void AddArray(double[,] target, double[,] array)
        {
            int width = target.GetLength(0);
            int height = target.GetLength(1);
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    target[x, y] += array[x, y];
        }

        public static double GetMaxDerivative(int channelCount)
        {
            return 255 * channelCount;
        }
    }
}
