using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public abstract class MatrixUnaryOperationBase : IMatrixOperation<IMatrix>
    {
        protected abstract double PerformOperation(double value);

        public IMatrix Execute(IMatrix matrix)
        {
            var result = new double[matrix.Rows, matrix.Columns];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                result[i, j] = PerformOperation(value);
            });

            return new Matrix(matrix.Rows, matrix.Columns, result);
        }
    }
}
