using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class LogOperation : IMatrixOperation<IMatrix>
    {
        public IMatrix Execute(IMatrix matrix)
        {
            int rows = matrix.Rows;
            int cols = matrix.Columns;
            double[,] result = new double[rows, cols];

            MatrixProcessor.IterateOverMatrix(rows, cols, (i, j) =>
            {
                result[i, j] = Math.Log(matrix.MatrixArray[i, j]);
            });

            return new Matrix(rows, cols, result);
        }
    }
}
