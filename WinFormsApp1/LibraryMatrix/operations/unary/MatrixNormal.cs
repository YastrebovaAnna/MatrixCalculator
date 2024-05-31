using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class MatrixNormal : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double norm = 0.0;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                norm += value * value;
            });

            return Math.Sqrt(norm);
        }
    }
}
