using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class AddOperation : IMatrixBinaryOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for addition.");
            }

            var result = new double[matrixA.Rows, matrixA.Columns];
            var iterator = new MatrixIterator(matrixA);

            iterator.Iterate((i, j, valueA, valueB) =>
            {
                result[i, j] = valueA + valueB;
            }, matrixB);

            return new Matrix(matrixA.Rows, matrixA.Columns, result);
        }

        public IMatrix Execute(IMatrix matrix)
        {
            throw new NotImplementedException("EqualityOperation requires two matrices.");
        }
    }
}
