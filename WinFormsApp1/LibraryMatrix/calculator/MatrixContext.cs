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
        private ITransposeOperation _transposeStrategy;
        private IInvertOperation _invertStrategy;
        private IRotateClockwiseOperation _rotateClockwiseStrategy;
        private IRotateCounterClockwiseOperation _rotateCounterClockwiseStrategy;

        public void SetStrategy(IMatrixBinaryOperation strategy) => _matrixBinaryStrategy = strategy;
        public void SetStrategy(IElementOperation strategy) => _elementStrategy = strategy;
        public void SetStrategy(IMatrixDeterminantOperation strategy) => _determinantStrategy = strategy;
        public void SetStrategy(IMatrixRankOperation strategy) => _rankStrategy = strategy;
        public void SetStrategy(IMatrixTraceOperation strategy) => _traceStrategy = strategy;
        public void SetStrategy(IMatrixElementFinder strategy) => _elementFinderStrategy = strategy;
        public void SetStrategy(IMatrixNormOperation strategy) => _normStrategy = strategy;
        public void SetStrategy(ITransposeOperation strategy) => _transposeStrategy = strategy;
        public void SetStrategy(IInvertOperation strategy) => _invertStrategy = strategy;
        public void SetStrategy(IRotateClockwiseOperation strategy) => _rotateClockwiseStrategy = strategy;
        public void SetStrategy(IRotateCounterClockwiseOperation strategy) => _rotateCounterClockwiseStrategy = strategy;

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

        public double ExecuteDeterminantOperation(IMatrix matrix)
        {
            if (_determinantStrategy == null)
                throw new InvalidOperationException("Determinant strategy is not set.");
            return _determinantStrategy.Execute(matrix);
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

        public IMatrix ExecuteTransposeOperation(IMatrix matrix)
        {
            if (_transposeStrategy == null)
                throw new InvalidOperationException("Transpose strategy is not set.");
            return _transposeStrategy.Execute(matrix);
        }

        public IMatrix ExecuteInvertOperation(IMatrix matrix)
        {
            if (_invertStrategy == null)
                throw new InvalidOperationException("Invert strategy is not set.");
            return _invertStrategy.Execute(matrix);
        }

        public IMatrix ExecuteRotateClockwiseOperation(IMatrix matrix)
        {
            if (_rotateClockwiseStrategy == null)
                throw new InvalidOperationException("RotateClockwise strategy is not set.");
            return _rotateClockwiseStrategy.Execute(matrix);
        }

        public IMatrix ExecuteRotateCounterClockwiseOperation(IMatrix matrix)
        {
            if (_rotateCounterClockwiseStrategy == null)
                throw new InvalidOperationException("RotateCounterClockwise strategy is not set.");
            return _rotateCounterClockwiseStrategy.Execute(matrix);
        }
    }
}
