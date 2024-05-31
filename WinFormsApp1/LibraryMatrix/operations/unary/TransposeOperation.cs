using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class TransposeOperation : IMatrixOperation<IMatrix>
    {
        public IMatrix Execute(IMatrix matrix)
        {
            int transposedRows = matrix.Columns;
            int transposedCols = matrix.Rows;
            double[,] transposedMatrixArray = new double[transposedRows, transposedCols];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                transposedMatrixArray[j, i] = value;
            });

            return new Matrix(transposedRows, transposedCols, transposedMatrixArray);
        }
    }
}
