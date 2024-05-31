using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class FindMaximumElement : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double max = double.MinValue;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                if (value > max)
                {
                    max = value;
                }
            });

            return max;
        }
    }
}
