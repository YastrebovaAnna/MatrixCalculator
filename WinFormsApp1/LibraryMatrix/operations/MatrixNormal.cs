using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class MatrixNormal : IMatrixOperation<double>
    {
        public double Execute(IMatrix matrix)
        {
            double norm = 0.0;
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    norm += matrix.MatrixArray[i, j] * matrix.MatrixArray[i, j];
                }
            }
            return Math.Sqrt(norm);
        }
    }
}
