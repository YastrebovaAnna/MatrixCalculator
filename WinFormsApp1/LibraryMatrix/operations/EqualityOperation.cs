using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class EqualityOperation : IMatrixOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (ReferenceEquals(matrixA, matrixB))
                return new Matrix(1, 1, new double[,] { { 1.0 } });

            if (matrixA == null || matrixB == null)
                return new Matrix(1, 1, new double[,] { { 0.0 } });

            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
                return new Matrix(1, 1, new double[,] { { 0.0 } });

            for (int i = 0; i < matrixA.Rows; i++)
            {
                for (int j = 0; j < matrixA.Columns; j++)
                {
                    if (matrixA.MatrixArray[i, j] != matrixB.MatrixArray[i, j])
                        return new Matrix(1, 1, new double[,] { { 0.0 } });
                }
            }

            return new Matrix(1, 1, new double[,] { { 1.0 } });
        }
    }
}
