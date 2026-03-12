using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EdgeDetector
{
    internal class Matrix
    {
        public static void ForEach<T>(T[,] matrix, Action<T, int, int> operation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    operation(matrix[x, y], x, y);
        }

        public static T2[,] NewMatrix<T1, T2>(T1[,] matrix, Func<T1, int, int, T2> operation)
        {
            int width = matrix.GetLength(0);
            int height = matrix.GetLength(1);
            T2[,] newMatrix = new T2[width, height];

            for (int y = 0; y < height; y++)
                for (int x = 0; x < width; x++)
                    newMatrix[x, y] = operation(matrix[x, y], x, y);

            return newMatrix;
        }
        public static void Map(double[,] matrix, double oldMin, double oldMax, double newMin, double newMax)
        {
            ForEach<double>(matrix, (value, x, y) =>
                matrix[x, y] = (value - oldMin) / (oldMax - oldMin) * (newMax - newMin) + newMin);
        }
    }
}