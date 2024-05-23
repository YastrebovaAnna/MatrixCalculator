using LibraryMatrix;
using LibraryMatrix.core;
using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using System.Data;

namespace WinFormsApp1
{
    public partial class FormForArithmetic : Form
    {
        public TextBoxMatrix numbers1;
        public TextBoxMatrix numbers2;
        public TextBoxMatrix resultTextBoxMatrix;
        public MatrixArithmeticOp resultMatrix;
        double[,] resultMatrixArray;
        private EventHandler MatrixTextBox_TextChanged;
        private List<TextBoxMatrix> displayedMatrices = new List<TextBoxMatrix>();
        public TextBoxMatrix textBoxMatrix1 { get; private set; }

        public FormForArithmetic()
        {
            InitializeComponent();
        }
        private void FormForArithmetic_Load(object sender, EventArgs e)
        {
            comboBoxChooseOp.SelectedIndex = 0;
        }
        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            numbers1 = CreateAndDisplayMatrix((int)numericUpDownRowsFirstMatrix.Value, (int)numericUpDownColFirstMatrix.Value, 80, 240, true);

        }

        private void buttonDisplaySecondMatrix_Click(object sender, EventArgs e)
        {
            numbers2 = CreateAndDisplayMatrix((int)numericUpDownRowsSecondMatrix.Value, (int)numericUpDownColSecondMatrix.Value, 840, 240, false);

        }

        private TextBoxMatrix CreateAndDisplayMatrix(int rows, int cols, int startX, int startY, bool isFirstMatrix)
        {
            IDataInputFactory dataInputFactory = new WinFormDataInputFactory();
            TextBoxMatrix matrix = new TextBoxMatrix(rows, cols, startX, startY, dataInputFactory);
            AddMatrixToForm(matrix, isFirstMatrix);
            return matrix;
        }

        private void AddMatrixToForm(TextBoxMatrix matrix, bool isFirstMatrix)
        {
            foreach (var dataInput in matrix.DataInputs)
            {
                var textBox = ((WinFormTextBox)dataInput).GetTextBox();
                Controls.Add(textBox);
                textBox.TextChanged += MatrixTextBox_TextChanged;
            }

            AdjustButtons(matrix, isFirstMatrix);
        }
        private void AdjustButtons(TextBoxMatrix matrix, bool isFirstMatrix)
        {
            var lastTextBox = ((WinFormTextBox)matrix.GetLastDataInput()).GetTextBox();
            if (lastTextBox != null)
            {
                int newY = lastTextBox.Location.Y + lastTextBox.Height + 10;

                if (isFirstMatrix)
                {
                    SetLeftButtonPositions(newY);
                }
                else
                {
                    SetRightButtonPositions(newY);
                }
            }
        }

        private void SetLeftButtonPositions(int newY)
        {
            buttonMatrixPow.Location = new Point(buttonMatrixPow.Location.X, newY);
            textBoxForExponent.Location = new Point(buttonMatrixPow.Location.X + buttonMatrixPow.Width + 0, newY);

            buttonMultSklyar.Location = new Point(buttonMultSklyar.Location.X, newY + buttonMatrixPow.Height + 10);
            textBoxForSkalyar.Location = new Point(textBoxForSkalyar.Location.X, newY + textBoxForExponent.Height + 10);

            buttonExpMatrix.Location = new Point(buttonExpMatrix.Location.X, newY + buttonMatrixPow.Height + buttonMultSklyar.Height + 20);
            buttonLogMatrix.Location = new Point(buttonLogMatrix.Location.X, buttonExpMatrix.Location.Y + buttonExpMatrix.Height + 10);
            buttonSinMatrix.Location = new Point(buttonSinMatrix.Location.X, buttonLogMatrix.Location.Y + buttonLogMatrix.Height + 10);
            buttonCosMatrix.Location = new Point(buttonCosMatrix.Location.X, buttonSinMatrix.Location.Y + buttonSinMatrix.Height + 10);
            buttonTangMatrix.Location = new Point(buttonTangMatrix.Location.X, buttonCosMatrix.Location.Y + buttonCosMatrix.Height + 10);
        }

