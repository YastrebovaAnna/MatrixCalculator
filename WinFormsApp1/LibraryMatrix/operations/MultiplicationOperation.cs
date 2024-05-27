using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class MultiplicationOperation : IMatrixOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Columns != matrixB.Rows)
            {
                throw new InvalidOperationException("Number of columns in Matrix A must be equal to number of rows in Matrix B for multiplication.");
            }

            var result = new double[matrixA.Rows, matrixB.Columns];
            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixB.Columns; j++)
                {
                    for (int k = 0; k < matrixA.Columns; k++)
                    {
                        result[i, j] += matrixA.MatrixArray[i, k] * matrixB.MatrixArray[k, j];
                    }
                }
            }
            return new Matrix(matrixA.Rows, matrixB.Columns, result);
        }
    }
}
