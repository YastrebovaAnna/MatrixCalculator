using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class CalculateRank : IMatrixOperation<int>
    {
        public int Execute(IMatrix matrix)
        {
            double[,] tempMatrix = (double[,])matrix.MatrixArray.Clone();
            int rows = matrix.Rows;
            int cols = matrix.Columns;
            int rank = cols;

            for (int row = 0; row < rank; row++)
            {
                if (tempMatrix[row, row] != 0)
                {
                    for (int col = 0; col < rows; col++)
                    {
                        if (col != row)
                        {
                            double mult = tempMatrix[col, row] / tempMatrix[row, row];
                            for (int i = 0; i < rank; i++)
                                tempMatrix[col, i] -= mult * tempMatrix[row, i];
                        }
                    }
                }
                else
                {
                    bool reduce = true;
                    for (int i = row + 1; i < rows; i++)
                    {
                        if (tempMatrix[i, row] != 0)
                        {
                            SwapRows(tempMatrix, row, i, rank);
                            reduce = false;
                            break;
                        }
                    }

                    if (reduce)
                    {
                        rank--;
                        for (int i = 0; i < rows; i++)
                            tempMatrix[i, row] = tempMatrix[i, rank];
                    }
                    row--;
                }
            }
            return rank;
        }

        private void SwapRows(double[,] matrix, int row1, int row2, int colCount)
        {
            for (int i = 0; i < colCount; i++)
            {
                double temp = matrix[row1, i];
                matrix[row1, i] = matrix[row2, i];
                matrix[row2, i] = temp;
            }
        }
    }
}