        private void SetRightButtonPositions(int newY)
        {
            buttonSecondMatrixPow.Location = new Point(buttonSecondMatrixPow.Location.X, newY);
            textBoxForSecondExponent.Location = new Point(buttonSecondMatrixPow.Location.X + buttonSecondMatrixPow.Width + 0, newY);

            buttonSecondMultSklyar.Location = new Point(buttonSecondMultSklyar.Location.X, newY + buttonSecondMatrixPow.Height + 10);
            textBoxForSecondSkalyar.Location = new Point(textBoxForSecondSkalyar.Location.X, newY + textBoxForSecondExponent.Height + 10);

            buttonExpSecondMatrix.Location = new Point(buttonExpSecondMatrix.Location.X, newY + buttonSecondMatrixPow.Height + buttonSecondMultSklyar.Height + 20);
            buttonLogSecondMatrix.Location = new Point(buttonLogSecondMatrix.Location.X, buttonExpSecondMatrix.Location.Y + buttonExpSecondMatrix.Height + 10);
            buttonSinSecondMatrix.Location = new Point(buttonSinSecondMatrix.Location.X, buttonLogSecondMatrix.Location.Y + buttonLogSecondMatrix.Height + 10);
            buttonCosSecondMatrix.Location = new Point(buttonCosSecondMatrix.Location.X, buttonSinSecondMatrix.Location.Y + buttonSinSecondMatrix.Height + 10);
            buttonTangSecondMatrix.Location = new Point(buttonTangSecondMatrix.Location.X, buttonCosSecondMatrix.Location.Y + buttonCosSecondMatrix.Height + 10);
        }

