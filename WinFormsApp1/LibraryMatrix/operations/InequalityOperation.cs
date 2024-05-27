using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class InequalityOperation : IMatrixOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            var equalityOperation = new EqualityOperation();
            var result = equalityOperation.Execute(matrixA, matrixB);
            return new Matrix(1, 1, new double[,] { { result.MatrixArray[0, 0] == 1.0 ? 0.0 : 1.0 } });
        }
    }
}
