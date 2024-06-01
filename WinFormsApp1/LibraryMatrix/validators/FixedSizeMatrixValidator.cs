using LibraryMatrix.interfaces.validation;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryMatrix.core;

namespace LibraryMatrix.validators
{
    public class FixedSizeMatrixValidator : IFixedSizeMatrixValidator
    {
        public void Validate(IMatrix matrix, int requiredRows, int requiredColumns)
        {
            if (matrix.Rows != requiredRows || matrix.Columns != requiredColumns)
            {
                MessageBoxHelper.Show($"Matrix must be {requiredRows}x{requiredColumns}.");
                return;
            }
        }
    }
}
