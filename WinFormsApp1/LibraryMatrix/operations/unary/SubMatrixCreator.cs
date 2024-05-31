
namespace LibraryMatrix.operations.unary
{
    public class SubMatrixCreator
    {
        public double[,] CreateSubMatrix(double[,] matrix, int excludingRow, int excludingCol)
        {
            int n = matrix.GetLength(0);
            double[,] result = new double[n - 1, n - 1];
            int r = 0;
            for (int i = 0; i < n; i++)
            {
                if (i == excludingRow)
                    continue;

                int c = 0;
                for (int j = 0; j < n; j++)
                {
                    if (j == excludingCol)
                        continue;

                    result[r, c] = matrix[i, j];
                    c++;
                }
                r++;
            }

            return result;
        }
    }
}
