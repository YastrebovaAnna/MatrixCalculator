using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateProduct : IMatrixElementFinder
    {
        public double Execute(IMatrix matrix)
        {
            double product = 1.0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    product *= matrix.MatrixArray[i, j];
                }
            }
            return product;
        }
    }
}
