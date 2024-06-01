using LibraryMatrix.interfaces.validation;
using LibraryMatrix.interfaces;
using LibraryMatrix.core;

namespace LibraryMatrix.validators
{
    public class SameSizeValidator : IMatrixSizeValidator
    {
        public void Validate(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
            {
                MessageBoxHelper.Show("Matrices must have the same dimensions for this operation.");
                return;
            }
        }
    }
}
