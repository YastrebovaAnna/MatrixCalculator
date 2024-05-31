using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class RotateClockwiseOperation : IMatrixOperation<IMatrix>
    {
        public IMatrix Execute(IMatrix matrix)
        {
            double[,] rotatedMatrixArray = new double[matrix.Columns, matrix.Rows];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                rotatedMatrixArray[j, matrix.Rows - 1 - i] = value;
            });

            return new Matrix(matrix.Columns, matrix.Rows, rotatedMatrixArray);
        }
    }
}
