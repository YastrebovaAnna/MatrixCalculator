using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class FindMinimumElement : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double min = double.MaxValue;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    if (matrix.MatrixArray[i, j] < min)
                        min = matrix.MatrixArray[i, j];
                }
            }
            return min;
        }
    }
}
