using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class FindMaximumElement : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double max = double.MinValue;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix.MatrixArray[i, j] > max)
                        max = matrix.MatrixArray[i, j];
                }
            }
            return max;
        }
    }
}
