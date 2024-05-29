using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.calculator
{
    public class MatrixContext : IMatrixContext
    {
        private IMatrixBinaryOperation _matrixBinaryStrategy;
        private IElementOperation _elementStrategy;
        private IMatrixDeterminantOperation _determinantStrategy;
        private IMatrixRankOperation _rankStrategy;
        private IMatrixTraceOperation _traceStrategy;
        private IMatrixElementFinder _elementFinderStrategy;
        private IMatrixNormOperation _normStrategy;
        public void SetStrategy(IMatrixBinaryOperation strategy)
        {
            _matrixBinaryStrategy = strategy;
        }

        public void SetStrategy(IElementOperation strategy)
        {
            _elementStrategy = strategy;
        }

        public void SetStrategy(IMatrixDeterminantOperation strategy)
        {
            _determinantStrategy = strategy;
        }

        public void SetStrategy(IMatrixRankOperation strategy)
        {
            _rankStrategy = strategy;
        }

        public void SetStrategy(IMatrixTraceOperation strategy)
        {
            _traceStrategy = strategy;
        }

        public void SetStrategy(IMatrixElementFinder strategy)
        {
            _elementFinderStrategy = strategy;
        }

        public void SetStrategy(IMatrixNormOperation strategy)
        {
            _normStrategy = strategy;
        }

        public double ExecuteDeterminantOperation(IMatrix matrix)
        {
            if (_determinantStrategy == null)
                throw new InvalidOperationException("Determinant strategy is not set.");

            return _determinantStrategy.Execute(matrix);
        }

        public IMatrix ExecuteOperation(IMatrix matrixA, IMatrix matrixB)
        {
            if (_matrixBinaryStrategy == null)
                throw new InvalidOperationException("Binary operation strategy is not set.");

            return _matrixBinaryStrategy.Execute(matrixA, matrixB);
        }

        public IMatrix ExecuteOperation(IMatrix matrix)
        {
            if (_elementStrategy == null)
                throw new InvalidOperationException("Element operation strategy is not set.");

            var resultArray = new double[matrix.Rows, matrix.Columns];
            MatrixProcessor.IterateOverMatrix(matrix.Rows, matrix.Columns, (i, j) =>
            {
                resultArray[i, j] = _elementStrategy.Execute(matrix.MatrixArray[i, j]);
            });
            return new Matrix(matrix.Rows, matrix.Columns, resultArray);
        }

        public int ExecuteRankOperation(IMatrix matrix)
        {
            if (_rankStrategy == null)
                throw new InvalidOperationException("Rank operation strategy is not set.");

            return _rankStrategy.Execute(matrix);
        }

        public double ExecuteTraceOperation(IMatrix matrix)
        {
            if (_traceStrategy == null)
                throw new InvalidOperationException("Trace operation strategy is not set.");

            return _traceStrategy.Execute(matrix);
        }

        public double ExecuteElementFinderOperation(IMatrix matrix)
        {
            if (_elementFinderStrategy == null)
                throw new InvalidOperationException("Element finder strategy is not set.");

            return _elementFinderStrategy.Execute(matrix);
        }

        public double ExecuteNormOperation(IMatrix matrix)
        {
            if (_normStrategy == null)
                throw new InvalidOperationException("Norm operation strategy is not set.");

            return _normStrategy.Execute(matrix);
        }
    }
}
