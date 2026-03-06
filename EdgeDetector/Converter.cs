using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EdgeDetector
{
    internal class Converter
    {
        const int channelSize = 255;
        
        public static Bitmap ApplyKernel2d(Bitmap image, Kernel2d krnl, int? threshold = null)
        {
            var result = SplitByChannels(image);

            double[,] red = TransformMatrix<int, double>(result.Item1, (x, y, value) => (double)value);
            double[,] redX = Convolve(red, krnl.X);
            double[,] redY = Convolve(red, krnl.Y);

            double[,] green = TransformMatrix<int, double>(result.Item2, (x, y, value) => (double)value);
            double[,] greenX = Convolve(green, krnl.X);
            double[,] greenY = Convolve(green, krnl.Y);

            double[,] blue = TransformMatrix<int, double>(result.Item3, (x, y, value) => (double)value);
            double[,] blueX = Convolve(blue, krnl.X);
            double[,] blueY = Convolve(blue, krnl.Y);

            double[,] magnitude = new double[redX.GetLength(0), redX.GetLength(1)];
            ApplyToMatrix<double>(magnitude, (x, y, value) =>
            {
                double dx = Math.Abs(redX[x, y]) + Math.Abs(greenX[x, y]) + Math.Abs(blueX[x, y]);
                double dy = Math.Abs(redY[x, y]) + Math.Abs(greenY[x, y]) + Math.Abs(blueY[x, y]);
                return Math.Sqrt(dx * dx + dy * dy);
            });

            Bitmap edgeMap = MatrixToBitmap(magnitude, 0, GetMaxMagnitude(3, krnl));
            if (threshold.HasValue)
                ApplyThresholding(edgeMap, threshold.Value);

            return edgeMap;
        }

        public static Bitmap ApplyKernel(Bitmap image, Kernel krnl)
        {
            var result = SplitByChannels(image);

            double[,] red = TransformMatrix<int, double>(result.Item1, (x, y, value) => (double)value);
            red = Convolve(red, krnl.X);

            double[,] green = TransformMatrix<int, double>(result.Item2, (x, y, value) => (double)value);
            green = Convolve(green, krnl.X);

            double[,] blue = TransformMatrix<int, double>(result.Item3, (x, y, value) => (double)value);
            blue = Convolve(blue, krnl.X);

            double[,] d2 = new double[red.GetLength(0), red.GetLength(1)];
            ApplyToMatrix<double>(d2, (x, y, value) => red[x, y] + green[x, y] + blue[x, y]);

            var interval = GetValueInterval(3, krnl);
            Bitmap edgeMap = MatrixToBitmap(d2, interval.Item1, interval.Item2);

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

        private static double[,] Convolve(double[,] m1, double[,] m2)
        {
            int width1 = m1.GetLength(0);
            int height1 = m1.GetLength(1);
            int width2 = m2.GetLength(0);
            int height2 = m2.GetLength(1);

            int m1xMax = width1 + width2 - 1;
            int m1yMax = height1 + height2 - 1;

            double[,] result = new double[m1xMax, m1yMax];

            for (int m1y = 0; m1y < m1yMax; m1y++)
            {
                for (int m1x = 0; m1x < m1xMax; m1x++)
                {
                    int m2xMax = width2 - Math.Max(0, m1x - width1 + 1);
                    int m2yMax = height2 - Math.Max(0, m1y - height1 + 1);
                    for (int m2y = -Math.Min(0, m1y - height2 + 1); m2y < m2yMax; m2y++)
                    {
                        for (int m2x = -Math.Min(0, m1x - width2 + 1); m2x < m2xMax; m2x++)
                        {
                            result[m1x, m1y] += m1[m1x - width2 + 1 + m2x, m1y - height2 + 1 + m2y] * m2[m2x, m2y];
                        }
                    }
                }
            }

            return result;
        }

        private static void ApplyToMatrix<T>(T[,] matrix, Func<int, int, T, T> operation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    matrix[x, y] = operation(x, y, matrix[x, y]);
        }

        private static T2[,] TransformMatrix<T1, T2>(T1[,] matrix, Func<int, int, T1, T2> operation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            T2[,] newMatrix = new T2[width, height];

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    newMatrix[x, y] = operation(x, y, matrix[x, y]);

            return newMatrix;
        }

        private static void IterateOverMatrix<T>(T[,] matrix, Action<int, int, T> operation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    operation(x, y, matrix[x, y]);
        }

        private static Bitmap MatrixToBitmap(double[,] array, double minValue, double maxValue)
        {
            int width = array.GetLength(0);
            int height = array.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            double diff = maxValue - minValue;
            for (int x = 0; x < width; x++)
                for (int y = 0; y < height; y++)
                    bitmap.SetPixel(x, y, Color.FromArgb(
                        (int)((array[x, y] - minValue) / diff * channelSize),
                        (int)((array[x, y] - minValue) / diff * channelSize),
                        (int)((array[x, y] - minValue) / diff * channelSize)
                    ));

            return bitmap;
        }

        private static double GetMaxMagnitude(int channels, Kernel2d krnl)
        {
            double posXAmpl = 0, negXAmpl = 0, posYAmpl = 0, negYAmpl = 0;
            IterateOverMatrix<double>(krnl.X, (x, y, value) =>
            {
                if (value > 0)
                    posXAmpl += value;
                else
                    negXAmpl += value;
            });
            IterateOverMatrix<double>(krnl.Y, (x, y, value) =>
            {
                if (value > 0)
                    posYAmpl += value;
                else
                    negYAmpl += value;
            });

            double maxDerivative = channelSize * Math.Max(Math.Max(posXAmpl, negXAmpl), Math.Max(posYAmpl, negYAmpl));

            return Math.Sqrt(2 * maxDerivative * maxDerivative * channels * channels);
        }

        private static (double, double) GetValueInterval(int channels, Kernel krnl)
        {
            double posValue = 0, negValue = 0;
            IterateOverMatrix<double>(krnl.X, (x, y, value) =>
            {
                if (value > 0)
                    posValue += value;
                else
                    negValue += value;
            });

            return (negValue * channels * channelSize, posValue * channels * channelSize);
        }
    }
}
