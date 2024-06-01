namespace LibraryMatrix.interfaces
{
    public interface IMatrixOperation<T>
    {
        T Execute(IMatrix matrix);
    }
}
