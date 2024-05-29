using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class TransposeOperation : ITransposeOperation
    {
        public IMatrix Execute(IMatrix matrix)
        {
            int transposedRows = matrix.Columns;
            int transposedCols = matrix.Rows;
            double[,] transposedMatrixArray = new double[transposedRows, transposedCols];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    transposedMatrixArray[j, i] = matrix.MatrixArray[i, j];
                }
            }

            return new Matrix(transposedRows, transposedCols, transposedMatrixArray);
        }
    }
}
