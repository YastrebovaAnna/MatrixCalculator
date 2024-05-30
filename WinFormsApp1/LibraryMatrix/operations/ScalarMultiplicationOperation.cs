using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class ScalarMultiplicationOperation : IMatrixOperation<IMatrix>
    {
        private readonly double _scalar;

        public ScalarMultiplicationOperation(double scalar)
        {
            _scalar = scalar;
        }

        public IMatrix Execute(IMatrix matrix)
        {
            double[,] result = new double[matrix.Rows, matrix.Columns];

            MatrixProcessor.IterateOverMatrix(matrix.Rows, matrix.Columns, (i, j) =>
            {
                result[i, j] = matrix.MatrixArray[i, j] * _scalar;
            });

            return new Matrix(matrix.Rows, matrix.Columns, result);
        }
    }
}
