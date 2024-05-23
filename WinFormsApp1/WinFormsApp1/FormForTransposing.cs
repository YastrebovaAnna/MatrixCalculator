using LibraryMatrix;
using LibraryMatrix.core;
using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using Label = System.Windows.Forms.Label;
using Matrix = LibraryMatrix.Matrix;

namespace CalcMatrix
{
    public partial class FormForTransposing : Form
    {
        private TextBoxMatrix numbers1;
        private Matrix matrixs;
        private string explanation = "";

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
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            if (matrixValues1 == null)
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            TransposableMatrix matrix = new TransposableMatrix(rows1, cols1, matrixValues1);

            if (checkBoxTransp.Checked)
            {
                matrixs = matrix.Transpose();
            }
            else if (checkBoxInvers.Checked)
            {
                HandleMatrixInversion(matrix);
            }
            else if (checkBoxRectang.Checked)
            {
                HandleRectangularConversion(matrix);
                return;
            }
            else if (checkBoxTriangView.Checked)
            {
                HandleTriangularConversion(matrix);
                return;
            }
            else if (checkBoxLU.Checked)
            {
                HandleLUDecomposition(matrix);
                return;
            }
            else if (checkBoxRotate.Checked)
            {
                HandleMatrixRotation(matrix);
            }
            else if (checkBoxSwapRows.Checked)
            {
                HandleRowSwap(matrix);
            }

            DisplayResultMatrix(matrixs);
        }
        private void HandleMatrixInversion(TransposableMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
            {
                MessageBox.Show("Матриця має бути квадратною", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double determinant = matrix.CalculateDeterminantGauss();
            if (determinant == 0)
            {
                MessageBox.Show("Детермінант дорівнює 0", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Matrix result = matrix.Invert();
            if (result == null)
            {
                MessageBox.Show("Не вдалося обчислити інверсію матриці.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            matrixs = new TransposableMatrix(result.Rows, result.Columns, result.MatrixArray);
            explanation = result.Explanation;
            AddResultLabel(explanation);
        }

        private void HandleRectangularConversion(TransposableMatrix matrix)
        {
            TransposableMatrix result = matrix.ConvertToDiagonalForm();
            matrixs = new TransposableMatrix(result.TriangularMatrix.GetLength(0), result.TriangularMatrix.GetLength(1), result.TriangularMatrix);
            explanation = result.Explanation;
            AddResultLabel(explanation);
        }

        private void HandleTriangularConversion(TransposableMatrix matrix)
        {
            TransposableMatrix result = matrix.ConvertToTriangularFormGausJordan();
            matrixs = new TransposableMatrix(result.TriangularMatrix.GetLength(0), result.TriangularMatrix.GetLength(1), result.TriangularMatrix);
            explanation = result.Explanation;
            AddResultLabel(explanation);
        }

        private void HandleLUDecomposition(TransposableMatrix matrix)
        {
            matrix.PerformLUDecomposition();
            DisplayLUDecomposition(matrix);
        }

        private void HandleMatrixRotation(TransposableMatrix matrix)
        {
            Matrix result = checkBoxSpinsFor.Checked ? matrix.RotateClockwise() : matrix.RotateCounterClockwise();
            matrixs = new TransposableMatrix(result.Rows, result.Columns, result.MatrixArray);
        }

        private void HandleRowSwap(TransposableMatrix matrix)
        {
            int row1 = (int)numericUpDownRows1Swap.Value;
            int row2 = (int)numericUpDownRows2Swap.Value;
            matrix.SwapRows(row1, row2);
            matrixs = new TransposableMatrix(matrix.Rows, matrix.Columns, matrix.MatrixArray);
        }

        private void DisplayLUDecomposition(TransposableMatrix matrix)
        {
            double[,] matrixLArray = new double[matrix.Rows, matrix.Columns];
            double[,] matrixUArray = new double[matrix.Rows, matrix.Columns];

            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    double value = matrix.MatrixArray[i, j];
                    matrixLArray[i, j] = (i == j) ? 1.0 : 0.0;
                    matrixUArray[i, j] = (i <= j) ? value : 0.0;
                    if (i > j)
                    {
                        matrixLArray[i, j] = value;
                    }
                }
            }

            int resultRowsL = matrix.Rows;
            int resultColsL = matrix.Columns;

            TextBoxMatrix matrixL = CreateAndDisplayMatrix(resultRowsL, resultColsL, 500, 500);
            TextBox lastTextBoxL = ((WinFormTextBox)matrixL.GetLastDataInput()).GetTextBox();
            int textBoxWidthL = lastTextBoxL.Width;

            TextBoxMatrix matrixU = CreateAndDisplayMatrix(resultRowsL, resultColsL, 500 + textBoxWidthL + 10, 500);

            matrixL.SetMatrixValues(matrixLArray);
            matrixU.SetMatrixValues(matrixUArray);

            matrixL.AutoSizeDataInputs();
            matrixU.AutoSizeDataInputs();

            SetReadOnly(matrixL);
            SetReadOnly(matrixU);
        }
        private void SetReadOnly(TextBoxMatrix matrix)
        {
            foreach (var dataInput in matrix.DataInputs)
            {
                ((WinFormTextBox)dataInput).GetTextBox().ReadOnly = true;
            }
        }
        private void DisplayResultMatrix(Matrix resultMatrix)
        {
            if (resultMatrix == null)
            {
                MessageBox.Show("Результуюча матриця пуста.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double[,] resultMatrixArray = resultMatrix.MatrixArray;
            int resultRows = resultMatrix.Rows;
            int resultCols = resultMatrix.Columns;

            this.resultMatrix = CreateAndDisplayMatrix(resultRows, resultCols, 750, 500);
            this.resultMatrix.SetMatrixValues(resultMatrixArray);
            SetReadOnly(this.resultMatrix);
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
