using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public abstract class MatrixBinaryOperationBase : IMatrixBinaryOperation
    {
        protected abstract double PerformOperation(double valueA, double valueB);

        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for this operation.");
            }

            var result = new double[matrixA.Rows, matrixA.Columns];
            var iterator = new MatrixIterator(matrixA);

            iterator.Iterate((i, j, valueA, valueB) =>
            {
                result[i, j] = PerformOperation(valueA, valueB);
            }, matrixB);

            return new Matrix(matrixA.Rows, matrixA.Columns, result);
        }

        public IMatrix Execute(IMatrix matrix)
        {
            throw new NotImplementedException("Binary operation requires two matrices.");
        }
    }
}