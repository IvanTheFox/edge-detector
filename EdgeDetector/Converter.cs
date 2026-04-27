using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace EdgeDetector
{
    internal class Converter
    {
        public const int CHANNEL_SIZE = 255;

        // Edge map generators
        public static Bitmap GetGradientEdgeMap(Bitmap image, Kernel2d krnl, int? threshold = null)
        {
            // Splitting the image into 3 int matrices of red, green and blue values
            (int[,] redInt, int[,] greenInt, int[,] blueInt) = GetChannels(image);

            // Converting int matrices to double matrices
            double[,] red = Matrix.NewMatrix(redInt,
                (value, x, y) => (double)value);
            double[,] green = Matrix.NewMatrix(greenInt,
                (value, x, y) => (double)value);
            double[,] blue = Matrix.NewMatrix(blueInt,
                (value, x, y) => (double)value);

            // Convolving channel matrices with X and Y variations of the kernel
            double[,] redX = Matrix.NewMatrix(Convolve(red, krnl.X),
                (value, x, y) => Math.Abs(value));
            double[,] greenX = Matrix.NewMatrix(Convolve(green, krnl.X),
                (value, x, y) => Math.Abs(value));
            double[,] blueX = Matrix.NewMatrix(Convolve(blue, krnl.X),
                (value, x, y) => Math.Abs(value));

            double[,] redY = Matrix.NewMatrix(Convolve(red, krnl.Y),
                (value, x, y) => Math.Abs(value));
            double[,] greenY = Matrix.NewMatrix(Convolve(green, krnl.Y),
                (value, x, y) => Math.Abs(value));
            double[,] blueY = Matrix.NewMatrix(Convolve(blue, krnl.Y),
                (value, x, y) => Math.Abs(value));

            // Calculating magnitude of change
            double[,] dx = Matrix.NewMatrix(redX,
                (value, x, y) => value + greenX[x, y] + blueX[x, y]);
            double[,] dy = Matrix.NewMatrix(redY,
                (value, x, y) => value + greenY[x, y] + blueY[x, y]);

            double[,] magnitude = Matrix.NewMatrix(redX,
                (value, x, y) => Math.Sqrt(dx[x, y] * dx[x, y] + dy[x, y] * dy[x, y]));

            // Mapping values to color channel size
            (double minDx, double maxDx) = GetConvolutionExtremes(255, krnl.X);
            (double minDy, double maxDy) = GetConvolutionExtremes(255, krnl.Y);
            double maxD = Math.Max(maxDx, maxDy);
            double maxMagnitude = Math.Sqrt(2 * maxD * maxD * 3 * 3);

            Matrix.Map(magnitude, 0, maxMagnitude, 0, 255);
            Matrix.Map(dx, minDy * 3, maxDx * 3, 0, 255);
            Matrix.Map(dy, minDy * 3, maxDy * 3, 0, 255);

            // Applying threshold if neccessary
            if (threshold.HasValue)
            {
                Matrix.ForEach(magnitude, (value, x, y) =>
                {
                    if (value < threshold)
                    {
                        dx[x, y] = 0;
                        dy[x, y] = 0;
                    }
                });
            }

            // Converting matrix to a Bitmap
            int[,] magnitudeInt = Matrix.NewMatrix(magnitude, (value, x, y) => (int)value);
            int[,] dxInt = Matrix.NewMatrix(dx, (value, x, y) => (int)value);
            int[,] dyInt = Matrix.NewMatrix(dy, (value, x, y) => (int)value);
            
            Bitmap edgeMap = MatrixToBitmap(dxInt, new int[dx.GetLength(0), dx.GetLength(1)], dyInt);

            return edgeMap;
        }

        public static Bitmap GetLaplacianEdgeMap(Bitmap image, int? threshold = null, int ? gaussianDeviation = null)
        {   
            Kernel krnl = Kernel.Laplacian;
            if (gaussianDeviation.HasValue)
                krnl.X = Convolve(krnl.X, Kernel.Gaussian(gaussianDeviation.Value).X);
            
            // Splitting the image into 3 int matrices of red, green and blue values
            (int[,] redInt, int[,] greenInt, int[,] blueInt) = GetChannels(image);

            // Converting int matrices to double matrices
            double[,] red = Matrix.NewMatrix(redInt,
                (value, x, y) => (double)value);
            double[,] green = Matrix.NewMatrix(greenInt,
                (value, x, y) => (double)value);
            double[,] blue = Matrix.NewMatrix(blueInt,
                (value, x, y) => (double)value);

            // Calculating second derivative of the image using Laplacian kernel
            red = Convolve(red, krnl.X);
            green = Convolve(green, krnl.X);
            blue = Convolve(blue, krnl.X);
            double[,] d2 = Matrix.NewMatrix(red, (value, x, y) =>
                value + green[x, y] + blue[x, y]);

            // Applying threshold and detecting zero crossings if needed
            int[,] d2Int;
            if (threshold.HasValue)
            {
                Matrix.ForEach(d2, (value, x, y) => d2[x, y] = (value > threshold.Value) ? CHANNEL_SIZE : 0);
                d2Int = Matrix.NewMatrix(d2, (value, x, y) => (int)value);
            }
            else
            {
                (double minExtreme, double maxExtreme) = GetConvolutionExtremes(255, krnl.X);
                Matrix.Map(d2, minExtreme * 3, maxExtreme * 3, 0, 255);
                d2Int = Matrix.NewMatrix(d2, (value, x, y) => (int)value);
            }

            // Converting matrix to Bitmap
            Bitmap edgeMap = MatrixToBitmap(d2Int);

            return edgeMap;
        }

        // Image operations
        public static (int[,], int[,], int[,]) GetChannels(Bitmap map)
        {
            int width = map.Width;
            int height = map.Height;

            int[,] red = new int[width, height];
            int[,] green = new int[width, height];
            int[,] blue = new int[width, height];

            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    Color pixel = map.GetPixel(x, y);
                    red[x, y] = pixel.R;
                    green[x, y] = pixel.G;
                    blue[x, y] = pixel.B;
                }
            }

            return (red, green, blue);
        }

        public static Bitmap MatrixToBitmap(int[,] matrix)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            Matrix.ForEach(matrix, (value, x, y) =>
                bitmap.SetPixel(x, y, Color.FromArgb(value, value, value)));

            return bitmap;
        }
        public static Bitmap MatrixToBitmap(int[,] r, int[,] g, int[,] b)
        {
            int width = r.GetLength(0);
            int height = r.GetLength(1);
            Bitmap bitmap = new Bitmap(width, height);

            Matrix.ForEach(r, (value, x, y) => {
                bitmap.SetPixel(x, y, Color.FromArgb(r[x, y], g[x, y], b[x, y]));
                });

            return bitmap;
        }

        // Mathematical operations
        public static double[,] Convolve(double[,] m1, double[,] m2)
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

        public static (double, double) GetConvolutionExtremes(double maxValue, double[,] matrix)
        {
            double negativeSum = 0, positiveSum = 0;
            Matrix.ForEach(matrix, (value, x, y) =>
            {
                if (value > 0)
                    positiveSum += value;
                else
                    negativeSum += value;
            });

            return (maxValue * negativeSum, maxValue * positiveSum);
        }
    }
}