using LibraryMatrix.interfaces.validation;
using LibraryMatrix.interfaces;
using LibraryMatrix.core;

namespace LibraryMatrix.validators
{
    public class MultiplicationSizeValidator : IMatrixSizeValidator
    {
        public void Validate(IMatrix matrixA, IMatrix matrixB)
        {
            if (matrixA.Columns != matrixB.Rows)
            {
                MessageBoxHelper.Show("Number of columns of the first matrix must equal the number of rows of the second matrix.");
                return;
            }
        }
    }
}
