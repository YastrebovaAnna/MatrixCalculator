using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.calculator
{
    public class MatrixContext : IMatrixContext
    {
        private object _strategy;

        public void SetStrategy<T>(IMatrixOperation<T> strategy)
        {
            _strategy = strategy;
        }

        public T ExecuteOperation<T>(IMatrix matrix)
        {
            if (_strategy is IMatrixOperation<T> operation)
            {
                return operation.Execute(matrix);
            }
            throw new InvalidOperationException("Operation strategy is not set.");
        }

        public IMatrix ExecuteBinaryOperation(IMatrix matrix1, IMatrix matrix2)
        {
            if (_strategy is IMatrixBinaryOperation operation)
            {
                return operation.Execute(matrix1, matrix2);
            }
            throw new InvalidOperationException("Binary operation strategy is not set.");
        }
    }
}
