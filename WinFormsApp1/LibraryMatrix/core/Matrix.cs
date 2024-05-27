using LibraryMatrix.interfaces;

namespace LibraryMatrix.core
{
    public class Matrix : IMatrix
    {
        public double[,] MatrixArray { get; private set; }

        public int Rows => MatrixArray.GetLength(0);
        public int Columns => MatrixArray.GetLength(1);

        public Matrix(int rows, int columns, double[,] matrixArray = null)
        {
            MatrixArray = matrixArray ?? new double[rows, columns];
        }
    }
}