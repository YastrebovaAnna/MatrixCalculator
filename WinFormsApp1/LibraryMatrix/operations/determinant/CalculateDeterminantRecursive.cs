using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;
using LibraryMatrix.operations.unary;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.determinant
{
    public class CalculateDeterminantRecursive : IMatrixOperation<double>
    {
        private readonly SubMatrixCreator _subMatrixCreator;
        private readonly IUnaryMatrixSizeValidator _sizeValidator;

        public CalculateDeterminantRecursive()
        {
            _subMatrixCreator = new SubMatrixCreator();
            _sizeValidator = new SquareMatrixValidator();
        }

        public double Execute(IMatrix matrix)
        {
            _sizeValidator.Validate(matrix);
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
