using System;

namespace LibraryMatrix
{
    public class Matrix
    {
        public double[,] MatrixArray { get; set; }
        public int Rows { get; set; }
        public int Columns { get; set; }
        public string Explanation { get; internal set; }

        public Matrix(int rows, int cols, double[,] matrixArray)
        {
            Rows = rows;
            Columns = cols;
            MatrixArray = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    MatrixArray[i, j] = matrixArray[i, j];
                }
            }
        }
        public Matrix(int rows, int columns)
        {
            Rows=rows;
            Columns=columns;
        }
    }
}