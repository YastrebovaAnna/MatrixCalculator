using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMatrix.core;

namespace LibraryMatrix
{
    public class MatrixArithmeticOp : Matrix
    {
        public MatrixArithmeticOp(int rows, int cols, double[,] values) : base(rows, cols, values)
        {

        }
        public static MatrixArithmeticOp operator +(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            double[,] resultArray = new double[matrix1.Rows, matrix1.Columns];

            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    resultArray[i, j] = matrix1.MatrixArray[i, j] + matrix2.MatrixArray[i, j];
                }
            }

            return new MatrixArithmeticOp(matrix1.Rows, matrix1.Columns, resultArray);
        }
        public static MatrixArithmeticOp operator -(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            double[,] resultArray = new double[matrix1.Rows, matrix1.Columns];
            for (int i = 0; i < matrix1.Rows; i++)
            {
                for (int j = 0; j < matrix1.Columns; j++)
                {
                    resultArray[i, j] = matrix1.MatrixArray[i, j] - matrix2.MatrixArray[i, j];
                }
            }

            return new MatrixArithmeticOp(matrix1.Rows, matrix1.Columns, resultArray);
        }
        public static MatrixArithmeticOp operator *(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            int rows = matrix1.Rows;
            int cols = matrix2.Columns;
            double[,] resultArray = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < matrix1.Columns; k++)
                    {
                        sum += matrix1.MatrixArray[i, k] * matrix2.MatrixArray[k, j];
                    }
                    resultArray[i, j] = sum;
                }
            }

            return new MatrixArithmeticOp(rows, cols, resultArray);
        }
        public static MatrixArithmeticOp operator *(MatrixArithmeticOp matrix, double scalar)
        {
            int rows = matrix.MatrixArray.GetLength(0);
            int columns = matrix.MatrixArray.GetLength(1);
            double[,] result = new double[rows, columns];

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    result[i, j] = matrix.MatrixArray[i, j] * scalar;
                }
            }

            return new MatrixArithmeticOp(rows, columns, result);
        }
        public static MatrixArithmeticOp operator ^(MatrixArithmeticOp matrix1, double power)
        {
            if (power < 0)
            {
                throw new ArgumentException("The power must be a non-negative integer.");
            }

            int size = matrix1.MatrixArray.GetLength(0);
            if (size != matrix1.MatrixArray.GetLength(1))
            {
                throw new ArgumentException("The matrix must be square.");
            }

            if (power == 0)
            {
                // Return the identity matrix
                double[,] identityData = new double[size, size];
                for (int i = 0; i < size; i++)
                {
                    identityData[i, i] = 1;
                }
                return new MatrixArithmeticOp(matrix1.Rows, matrix1.Columns, identityData);
            }

            MatrixArithmeticOp result = matrix1;
            for (int i = 1; i < power; i++)
            {
                result = result * matrix1;
            }
            return result;
        }
        public static bool operator ==(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            if (ReferenceEquals(matrix1, matrix2))
            {
                return true;
            }

            if (ReferenceEquals(matrix1, null) || ReferenceEquals(matrix2, null))
            {
                return false;
            }

            if (matrix1.MatrixArray.GetLength(0) != matrix2.MatrixArray.GetLength(0) || matrix1.MatrixArray.GetLength(1) != matrix2.MatrixArray.GetLength(1))
            {
                return false;
            }

            for (int i = 0; i < matrix1.MatrixArray.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.MatrixArray.GetLength(1); j++)
                {
                    if (matrix1.MatrixArray[i, j] != matrix2.MatrixArray[i, j])
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static bool operator !=(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            return !(matrix1 == matrix2);
        }

        public MatrixArithmeticOp Exp()
        {
            double[,] resultArray = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultArray[i, j] = Math.Exp(MatrixArray[i, j]);
                }
            }
            return new MatrixArithmeticOp(Rows, Columns, resultArray);
        }
        public MatrixArithmeticOp Log()
        {
            double[,] resultArray = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultArray[i, j] = Math.Log(MatrixArray[i, j]);
                }
            }

            return new MatrixArithmeticOp(Rows, Columns, resultArray);
        }
        public MatrixArithmeticOp Sin()
        {
            double[,] resultArray = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultArray[i, j] = Math.Sin(MatrixArray[i, j]);
                }
            }

            return new MatrixArithmeticOp(Rows, Columns, resultArray);
        }
        public MatrixArithmeticOp Cos()
        {
            double[,] resultArray = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultArray[i, j] = Math.Cos(MatrixArray[i, j]);
                }
            }

            return new MatrixArithmeticOp(Rows, Columns, resultArray);
        }
        public MatrixArithmeticOp Tan()
        {
            double[,] resultArray = new double[Rows, Columns];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    resultArray[i, j] = Math.Tan(MatrixArray[i, j]);
                }
            }

            return new MatrixArithmeticOp(Rows, Columns, resultArray);
        }
    }

}
