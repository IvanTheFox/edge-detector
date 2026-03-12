using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    internal class Kernel
    {
        public string Name { get; set; }
        public int Size { get; set; }
        public double[,] X { get; set; }

        public enum Kernels
        {
            Laplacian = 1
        }

        public Kernel()
        {
            Name = "Zeros";
            X = new double[,]
            {
                { 0, 0 },
                { 0, 0 }
            };
            Size = X.GetLength(0);
        }

        public Kernel(string name, double[,] x)
        {
            Name = name;
            X = x;
            Size = x.GetLength(0);
        }

        public Kernel(Kernels krnl)
        {
            switch (krnl)
            {
                default:
                    break;

                case Kernels.Laplacian:
                    Name = "Laplacian";
                    X = new double[,]
                    {
                        { 1, 1, 1 },
                        { 1, -8, 1 },
                        { 1, 1, 1 }
                    };
                    Size = X.GetLength(0);
                    break;
            }
        }

        public static Kernel Laplacian => new Kernel(Kernels.Laplacian);

        public static Kernel Gaussian(int deviation)
        {
            int size = (int)(2 * Math.PI * deviation);
            int variance = deviation * deviation;

            double[,] matrix = new double[size, size];
            Matrix.ForEach(matrix, (value, x, y) =>
                matrix[x, y] = Math.Pow(Math.E, -0.5 * (x * x + y *y) / variance) / 2 / Math.PI / variance );

            Kernel krnl = new Kernel($"Gaussian({deviation})", matrix);
            return krnl;
        }
    }
    
    internal class Kernel2d : Kernel
    {
        public double[,] Y { get; set; }

        public enum Kernels
        {
            Roberts = 1,
            Prewitt = 2,
            Sobel3x3 = 3,
            Sobel5x5 = 4
        }

        public Kernel2d(string name, double[,] x, double[,] y)
            : base(name, x)
        { Y = y; }

        public Kernel2d(Kernels krnl)
        {
            switch (krnl)
            {
                default:
                    Name = "Roberts";
                    X = new double[2, 2]
                    {
                        { 0, 1 },
                        { -1, 0 }
                    };
                    Y = new double[2, 2]
                    {
                        { 1, 0 },
                        { 0, -1 }
                    };
                    break;

                case Kernels.Prewitt:
                    Name = "Prewitt";
                    X = new double[3, 3]
                    {
                        { -1, 0, 1 },
                        { -1, 0, 1 },
                        { -1, 0, 1 }
                    };
                    Y = new double[3, 3]
                    {
                        { 1, 1, 1 },
                        { 0, 0, 0 },
                        { -1, -1, -1 }
                    };
                    break;

                case Kernels.Sobel3x3:
                    Name = "Sobel3x3";
                    X = new double[3, 3]
                    {
                        { -1, 0, 1 },
                        { -2, 0, 2 },
                        { -1, 0, 1 }
                    };
                    Y = new double[3, 3]
                    {
                        { 1, 2, 1 },
                        { 0, 0, 0 },
                        { -1, -2, -1 }
                    };
                    break;

                case Kernels.Sobel5x5:
                    Name = "Sobel5x5";
                    X = new double[5, 5]
                    {
                        { -1, -2, 0, 2, 1 },
                        { -2, -3, 0, 3, 2 },
                        { -3, -5, 0, 5, 3 },
                        { -2, -3, 0, 3, 2 },
                        { -1, -2, 0, 2, 1 }
                    };
                    Y = new double[5, 5]
                    {
                        { 1, 2, 3, 2, 1 },
                        { 2, 3, 5, 3, 2 },
                        { 0, 0, 0, 0, 0 },
                        { -2, -3, -5, -3, -2 },
                        { -1, -2, -3, -2, -1 }
                    };
                    break;
            }
            Size = X.GetLength(0);
        }

        public static Kernel2d Roberts => new Kernel2d(Kernels.Roberts);
        public static Kernel2d Prewitt => new Kernel2d(Kernels.Prewitt);
        public static Kernel2d Sobel3x3 => new Kernel2d(Kernels.Sobel3x3);
        public static Kernel2d Sobel5x5 => new Kernel2d(Kernels.Sobel5x5);
    }
}