namespace LibraryMatrix.interfaces
{
    public interface IMatrixBinaryOperation : IMatrixOperation<IMatrix>
    {
        IMatrix Execute(IMatrix matrixA, IMatrix matrixB);
    }
}
