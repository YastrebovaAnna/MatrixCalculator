using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class FindMinimumElement : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double min = double.MaxValue;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                if (value < min)
                {
                    min = value;
                }
            });

            return min;
        }
    }
}
