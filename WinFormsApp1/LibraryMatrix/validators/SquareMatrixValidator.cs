using LibraryMatrix.interfaces.validation;
using LibraryMatrix.interfaces;
using LibraryMatrix.core;

namespace LibraryMatrix.validators
{
    public class SquareMatrixValidator : IUnaryMatrixSizeValidator
    {
        public void Validate(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
            {
                MessageBoxHelper.Show("Matrix must be square for this operation.");
                return;
            }
        }
    }
}
