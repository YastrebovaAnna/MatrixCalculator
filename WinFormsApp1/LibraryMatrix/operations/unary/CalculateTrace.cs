using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateTrace : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                throw new InvalidOperationException("Matrix must be square.");

            double trace = 0.0;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                if (i == j)
                {
                    trace += value;
                }
            });

            return trace;
        }
    }
}
