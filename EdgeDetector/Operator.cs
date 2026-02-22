using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    internal struct Operator
    {
        public string name;
        public double[,] X;
        public double[,] Y;

        public enum Operators
        {
            Roberts = 1,
            Prewitt = 2,
            Sobel3x3 = 3,
            Sobel5x5 = 4
        }

        public Operator(Operators op)
        {
            switch (op)
            {
                case Operators.Roberts:
                    this.name = "Roberts";
                    this.X = new double[2, 2]
                    {
                        { 0, 1 },
                        { -1, 0 }
                    };
                    this.Y = new double[2, 2]
                    {
                        { 1, 0 },
                        { 0, -1 }
                    };
                    break;

                case Operators.Prewitt:
                    this.name = "Prewitt";
                    this.X = new double[3, 3]
                    {
                        { -1, 0, 1 },
                        { -1, 0, 1 },
                        { -1, 0, 1 }
                    };
                    this.Y = new double[3, 3]
                    {
                        { 1, 1, 1 },
                        { 0, 0, 0 },
                        { -1, -1, -1 }
                    };
                    break;

                case Operators.Sobel3x3:
                    this.name = "Sobel3x3";
                    this.X = new double[3, 3]
                    {
                        { -1, 0, 1 },
                        { -2, 0, 2 },
                        { -1, 0, 1 }
                    };
                    this.Y = new double[3, 3]
                    {
                        { 1, 2, 1 },
                        { 0, 0, 0 },
                        { -1, -2, -1 }
                    };
                    break;

                case Operators.Sobel5x5:
                    this.name = "Sobel5x5";
                    this.X = new double[5, 5]
                    {
                        { -1, -2, 0, 2, 1 },
                        { -2, -3, 0, 3, 2 },
                        { -3, -5, 0, 5, 3 },
                        { -2, -3, 0, 3, 2 },
                        { -1, -2, 0, 2, 1 }
                    };
                    this.Y = new double[5, 5]
                    {
                        { 1, 2, 3, 2, 1 },
                        { 2, 3, 5, 3, 2 },
                        { 0, 0, 0, 0, 0 },
                        { -2, -3, -5, -3, -2 },
                        { -1, -2, -3, -2, -1 }
                    };
                    break;

                default:
                    this.name = "Roberts";
                    this.X = new double[2, 2]
                    {
                        { 0, 1 },
                        { -1, 0 }
                    };
                    this.Y = new double[2, 2]
                    {
                        { 1, 0 },
                        { 0, -1 }
                    };
                    break;
            }
        }
    }
}