
namespace LibraryMatrix.interfaces
{
    public interface IMatrixContext
    {
        void SetStrategy<T>(IMatrixOperation<T> operation);
        T ExecuteOperation<T>(IMatrix matrix);
        IMatrix ExecuteBinaryOperation(IMatrix matrix1, IMatrix matrix2);
    }
}