        private void buttonSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues1 != null && matrixValues2 != null)
            {
                int rows1 = numbers1.Rows;
                int cols1 = numbers1.Columns;
                int rows2 = numbers2.Rows;
                int cols2 = numbers2.Columns;
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp matrix2 = new MatrixArithmeticOp(rows2, cols2, matrixValues2);

                if (comboBoxChooseOp.SelectedIndex == 0)
                {
                    resultMatrix = PerformMatrixAddition(matrix1, matrix2);
                }
                else if (comboBoxChooseOp.SelectedIndex == 1)
                {
                    resultMatrix = PerformMatrixSubtraction(matrix1, matrix2);
                }
                else if (comboBoxChooseOp.SelectedIndex == 2)
                {
                    resultMatrix = PerformMatrixMultiplication(matrix1, matrix2);
                }
                else if (comboBoxChooseOp.SelectedIndex == 3)
                {
                    CompareMatrices(matrix1, matrix2);
                    return;
                }

                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private MatrixArithmeticOp PerformMatrixAddition(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                MessageBox.Show("Дві матриці можуть бути додані, якщо вони мають однаковий розмір", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return matrix1 + matrix2;
        }

        private MatrixArithmeticOp PerformMatrixSubtraction(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
            {
                MessageBox.Show("Віднімання матриць виконується лише за умови, якщо вони однакового розміру", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return matrix1 - matrix2;
        }

        private MatrixArithmeticOp PerformMatrixMultiplication(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            if (matrix1.Columns != matrix2.Rows)
            {
                MessageBox.Show("Дві матриці можуть бути помножені, якщо кількість стовпців першої матриці співпадає з кількістю рядків другої матриці", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }
            return matrix1 * matrix2;
        }

        private void CompareMatrices(MatrixArithmeticOp matrix1, MatrixArithmeticOp matrix2)
        {
            if (matrix1 == matrix2)
            {
                MessageBox.Show("Матриці рівні", "Перевірка матриць на рівність", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Матриці не рівні", "Перевірка матриць на рівність", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DisplayResultMatrix()
        {
            double[,] resultMatrixArray = resultMatrix.MatrixArray;

            if (resultTextBoxMatrix != null)
            {
                foreach (TextBox textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
                {
                    Controls.Remove(textBox);
                }
            }

            resultTextBoxMatrix = new TextBoxMatrix(
                resultMatrix.Rows,
                resultMatrix.Columns,
                buttonTangMatrix.Location.X,
                buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70,
                new WinFormDataInputFactory()
            );

            AddMatrixToForm(resultTextBoxMatrix, false);

            MatrixProcessor.SetMatrixValues(resultTextBoxMatrix, resultMatrixArray);

            foreach (TextBox textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
            {
                textBox.ReadOnly = true;
            }

            AdjustResultMatrixLayout();
        }

        private void AdjustResultMatrixLayout()
        {
            int leftMargin = ((WinFormTextBox)resultTextBoxMatrix.DataInputs[0, 0]).GetTextBox().Left;
            for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
            {
                for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                {
                    ((WinFormTextBox)resultTextBoxMatrix.DataInputs[i, j]).GetTextBox().Left = ((WinFormTextBox)resultTextBoxMatrix.DataInputs[i, j - 1]).GetTextBox().Right + 10;
                }
            }
        }
        private void buttonMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            int exponent = GetExponentValue(textBoxForExponent);
            if (matrixValues1 != null && exponent >= 0)
            {
                resultMatrix = PerformMatrixExponentiation(matrixValues1, exponent);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private int GetExponentValue(TextBox exponentTextBox)
        {
            if (!string.IsNullOrEmpty(exponentTextBox.Text) && int.TryParse(exponentTextBox.Text, out int exponent))
            {
                return exponent;
            }
            MessageBox.Show("Введіть значення для показника степеня", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return -1;
        }
        private MatrixArithmeticOp PerformMatrixExponentiation(double[,] matrixValues, int exponent)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix ^ exponent;
        }
        private void buttonMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            double scalar = GetScalarValue(textBoxForSkalyar);
            if (matrixValues1 != null && scalar != double.MinValue)
            {
                resultMatrix = PerformMatrixScalarMultiplication(matrixValues1, scalar);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private double GetScalarValue(TextBox scalarTextBox)
        {
            if (!string.IsNullOrEmpty(scalarTextBox.Text) && double.TryParse(scalarTextBox.Text, out double scalar))
            {
                return scalar;
            }
            MessageBox.Show("Введіть значення скаляра", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return double.MinValue;
        }

        private MatrixArithmeticOp PerformMatrixScalarMultiplication(double[,] matrixValues, double scalar)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix * scalar;
        }
        private void buttonSecondMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            int exponent = GetExponentValue(textBoxForSecondExponent);
            if (matrixValues2 != null && exponent >= 0)
            {
                resultMatrix = PerformMatrixExponentiation(matrixValues2, exponent);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonSecondMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            double scalar = GetScalarValue(textBoxForSecondSkalyar);
            if (matrixValues2 != null && scalar != double.MinValue)
            {
                resultMatrix = PerformMatrixScalarMultiplication(matrixValues2, scalar);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private void buttonExpMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                resultMatrix = PerformMatrixExponential(matrixValues1);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private MatrixArithmeticOp PerformMatrixExponential(double[,] matrixValues)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix.Exp();
        }
        private void buttonLogMatrix_Click(object sender, EventArgs e)
        {

            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                resultMatrix = PerformMatrixLogarithm(matrixValues1);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private MatrixArithmeticOp PerformMatrixLogarithm(double[,] matrixValues)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix.Log();
        }
        private void buttonSinMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                resultMatrix = PerformMatrixSine(matrixValues1);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private MatrixArithmeticOp PerformMatrixSine(double[,] matrixValues)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix.Sin();
        }
        private void buttonCosMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                resultMatrix = PerformMatrixCosine(matrixValues1);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private MatrixArithmeticOp PerformMatrixCosine(double[,] matrixValues)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix.Cos();
        }
        private void buttonTangMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                resultMatrix = PerformMatrixTangent(matrixValues1);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }
        private MatrixArithmeticOp PerformMatrixTangent(double[,] matrixValues)
        {
            MatrixArithmeticOp matrix = new MatrixArithmeticOp(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
            return matrix.Tan();
        }
        private void buttonExpSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                resultMatrix = PerformMatrixExponential(matrixValues2);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonLogSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                resultMatrix = PerformMatrixLogarithm(matrixValues2);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonSinSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                resultMatrix = PerformMatrixSine(matrixValues2);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonCosSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                resultMatrix = PerformMatrixCosine(matrixValues2);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonTangSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                resultMatrix = PerformMatrixTangent(matrixValues2);
                if (resultMatrix != null)
                {
                    DisplayResultMatrix();
                }
            }
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (numbers1 != null)
            {
                ClearMatrix(numbers1);
                numbers1 = null;
                ResetButtonPositions(true);
            }
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            if (numbers2 != null)
            {
                ClearMatrix(numbers2);
                numbers2 = null;
                ResetButtonPositions(false);
            }
        }
        private void ClearMatrix(TextBoxMatrix matrix)
        {
            foreach (var textBox in matrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
            {
                Controls.Remove(textBox);
                textBox.Dispose();
            }
        }

        private void ResetButtonPositions(bool isFirstMatrix)
        {
            if (isFirstMatrix)
            {
                buttonMatrixPow.Location = new Point(74, 245);
                textBoxForExponent.Location = new Point(265, 245);
                buttonMultSklyar.Location = new Point(74, 280);
                textBoxForSkalyar.Location = new Point(265, 280);
                buttonExpMatrix.Location = new Point(73, 315);
                buttonLogMatrix.Location = new Point(74, 350);
                buttonSinMatrix.Location = new Point(74, 385);
                buttonCosMatrix.Location = new Point(73, 420);
                buttonTangMatrix.Location = new Point(74, 455);
            }
            else
            {
                buttonSecondMatrixPow.Location = new Point(839, 245);
                textBoxForSecondExponent.Location = new Point(1029, 245);

                buttonSecondMultSklyar.Location = new Point(840, 283);
                textBoxForSecondSkalyar.Location = new Point(1029, 283);

                buttonExpSecondMatrix.Location = new Point(839, 318);
                buttonLogSecondMatrix.Location = new Point(840, 353);
                buttonSinSecondMatrix.Location = new Point(840, 388);
                buttonCosSecondMatrix.Location = new Point(839, 423);
                buttonTangSecondMatrix.Location = new Point(840, 458);
            }
        }
    }
}