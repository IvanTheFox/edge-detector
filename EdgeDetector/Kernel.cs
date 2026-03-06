using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    internal struct Kernel
    {
        public string Name { get; }
        public int Size { get; }
        public double[,] X { get; }
        public double[,] Y { get; }

        public enum Kernels
        {
            Roberts = 1,
            Prewitt = 2,
            Sobel3x3 = 3,
            Sobel5x5 = 4
        }

        public static Kernel Roberts => new Kernel(Kernels.Roberts);
        public static Kernel Prewitt => new Kernel(Kernels.Prewitt);
        public static Kernel Sobel3x3 => new Kernel(Kernels.Sobel3x3);
        public static Kernel Sobel5x5 => new Kernel(Kernels.Sobel5x5);

        public Kernel(Kernels op)
        {
            switch (op)
            {
                case Kernels.Roberts:
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
            }
            Size = X.GetLength(0);
        }
    }
}