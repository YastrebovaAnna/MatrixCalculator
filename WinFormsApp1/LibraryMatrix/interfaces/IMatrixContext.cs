
namespace LibraryMatrix.interfaces
{
    public interface IMatrixContext
    {
        void SetStrategy(IMatrixOperation matrixStrategy);
        void SetStrategy(IElementOperation elementStrategy);
        IMatrix ExecuteOperation(IMatrix matrixA, IMatrix matrixB);
        IMatrix ExecuteOperation(IMatrix matrix);
    }
}
