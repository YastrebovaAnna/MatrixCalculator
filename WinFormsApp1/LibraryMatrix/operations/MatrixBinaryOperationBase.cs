using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;

namespace LibraryMatrix.operations
{
    public abstract class MatrixBinaryOperationBase : IMatrixBinaryOperation
    {
        private readonly IMatrixSizeValidator? _sizeValidator;

        protected MatrixBinaryOperationBase(IMatrixSizeValidator? sizeValidator = null)
        {
            _sizeValidator = sizeValidator;
        }

        protected abstract double PerformOperation(double valueA, double valueB);

        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            _sizeValidator?.Validate(matrixA, matrixB);

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