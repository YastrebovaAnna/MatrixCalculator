using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateProduct : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double product = 1.0;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                product *= value;
            });

            return product;
        }
    }
}
