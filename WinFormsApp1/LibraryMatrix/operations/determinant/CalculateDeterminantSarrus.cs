using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.determinant
{
    public class CalculateDeterminantSarrus : IMatrixOperation<double>
    {
        private readonly IFixedSizeMatrixValidator _sizeValidator;

        public CalculateDeterminantSarrus()
        {
            _sizeValidator = new FixedSizeMatrixValidator();
        }

        public double Execute(IMatrix matrix)
        {
            _sizeValidator.Validate(matrix, 3, 3);

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
