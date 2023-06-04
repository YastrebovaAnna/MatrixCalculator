using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace LibraryMatrix
{
    public class TextBoxMatrix : Matrix
    {

        public TextBox[,] TextBoxes { get; set; }
        public TextBoxMatrix(int rows, int columns, int startX, int startY) : base(rows, columns)
        {
            TextBoxes = new TextBox[rows, columns];
            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < columns; col++)
                {
                    TextBoxes[row, col] = new TextBox
                    {
                        Width = 60,
                        Location = new System.Drawing.Point(startX + col * 70, startY + row * 35),
                        BackColor = System.Drawing.Color.FromArgb(244, 245, 240)
                    };

                }
            }
        }

        public TextBox GetLastTextBox()
        {
            int rows = TextBoxes.GetLength(0);
            int cols = TextBoxes.GetLength(1);

            if (rows > 0 && cols > 0)
            {
                return TextBoxes[rows - 1, cols - 1];
            }

            return null;
        }
        public void SetTextBoxes(TextBox[,] textBoxes)
        {
            TextBoxes = textBoxes;
        }
        public TextBox[,] GetTextBoxes()
        {
            return TextBoxes;
        }

        public static double[,] GetMatrixValues(TextBoxMatrix textBoxMatrix)
        {
            if (textBoxMatrix == null)
            {
                return null;
            }

            int rows = textBoxMatrix.Rows;
            int cols = textBoxMatrix.Columns;
            double[,] values = new double[rows, cols];

            TextBox[,] textBoxes = textBoxMatrix.GetTextBoxes();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    string text = textBoxes[row, col].Text;
                    if (double.TryParse(text, out double value))
                    {
                        values[row, col] = value;
                    }
                    else
                    {
                        return null;
                    }
                }
            }

            return values;
        }

        public void SetMatrixValues(double[,] matrix)
        {
            if (matrix.GetLength(0) != Rows || matrix.GetLength(1) != Columns)
            {
                MessageBox.Show("Invalid matrix dimensions.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    TextBoxes[row, col].Text = matrix[row, col].ToString();
                }
            }
        }
        public void AutoSizeTextBoxes()
        {
            int maxWidth = 0;
            int maxHeight = 0;

            foreach (TextBox textBox in TextBoxes)
            {
                Size textSize = TextRenderer.MeasureText(textBox.Text, textBox.Font);

                maxWidth = Math.Max(maxWidth, textSize.Width);
                maxHeight = Math.Max(maxHeight, textSize.Height);
            }

            foreach (TextBox textBox in TextBoxes)
            {
                textBox.Width = maxWidth;
                textBox.Height = maxHeight;
            }
        }
        public void ResizeTextBoxes(int newRows, int newColumns, int startX, int startY)
        {
            int currentRows = TextBoxes.GetLength(0);
            int currentColumns = TextBoxes.GetLength(1);
            if (newRows == currentRows && newColumns == currentColumns)
            {
                return;
            }

            TextBox[,] newTextBoxes = new TextBox[newRows, newColumns];

            for (int row = 0; row < newRows; row++)
            {
                for (int col = 0; col < newColumns; col++)
                {
                    if (row < currentRows && col < currentColumns)
                    {
                        newTextBoxes[row, col] = TextBoxes[row, col];
                    }
                    else
                    {
                        newTextBoxes[row, col] = new TextBox
                        {
                            Width = 60,
                            Location = new System.Drawing.Point(startX + col * 70, startY + row * 35),
                            BackColor = System.Drawing.Color.FromArgb(244, 245, 240)
                        };
                    }
                }
            }

            TextBoxes = newTextBoxes;
        }
        public static void SetTextBoxSpacing(TextBoxMatrix matrix, int spacing)
        {
            TextBox[] textBoxes = matrix.GetTextBoxes().OfType<TextBox>().ToArray();
            int currentTop = 0;

            foreach (TextBox textBox in textBoxes)
            {
                textBox.Width = currentTop;
                currentTop = spacing;
            }
        }
    }
}
