using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class AddOperation : IMatrixBinaryOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for addition.");
            }

            var result = new double[matrixA.Rows, matrixA.Columns];
            MatrixProcessor.IterateOverMatrix(matrixA.Rows, matrixA.Columns, (i, j) =>
            {
                result[i, j] = matrixA.MatrixArray[i, j] + matrixB.MatrixArray[i, j];
            });
            return new Matrix(matrixA.Rows, matrixA.Columns, result);
        }
    }
}
