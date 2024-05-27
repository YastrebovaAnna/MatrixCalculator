using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class AddOperation : IMatrixOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for addition.");
            }

            var result = new double[matrixA.Rows, matrixA.Columns];
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Columns; j++)
                {
                    result[i, j] = matrixA.MatrixArray[i, j] + matrixB.MatrixArray[i, j];
                }
            }
            return new Matrix(matrixA.Rows, matrixA.Columns, result);
        }
    }
}
