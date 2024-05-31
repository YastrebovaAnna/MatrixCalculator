using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.rotation
{
    public class RotateCounterClockwiseOperation : IMatrixOperation<IMatrix>
    {
        public IMatrix Execute(IMatrix matrix)
        {
            double[,] rotatedMatrixArray = new double[matrix.Columns, matrix.Rows];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                rotatedMatrixArray[matrix.Columns - 1 - j, i] = value;
            });

            return new Matrix(matrix.Columns, matrix.Rows, rotatedMatrixArray);
        }
    }
}
