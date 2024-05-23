using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.AxHost;

namespace LibraryMatrix.core
{
    public class TextBoxMatrix : IMatrix
    {
        public IDataInput[,] DataInputs { get; private set; }
        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public TextBoxMatrix(int rows, int columns, int startX, int startY, IDataInputFactory dataInputFactory)
        {
            Rows = rows;
            Columns = columns;
            DataInputs = new IDataInput[rows, columns];
            InitializeDataInputs(startX, startY, dataInputFactory);
        }
        private void IterateOverMatrix(Action<int, int> action)
        {
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    action(row, col);
                }
            }
        }

        private IDataInput CreateAndInitializeDataInput(IDataInputFactory dataInputFactory, int startX, int startY, int row, int col)
        {
            var dataInput = dataInputFactory.CreateDataInput();
            InitializeDataInputProperties(dataInput, startX, startY, row, col);
            return dataInput;
        }

        private void InitializeDataInputs(int startX, int startY, IDataInputFactory dataInputFactory)
        {
            IterateOverMatrix((row, col) =>
            {
                DataInputs[row, col] = CreateAndInitializeDataInput(dataInputFactory, startX, startY, row, col);
            });
        }

        private void InitializeDataInputProperties(IDataInput dataInput, int startX, int startY, int row, int col)
        {
            dataInput.Width = 60;
            dataInput.Location = new Point(startX + col * 70, startY + row * 35);
            dataInput.BackColor = Color.FromArgb(244, 245, 240);
        }

        public IDataInput GetLastDataInput()
        {
            return (Rows > 0 && Columns > 0) ? DataInputs[Rows - 1, Columns - 1] : null;
        }

        public static double[,] GetMatrixValues(TextBoxMatrix textBoxMatrix)
        {
            if (textBoxMatrix == null) return null;

            double[,] values = new double[textBoxMatrix.Rows, textBoxMatrix.Columns];
            bool parsingFailed = false;

            textBoxMatrix.IterateOverMatrix((row, col) =>
            {
                if (!double.TryParse(textBoxMatrix.DataInputs[row, col].Text, out values[row, col]))
                {
                    parsingFailed = true;
                }
            });

            return parsingFailed ? null : values;
        }

        public void SetMatrixValues(double[,] matrix)
        {
            if (!IsMatrixSizeValid(matrix))
            {
                ShowErrorMessage("Invalid matrix dimensions.");
                return;
            }

            IterateOverMatrix((row, col) =>
            {
                DataInputs[row, col].Text = matrix[row, col].ToString();
            });
        }

        public void AutoSizeDataInputs()
        {
            int maxWidth = 0, maxHeight = 0;

            IterateOverMatrix((row, col) =>
            {
                Size textSize = TextRenderer.MeasureText(DataInputs[row, col].Text, SystemFonts.DefaultFont);
                maxWidth = Math.Max(maxWidth, textSize.Width);
                maxHeight = Math.Max(maxHeight, textSize.Height);
            });

            SetDataInputSize(maxWidth, maxHeight);
        }

        private void SetDataInputSize(int width, int height)
        {
            IterateOverMatrix((row, col) =>
            {
                DataInputs[row, col].Width = width;
                DataInputs[row, col].Height = height;
            });
        }

        public void ResizeDataInputs(int newRows, int newColumns, int startX, int startY, IDataInputFactory dataInputFactory)
        {
            if (newRows == Rows && newColumns == Columns) return;

            IDataInput[,] newDataInputs = new IDataInput[newRows, newColumns];

            for (int row = 0; row < newRows; row++)
            {
                for (int col = 0; col < newColumns; col++)
                {
                    newDataInputs[row, col] = (row < Rows && col < Columns)
                        ? DataInputs[row, col]
                        : CreateAndInitializeDataInput(dataInputFactory, startX, startY, row, col);
                }
            }

            DataInputs = newDataInputs;
            Rows = newRows;
            Columns = newColumns;
        }

        public static void SetDataInputSpacing(TextBoxMatrix matrix, int spacing)
        {
            IDataInput[] dataInputs = matrix.DataInputs.Cast<IDataInput>().ToArray();
            int currentTop = 0;

            foreach (IDataInput dataInput in dataInputs)
            {
                dataInput.Width = currentTop;
                currentTop = spacing;
            }
        }
        private bool IsMatrixSizeValid(double[,] matrix)
        {
            return matrix.GetLength(0) == Rows && matrix.GetLength(1) == Columns;
        }

        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}