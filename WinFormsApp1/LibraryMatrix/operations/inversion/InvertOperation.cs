using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;
using LibraryMatrix.operations.determinant;
using LibraryMatrix.operations.unary;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.inversion
{
    public class InvertOperation : IMatrixOperation<IMatrix>
    {
        private readonly SubMatrixCreator _subMatrixCreator;
        private readonly CalculateDeterminantRecursive _calculateDeterminantRecursive;
        private readonly IUnaryMatrixSizeValidator _sizeValidator;

        public InvertOperation()
        {
            _subMatrixCreator = new SubMatrixCreator();
            _calculateDeterminantRecursive = new CalculateDeterminantRecursive();
            _sizeValidator = new SquareMatrixValidator();
        }

        public IMatrix Execute(IMatrix matrix)
        {
            _sizeValidator.Validate(matrix);

            int size = matrix.Rows;
            double[,] invertedMatrixArray = new double[size, size];
            double determinant = _calculateDeterminantRecursive.Execute(matrix);

            if (determinant == 0)
            {
                MessageBoxHelper.Show($"Matrix determinant is zero, cannot invert.");
                return null;
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] subMatrix = _subMatrixCreator.CreateSubMatrix(matrix.MatrixArray, i, j);
                    double subDeterminant = _calculateDeterminantRecursive.Execute(new Matrix(size - 1, size - 1, subMatrix));

                    double cofactor = Math.Pow(-1, i + j) * subDeterminant;
                    invertedMatrixArray[j, i] = cofactor / determinant;
                }
            }

            return new Matrix(size, size, invertedMatrixArray);
        }
    }
}
