using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class RotateClockwiseOperation : IRotateClockwiseOperation
    {
        public IMatrix Execute(IMatrix matrix)
        {
            double[,] rotatedMatrixArray = new double[matrix.Columns, matrix.Rows];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    rotatedMatrixArray[j, matrix.Rows - 1 - i] = matrix.MatrixArray[i, j];
                }
            }

            return new Matrix(matrix.Columns, matrix.Rows, rotatedMatrixArray);
        }
    }
}
