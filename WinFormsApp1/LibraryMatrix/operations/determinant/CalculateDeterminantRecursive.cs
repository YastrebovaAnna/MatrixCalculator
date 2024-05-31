using LibraryMatrix.interfaces;
using LibraryMatrix.operations.unary;

namespace LibraryMatrix.operations.determinant
{
    public class CalculateDeterminantRecursive : IMatrixOperation<double>
    {
        private readonly SubMatrixCreator _subMatrixCreator;

        public CalculateDeterminantRecursive()
        {
            _subMatrixCreator = new SubMatrixCreator();
        }

        public double Execute(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                throw new InvalidOperationException("Matrix must be square.");

            return Determinant(matrix.MatrixArray);
        }

        private double Determinant(double[,] matrix)
        {
            int n = matrix.GetLength(0);

            if (n == 1)
                return matrix[0, 0];

            if (n == 2)
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];

            double det = 0;
            for (int col = 0; col < n; col++)
            {
                double[,] subMatrix = _subMatrixCreator.CreateSubMatrix(matrix, 0, col);
                det += (col % 2 == 0 ? 1 : -1) * matrix[0, col] * Determinant(subMatrix);
            }

            return det;
        }
    }
}
