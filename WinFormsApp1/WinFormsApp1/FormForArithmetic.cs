using LibraryMatrix;
using LibraryMatrix.calculator;
using LibraryMatrix.core;
using LibraryMatrix.facade;
using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;
using System.Data;

namespace WinFormsApp1
{
    public partial class FormForArithmetic : Form
    {
        public TextBoxMatrix numbers1;
        public TextBoxMatrix numbers2;
        public TextBoxMatrix resultTextBoxMatrix;
        private EventHandler MatrixTextBox_TextChanged;
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

            if (isFirstMatrix || matrix != resultTextBoxMatrix)
                AdjustButtons(matrix, isFirstMatrix);
        }
        private void AdjustButtons(TextBoxMatrix matrix, bool isFirstMatrix)
        {
            var lastTextBox = ((WinFormTextBox)matrix.GetLastDataInput()).GetTextBox();
            if (lastTextBox != null)
            {
                int newY = lastTextBox.Location.Y + lastTextBox.Height + 10;

                if (isFirstMatrix)
                    SetLeftButtonPositions(newY);
                else
                    SetRightButtonPositions(newY);
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
        private void DisplayResultMatrix(IMatrix resultMatrix)
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
                IMatrix matrix1 = new Matrix(rows1, cols1, matrixValues1);
                IMatrix matrix2 = new Matrix(rows2, cols2, matrixValues2);

                IMatrix resultMatrix = null;

                if (comboBoxChooseOp.SelectedIndex == 0)
                    resultMatrix = MatrixFacade.Add(matrix1, matrix2);
                else if (comboBoxChooseOp.SelectedIndex == 1)
                    resultMatrix = MatrixFacade.Subtract(matrix1, matrix2);
                else if (comboBoxChooseOp.SelectedIndex == 2)
                    resultMatrix = MatrixFacade.Multiply(matrix1, matrix2);
                else if (comboBoxChooseOp.SelectedIndex == 3)
                {
                    resultMatrix = MatrixFacade.Equality(matrix1, matrix2);
                    MessageBox.Show(resultMatrix.MatrixArray[0, 0] == 1.0 ? "Matrices are equal" : "Matrices are not equal", "Comparison Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (comboBoxChooseOp.SelectedIndex == 4)
                {
                    resultMatrix = MatrixFacade.Inequality(matrix1, matrix2);
                    MessageBox.Show(resultMatrix.MatrixArray[0, 0] == 1.0 ? "Matrices are not equal" : "Matrices are equal", "Comparison Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
            else
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void buttonMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            int exponent = GetExponentValue(textBoxForExponent);
            if (matrixValues1 != null && exponent >= 0)
            {
                IMatrix matrix = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Power(matrix, exponent);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private int GetExponentValue(TextBox exponentTextBox)
        {
            if (!string.IsNullOrEmpty(exponentTextBox.Text) && int.TryParse(exponentTextBox.Text, out int exponent))
                return exponent;

            MessageBox.Show("Введіть значення для показника степеня", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return -1;
        }
        
        private void buttonMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            double scalar = GetScalarValue(textBoxForSkalyar);
            if (matrixValues1 != null && scalar != double.MinValue)
            {
                IMatrix matrix = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.MultiplyByScalar(matrix, scalar);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private double GetScalarValue(TextBox scalarTextBox)
        {
            if (!string.IsNullOrEmpty(scalarTextBox.Text) && double.TryParse(scalarTextBox.Text, out double scalar))
                return scalar;

            MessageBox.Show("Введіть значення скаляра", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return double.MinValue;
        }

        
        private void buttonSecondMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            int exponent = GetExponentValue(textBoxForExponent);
            if (matrixValues2 != null && exponent >= 0)
            {
                IMatrix matrix = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Power(matrix, exponent);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void buttonSecondMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            double scalar = GetScalarValue(textBoxForSkalyar);
            if (matrixValues2 != null && scalar != double.MinValue)
            {
                IMatrix matrix = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.MultiplyByScalar(matrix, scalar);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonExpMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                IMatrix matrix1 = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Exp(matrix1);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonLogMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                IMatrix matrix1 = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Log(matrix1);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonSinMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                IMatrix matrix1 = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Sin(matrix1);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonCosMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                IMatrix matrix1 = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Cos(matrix1);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonTangMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                IMatrix matrix1 = new Matrix(matrixValues1.GetLength(0), matrixValues1.GetLength(1), matrixValues1);
                IMatrix resultMatrix = MatrixFacade.Tan(matrix1);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }
        private void buttonExpSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                IMatrix matrix2 = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Exp(matrix2);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void buttonLogSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                IMatrix matrix2 = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Log(matrix2);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void buttonSinSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                IMatrix matrix2 = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Sin(matrix2);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void buttonCosSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                IMatrix matrix2 = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Cos(matrix2);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void buttonTangSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);
            if (matrixValues2 != null)
            {
                IMatrix matrix2 = new Matrix(matrixValues2.GetLength(0), matrixValues2.GetLength(1), matrixValues2);
                IMatrix resultMatrix = MatrixFacade.Tan(matrix2);
                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
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