using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;

namespace LibraryMatrix.operations
{
    public abstract class MatrixUnaryOperationBase : IMatrixOperation<IMatrix>
    {
        private readonly IUnaryMatrixSizeValidator? _sizeValidator;

        protected MatrixUnaryOperationBase(IUnaryMatrixSizeValidator? sizeValidator = null)
        {
            _sizeValidator = sizeValidator;
        }

        protected abstract double PerformOperation(double value);

        public IMatrix Execute(IMatrix matrix)
        {
            _sizeValidator?.Validate(matrix);

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
