using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.calculator
{
    public class MatrixContext : IMatrixContext
    {
        private IMatrixOperation _matrixStrategy;
        private IElementOperation _elementStrategy;

        public void SetStrategy(IMatrixOperation strategy)
        {
            _matrixStrategy = strategy;
        }

        public void SetStrategy(IElementOperation strategy)
        {
            _elementStrategy = strategy;
        }

        public IMatrix ExecuteOperation(IMatrix matrixA, IMatrix matrixB)
        {
            return _matrixStrategy.Execute(matrixA, matrixB);
        }

        public IMatrix ExecuteOperation(IMatrix matrix)
        {
            var resultArray = new double[matrix.Rows, matrix.Columns];
            MatrixProcessor.IterateOverMatrix(matrix.Rows, matrix.Columns, (i, j) =>
            {
                resultArray[i, j] = _elementStrategy.Execute(matrix.MatrixArray[i, j]);
            });
            return new Matrix(matrix.Rows, matrix.Columns, resultArray);
        }
    }
}
