using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class MultiplicationOperation : IMatrixBinaryOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Columns != matrixB.Rows)
            {
                throw new InvalidOperationException("Number of columns in Matrix A must be equal to number of rows in Matrix B for multiplication.");
            }

            var result = new double[matrixA.Rows, matrixB.Columns];
            var iterator = new MatrixIterator(matrixA);

            iterator.Iterate((i, j, valueA, valueB) =>
            {
                for (int k = 0; k < matrixA.Columns; k++)
                {
                    result[i, j] += matrixA.MatrixArray[i, k] * matrixB.MatrixArray[k, j];
                }
            }, matrixB);

            return new Matrix(matrixA.Rows, matrixB.Columns, result);
        }
        public IMatrix Execute(IMatrix matrix)
        {
            throw new NotImplementedException("MultiplicationOperation requires two matrices.");
        }
    }
}
