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
