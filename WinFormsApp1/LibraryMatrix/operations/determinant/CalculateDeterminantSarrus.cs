using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateDeterminantSarrus : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            if (matrix.Rows != 3 || matrix.Columns != 3)
                throw new InvalidOperationException("Matrix must be 3x3 for Sarrus method.");

            double[,] m = matrix.MatrixArray;
            return
                m[0, 0] * m[1, 1] * m[2, 2] +
                m[0, 1] * m[1, 2] * m[2, 0] +
                m[0, 2] * m[1, 0] * m[2, 1] -
                m[0, 2] * m[1, 1] * m[2, 0] -
                m[0, 1] * m[1, 0] * m[2, 2] -
                m[0, 0] * m[1, 2] * m[2, 1];
        }
    }
}
