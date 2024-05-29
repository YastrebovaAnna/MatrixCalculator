namespace LibraryMatrix.interfaces
{
    public interface IMatrixBinaryOperation
    {
        IMatrix Execute(IMatrix matrixA, IMatrix matrixB);
    }
}
