using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class InvertOperation : IInvertOperation
    {
        public IMatrix Execute(IMatrix matrix)
        {
            int size = matrix.Rows;
            double[,] invertedMatrixArray = new double[size, size];
            double determinant = CalculateDeterminantRecursive(matrix.MatrixArray);

            if (determinant == 0)
                throw new InvalidOperationException("Matrix determinant is zero, cannot invert.");

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] subMatrix = CreateSubMatrix(matrix.MatrixArray, i, j);
                    double subDeterminant = CalculateDeterminantRecursive(subMatrix);

                    double cofactor = Math.Pow(-1, i + j) * subDeterminant;
                    invertedMatrixArray[j, i] = cofactor / determinant;
                }
            }

            return new Matrix(size, size, invertedMatrixArray);
        }

        private double CalculateDeterminantRecursive(double[,] matrix)
        {
            int size = matrix.GetLength(0);
            if (size == 1) return matrix[0, 0];

            double determinant = 0;
            for (int j = 0; j < size; j++)
            {
                double[,] subMatrix = CreateSubMatrix(matrix, 0, j);
                double subDeterminant = CalculateDeterminantRecursive(subMatrix);
                determinant += Math.Pow(-1, j) * matrix[0, j] * subDeterminant;
            }
            return determinant;
        }

        private double[,] CreateSubMatrix(double[,] matrix, int excludeRow, int excludeCol)
        {
            int size = matrix.GetLength(0);
            double[,] subMatrix = new double[size - 1, size - 1];
            int r = -1;

            for (int i = 0; i < size; i++)
            {
                if (i == excludeRow) continue;
                r++;
                int c = -1;

                for (int j = 0; j < size; j++)
                {
                    if (j == excludeCol) continue;
                    subMatrix[r, ++c] = matrix[i, j];
                }
            }
            return subMatrix;
        }
    }
}
