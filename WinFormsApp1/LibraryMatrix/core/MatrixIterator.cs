using LibraryMatrix.interfaces;

namespace LibraryMatrix.core
{
    public class MatrixIterator : IIterator
    {
        private readonly IMatrix _matrix;

        public MatrixIterator(IMatrix matrix)
        {
            _matrix = matrix;
        }

        public void Iterate(Action<int, int, double> action)
        {
            for (int i = 0; i < _matrix.Rows; i++)
            {
                for (int j = 0; j < _matrix.Columns; j++)
                {
                    action(i, j, _matrix.MatrixArray[i, j]);
                }
            }
        }

        public void Iterate(Action<int, int, double, double> action, IMatrix otherMatrix)
        {
            if (_matrix.Rows != otherMatrix.Rows || _matrix.Columns != otherMatrix.Columns)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for iteration.");
            }

            for (int i = 0; i < _matrix.Rows; i++)
            {
                for (int j = 0; j < _matrix.Columns; j++)
                {
                    action(i, j, _matrix.MatrixArray[i, j], otherMatrix.MatrixArray[i, j]);
                }
            }
        }
    }
}
