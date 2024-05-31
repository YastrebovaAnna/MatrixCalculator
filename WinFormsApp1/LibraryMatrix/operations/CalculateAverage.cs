using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateAverage : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double sum = 0.0;
            int elementCount = matrix.Rows * matrix.Columns;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                sum += value;
            });

            return sum / elementCount;
        }
    }
}
