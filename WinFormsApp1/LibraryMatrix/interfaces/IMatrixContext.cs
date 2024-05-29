
namespace LibraryMatrix.interfaces
{
    public interface IMatrixContext
    {
        void SetStrategy(IMatrixBinaryOperation matrixStrategy);
        void SetStrategy(IElementOperation elementStrategy);
        void SetStrategy(IMatrixDeterminantOperation determinantStrategy);
        IMatrix ExecuteOperation(IMatrix matrixA, IMatrix matrixB);
        IMatrix ExecuteOperation(IMatrix matrix);
        double ExecuteDeterminantOperation(IMatrix matrix);
        void SetStrategy(IMatrixRankOperation operation);
        void SetStrategy(IMatrixTraceOperation operation);
        void SetStrategy(IMatrixElementFinder operation);
        void SetStrategy(IMatrixNormOperation operation);
        int ExecuteRankOperation(IMatrix matrix);
        double ExecuteTraceOperation(IMatrix matrix);
        double ExecuteElementFinderOperation(IMatrix matrix);
        double ExecuteNormOperation(IMatrix matrix);
        void SetStrategy(ITransposeOperation operation);
        void SetStrategy(IInvertOperation operation);
        void SetStrategy(IRotateClockwiseOperation operation);
        void SetStrategy(IRotateCounterClockwiseOperation operation);
        IMatrix ExecuteTransposeOperation(IMatrix matrix);
        IMatrix ExecuteInvertOperation(IMatrix matrix);
        IMatrix ExecuteRotateClockwiseOperation(IMatrix matrix);
        IMatrix ExecuteRotateCounterClockwiseOperation(IMatrix matrix);
    }
}
