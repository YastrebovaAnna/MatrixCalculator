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
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                result[i, j] = Math.Pow(value, _power);
            });

            return new Matrix(rows, cols, result);
        }
    }
}
