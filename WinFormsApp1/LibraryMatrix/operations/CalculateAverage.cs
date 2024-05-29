using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateAverage : IMatrixElementFinder
    {
        public double Execute(IMatrix matrix)
        {
            double sum = 0.0;
            int elementCount = matrix.Rows * matrix.Columns;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    sum += matrix.MatrixArray[i, j];
                }
            }
            return sum / elementCount;
        }
    }
}
