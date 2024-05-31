using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.core
{
    public static class MatrixProcessor
    {
        public static void IterateOverMatrix(int rows, int columns, Action<int, int> action)
        {
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    action(row, col);
                }
            }
        }

        public static double[,] GetMatrixValues(TextBoxMatrix textBoxMatrix)
        {
            if (textBoxMatrix == null) return null;

            double[,] values = new double[textBoxMatrix.Rows, textBoxMatrix.Columns];
            bool parsingFailed = false;

            IterateOverMatrix(textBoxMatrix.Rows, textBoxMatrix.Columns, (row, col) =>
            {
                if (!double.TryParse(textBoxMatrix.DataInputs[row, col].Text, out values[row, col]))
                {
                    parsingFailed = true;
                }
            });

            return parsingFailed ? null : values;
        }

        public static void SetMatrixValues(TextBoxMatrix textBoxMatrix, double[,] matrix)
        {
            if (!IsMatrixSizeValid(textBoxMatrix, matrix))
            {
                ErrorHandler.ShowErrorMessage("Invalid matrix dimensions.");
                return;
            }

            IterateOverMatrix(textBoxMatrix.Rows, textBoxMatrix.Columns, (row, col) =>
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
