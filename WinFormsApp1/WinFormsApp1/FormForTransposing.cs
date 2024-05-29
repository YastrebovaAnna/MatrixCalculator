using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using LibraryMatrix;
using LibraryMatrix.core;
using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace CalcMatrix
{
    public partial class FormForTransposing : Form
    {
        private TextBoxMatrix numbers1;
        private IMatrix matrixs;
        private string explanation = "";

        private List<Label> resultLabels = new List<Label>();
        public TextBoxMatrix resultTextBoxMatrix;
        public EventHandler buttonDisplayTextBox_TextChanged { get; private set; }
        public EventHandler MatrixTextBox_TextChanged { get; private set; }

        public FormForTransposing()
        {
            InitializeComponent();
        }

        private void FormForTransposing_Load(object sender, EventArgs e)
        {

        }

        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDownRowsMatrix.Value;
            int cols = (int)numericUpDownColMatrix.Value;
            numbers1 = CreateAndDisplayMatrix(rows, cols, 80, 270);
        }
        private TextBoxMatrix CreateAndDisplayMatrix(int rows, int cols, int startX, int startY)
        {
            IDataInputFactory dataInputFactory = new WinFormDataInputFactory();
            TextBoxMatrix matrix = new TextBoxMatrix(rows, cols, startX, startY, dataInputFactory);
            AddMatrixToForm(matrix);
            return matrix;
        }

        private void AddMatrixToForm(TextBoxMatrix matrix)
        {
            foreach (IDataInput dataInput in matrix.DataInputs)
            {
                var textBox = ((WinFormTextBox)dataInput).GetTextBox();
                Controls.Add(textBox);
                textBox.TextChanged += MatrixTextBox_TextChanged;
            }
        }

        private void buttonTranspositionMatrix_Click_1(object sender, EventArgs e)
        {
            RemoveResultLabels();
            RemoveResultTextBoxes();
            CalculateMatrix();
        }

        private void CalculateMatrix()
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues == null)
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rows = numbers1.Rows;
            int cols = numbers1.Columns;
            IMatrix matrix = new Matrix(rows, cols, matrixValues);

            if (checkBoxTransp.Checked)
            {
                matrixs = TransposableMatrixOperations.Transpose(matrix);
            }
            else if (checkBoxInvers.Checked)
            {
                HandleMatrixInversion(matrix);
            }
            else if (checkBoxRotate.Checked)
            {
                HandleMatrixRotation(matrix);
            }

            DisplayResultMatrix(matrixs);
        }

        private void HandleMatrixInversion(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
            {
                MessageBox.Show("Матриця має бути квадратною", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double determinant;
            if (matrix.Rows == 2 && matrix.Columns == 2)
            {
                determinant = MatrixOperationDetermContext.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
            }
            else
            {
                determinant = MatrixOperationDetermContext.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
            }

            AddResultLabel("Детермінант: " + determinant.ToString());

            if (determinant == 0)
            {
                MessageBox.Show("Детермінант дорівнює 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            matrixs = TransposableMatrixOperations.Invert(matrix);
        }

      
        private void HandleMatrixRotation(IMatrix matrix)
        {
            if (checkBoxSpinsFor.Checked)
                matrixs = TransposableMatrixOperations.RotateClockwise(matrix);
            else
                matrixs = TransposableMatrixOperations.RotateCounterClockwise(matrix);
        }

        private void DisplayResultMatrix(IMatrix resultMatrix)
        {
            if (resultMatrix == null)
            {
                MessageBox.Show("Результуюча матриця пуста.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[,] resultMatrixArray = resultMatrix.MatrixArray;
            int resultRows = resultMatrix.Rows;
            int resultCols = resultMatrix.Columns;

            if (resultTextBoxMatrix != null)
            {
                foreach (var textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
                {
                    Controls.Remove(textBox);
                    textBox.Dispose();
                }
            }

            resultTextBoxMatrix = CreateAndDisplayMatrix(resultRows, resultCols, 750, 500);
            MatrixProcessor.SetMatrixValues(resultTextBoxMatrix, resultMatrixArray);
            foreach (TextBox textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
            {
                textBox.ReadOnly = true;
            }
        }

        private void AddResultLabel(string explanation)
        {
            Label label = new Label
            {
                Text = explanation,
                AutoSize = true,
                Location = new Point(100, 500)
            };
            Controls.Add(label);
            resultLabels.Add(label);
        }

        private void RemoveResultLabels()
        {
            foreach (Label label in resultLabels)
            {
                Controls.Remove(label);
                label.Dispose();
            }

            resultLabels.Clear();
        }

        private void RemoveResultTextBoxes()
        {
            foreach (Control control in Controls.OfType<Control>().ToList())
            {
                if (control is TextBox textBox && textBox.ReadOnly)
                {
                    Controls.Remove(textBox);
                    textBox.Dispose();
                }
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (numbers1 != null)
            {
                foreach (var dataInput in numbers1.DataInputs)
                {
                    var textBox = ((WinFormTextBox)dataInput).GetTextBox();
                    if (textBox.Parent == this)
                    {
                        Controls.Remove(textBox);
                        textBox.Dispose();
                    }
                }
            }
        }
    }
}
