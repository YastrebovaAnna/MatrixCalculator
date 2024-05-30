using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class PowerOperation : IMatrixOperation<IMatrix>
    {
        private readonly double _power;

        public PowerOperation(double power)
        {
            _power = power;
        }

        public IMatrix Execute(IMatrix matrix)
        {
            int rows = matrix.Rows;
            int cols = matrix.Columns;
            double[,] result = new double[rows, cols];

            MatrixProcessor.IterateOverMatrix(rows, cols, (i, j) =>
            {
                result[i, j] = Math.Pow(matrix.MatrixArray[i, j], _power);
            });

            return new Matrix(rows, cols, result);
        }
    }
}
