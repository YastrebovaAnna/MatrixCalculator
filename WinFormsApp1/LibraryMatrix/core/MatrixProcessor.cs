
using System.Windows.Forms;

namespace LibraryMatrix.core
{
    public static class MatrixProcessor
    {
        public static double[,] GetMatrixValues(TextBoxMatrix textBoxMatrix)
        {
            if (textBoxMatrix == null)
                throw new ArgumentNullException(nameof(textBoxMatrix));

            var matrixWrapper = new TextBoxMatrixWrapper(textBoxMatrix);
            return matrixWrapper.MatrixArray;
        }

        public static void SetMatrixValues(TextBoxMatrix textBoxMatrix, double[,] matrix)
        {
            if (textBoxMatrix == null)
                MessageBoxHelper.Show($"{nameof(textBoxMatrix)}");

            if (matrix == null)
                MessageBoxHelper.Show($"{(nameof(matrix))}");

            if (!IsMatrixSizeValid(textBoxMatrix, matrix))
            {
                MessageBoxHelper.Show($"Incorrect dimensions of the matrix.");
                return;
            }

            var iterator = new MatrixIterator(new TextBoxMatrixWrapper(textBoxMatrix));

            iterator.Iterate((row, col, value) =>
            {
                textBoxMatrix.DataInputs[row, col].Text = matrix[row, col].ToString("F2");
            });
        }


        private static bool IsMatrixSizeValid(TextBoxMatrix textBoxMatrix, double[,] matrix)
        {
            return matrix.GetLength(0) == textBoxMatrix.Rows && matrix.GetLength(1) == textBoxMatrix.Columns;
        }
    }
}
