using LibraryMatrix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Label = System.Windows.Forms.Label;
using Matrix = LibraryMatrix.Matrix;

namespace CalcMatrix
{
    public partial class FormForTransposing : Form
    {
        public TextBoxMatrix numbers1;
        Matrix matrixs;
        string explanation = "";

        private List<Label> resultLabels = new List<Label>();

        private TextBoxMatrix resultMatrix;
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
            numbers1 = new TextBoxMatrix(rows, cols, 80, 270);
            Controls.AddRange(numbers1.GetTextBoxes().OfType<Control>().ToArray());

            foreach (TextBox textBox in numbers1.GetTextBoxes())
            {
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
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                int rows1 = numbers1.Rows;
                int cols1 = numbers1.Columns;
                TransposableMatrix matrix = new TransposableMatrix(rows1, cols1, matrixValues1);

                if (checkBoxTransp.Checked)
                {
                    matrixs = matrix.Transpose();
                }
                else if (checkBoxInvers.Checked)
                {
                    if (rows1 != cols1)
                    {
                        MessageBox.Show("Матриця має бути квадратною", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    else
                    {
                        double Determinant = matrix.CalculateDeterminantGauss();
                        if (Determinant == 0)
                        {
                            MessageBox.Show("Детермінант дорівнює 0", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        Matrix result = matrix.Invert();
                        matrixs = new TransposableMatrix(result.Rows, result.Columns, result.MatrixArray);
                        string explanation = result.Explanation;
                        AddResultLabel(explanation);
                    }
                }
                else if (checkBoxRectang.Checked)
                {
                    RemoveResultLabels();
                    RemoveResultTextBoxes();
                    TransposableMatrix result = matrix.ConvertToDiagonalForm();
                    matrixs = new TransposableMatrix(result.TriangularMatrix.GetLength(0), result.TriangularMatrix.GetLength(1), result.TriangularMatrix);
                    string explanation = result.Explanation;
                    AddResultLabel(explanation);
                    return;
                }
                else if (checkBoxTriangView.Checked)
                {
                    RemoveResultLabels();
                    RemoveResultTextBoxes();
                    TransposableMatrix result = matrix.ConvertToTriangularFormGausJordan();
                    matrixs = new TransposableMatrix(result.TriangularMatrix.GetLength(0), result.TriangularMatrix.GetLength(1), result.TriangularMatrix);
                    string explanation = result.Explanation;
                    AddResultLabel(explanation);
                    return;
                }
                else if (checkBoxLU.Checked)
                {
                    RemoveResultLabels();
                    RemoveResultTextBoxes();
                    matrix.PerformLUDecomposition();
                    double[,] matrixLArray = new double[matrix.Rows, matrix.Columns];
                    double[,] matrixUArray = new double[matrix.Rows, matrix.Columns];

                    for (int i = 0; i < matrix.Rows; i++)
                    {
                        for (int j = 0; j < matrix.Columns; j++)
                        {
                            double value = matrix.MatrixArray[i, j];
                            matrixLArray[i, j] = (i == j) ? 1.0 : 0.0;
                            matrixUArray[i, j] = (i <= j) ? value : 0.0;
                            matrixLArray[i, j] = (i <= j) ? 0.0 : value;
                        }
                    }

                    int resultRowsL = matrix.Rows;
                    int resultColsL = matrix.Columns;
                    TextBoxMatrix matrixL = new TextBoxMatrix(resultRowsL, resultColsL, 500, 500);
                    TextBox lastTextBox = matrixL.GetLastTextBox();
                    int textBoxWidth = lastTextBox.Width;
                    TextBoxMatrix matrixU = new TextBoxMatrix(resultRowsL, resultColsL, textBoxWidth + 5, 500);
                    matrixL.SetMatrixValues(matrixLArray);
                    matrixU.SetMatrixValues(matrixUArray);
                    TextBoxMatrix.SetTextBoxSpacing(matrixL, 1);
                    TextBoxMatrix.SetTextBoxSpacing(matrixU, 1);
                    Controls.AddRange(matrixL.GetTextBoxes().OfType<Control>().ToArray());
                    Controls.AddRange(matrixU.GetTextBoxes().OfType<Control>().ToArray());
                    matrixL.AutoSizeTextBoxes();
                    matrixU.AutoSizeTextBoxes();
                    matrixL.GetTextBoxes().OfType<TextBox>().ToList().ForEach(textBox => textBox.ReadOnly = true);
                    matrixU.GetTextBoxes().OfType<TextBox>().ToList().ForEach(textBox => textBox.ReadOnly = true);
                    return;
                }
                else if (checkBoxRotate.Checked)
                {
                    if (checkBoxSpinsFor.Checked)
                    {
                        RemoveResultLabels();
                        RemoveResultTextBoxes();
                        Matrix result = matrix.RotateClockwise();
                        matrixs = new TransposableMatrix(result.Rows, result.Columns, result.MatrixArray);
                    }
                    else
                    {
                        RemoveResultLabels();
                        RemoveResultTextBoxes();
                        Matrix result = matrix.RotateCounterClockwise();
                        matrixs = new TransposableMatrix(result.Rows, result.Columns, result.MatrixArray);
                    }
                }
                else if (checkBoxSwapRows.Checked)
                {
                    RemoveResultLabels();
                    RemoveResultTextBoxes();
                    int row1 = (int)numericUpDownRows1Swap.Value;
                    int row2 = (int)numericUpDownRows2Swap.Value;
                    matrix.SwapRows(row1, row2);
                    matrixs = new TransposableMatrix(matrix.Rows, matrix.Columns, matrix.MatrixArray);
                }

                RemoveResultLabels();
                RemoveResultTextBoxes();
                double[,] resultMatrixArray = matrixs.MatrixArray;
                int resultRows = matrixs.Rows;
                int resultCols = matrixs.Columns;

                resultMatrix = new TextBoxMatrix(resultRows, resultCols, 750, 500);
                resultMatrix.SetMatrixValues(resultMatrixArray);
                Controls.AddRange(resultMatrix.GetTextBoxes().OfType<Control>().ToArray());
                resultMatrix.GetTextBoxes().OfType<TextBox>().ToList().ForEach(textBox => textBox.ReadOnly = true);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void AddResultLabel(string explanation)
        {
            Label label = new Label();
            label.Text = explanation;
            label.AutoSize = true;
            label.Location = new Point(100, 500);
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
            TextBox[] textBoxes = Controls.OfType<TextBox>().ToArray();

            foreach (TextBox textBox in textBoxes)
            {
                if (textBox.ReadOnly)
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
                foreach (System.Windows.Forms.TextBox textBox in numbers1.GetTextBoxes())
                {
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
