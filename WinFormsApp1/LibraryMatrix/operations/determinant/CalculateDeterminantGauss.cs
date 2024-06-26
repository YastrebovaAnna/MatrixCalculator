﻿using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.determinant
{
    public class CalculateDeterminantGauss : IMatrixOperation<double>
    {
        private readonly IUnaryMatrixSizeValidator _sizeValidator;

        public CalculateDeterminantGauss()
        {
            _sizeValidator = new SquareMatrixValidator();
        }
        public double Execute(IMatrix matrix)
        {
            _sizeValidator.Validate(matrix);

            double[,] tempMatrix = (double[,])matrix.MatrixArray.Clone();
            int n = matrix.Rows;
            double determinant = 1.0;

            for (int i = 0; i < n; i++)
            {
                int pivot = i;
                for (int j = i + 1; j < n; j++)
                {
                    if (Math.Abs(tempMatrix[j, i]) > Math.Abs(tempMatrix[pivot, i]))
                        pivot = j;
                }

                if (pivot != i)
                {
                    for (int k = 0; k < n; k++)
                    {
                        double tmp = tempMatrix[i, k];
                        tempMatrix[i, k] = tempMatrix[pivot, k];
                        tempMatrix[pivot, k] = tmp;
                    }
                    determinant *= -1;
                }

                if (tempMatrix[i, i] == 0)
                    return 0;

                determinant *= tempMatrix[i, i];

                for (int j = i + 1; j < n; j++)
                {
                    double factor = tempMatrix[j, i] / tempMatrix[i, i];
                    for (int k = i; k < n; k++)
                    {
                        tempMatrix[j, k] -= factor * tempMatrix[i, k];
                    }
                }
            }

            return determinant;
        }
    }
}
