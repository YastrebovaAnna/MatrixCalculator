using LibraryMatrix.interfaces;

namespace LibraryMatrix.calculator
{
    public class MatrixContext
    {
        private IMatrixOperation _strategy;

        public void SetStrategy(IMatrixOperation strategy)
        {
            _strategy = strategy;
        }

        public IMatrix ExecuteOperation(IMatrix matrixA, IMatrix matrixB)
        {
            return _strategy.Execute(matrixA, matrixB);
        }
    }
}
