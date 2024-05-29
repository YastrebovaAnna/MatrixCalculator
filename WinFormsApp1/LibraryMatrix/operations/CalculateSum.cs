using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.operations
{
    public class CalculateSum : IMatrixElementFinder
    {
        public double Execute(IMatrix matrix)
        {
            double sum = 0.0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sum += matrix.MatrixArray[i, j];
                }
            }
            return sum;
        }
    }
}
