namespace LibraryMatrix.interfaces
{
    public interface IMatrixOperation
    {
        IMatrix Execute(IMatrix matrixA, IMatrix matrixB);
    }
}
