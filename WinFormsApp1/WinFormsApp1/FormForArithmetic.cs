using LibraryMatrix;
using LibraryMatrix.calculator;
using LibraryMatrix.core;
using LibraryMatrix.facade;
using LibraryMatrix.implementations.controls;
using LibraryMatrix.implementations.dataInputs;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.controls;
using LibraryMatrix.interfaces.dataInputs;
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
        private IControlManager<IControl> controlManager;
        private Dictionary<Control, Point> controlInitialPositionsMatrix1;
        private Dictionary<Control, Point> controlInitialPositionsMatrix2;
        public FormForArithmetic()
        {
            InitializeComponent();
            IControlManagerFactory<IControl> factory = new WinFormControlManagerFactory<IControl>();
            controlManager = factory.CreateControlManager(this);

            controlInitialPositionsMatrix1 = new Dictionary<Control, Point>
            {
                { buttonMatrixPow, buttonMatrixPow.Location },
                { textBoxForExponent, textBoxForExponent.Location },
                { buttonMultSklyar, buttonMultSklyar.Location },
                { textBoxForSkalyar, textBoxForSkalyar.Location },
                { buttonExpMatrix, buttonExpMatrix.Location },
                { buttonLogMatrix, buttonLogMatrix.Location },
                { buttonSinMatrix, buttonSinMatrix.Location },
                { buttonCosMatrix, buttonCosMatrix.Location },
                { buttonTangMatrix, buttonTangMatrix.Location }
            };

            controlInitialPositionsMatrix2 = new Dictionary<Control, Point>
            {
                { buttonSecondMatrixPow, buttonSecondMatrixPow.Location },
                { textBoxForSecondExponent, textBoxForSecondExponent.Location },
                { buttonSecondMultSklyar, buttonSecondMultSklyar.Location },
                { textBoxForSecondSkalyar, textBoxForSecondSkalyar.Location },
                { buttonExpSecondMatrix, buttonExpSecondMatrix.Location },
                { buttonLogSecondMatrix, buttonLogSecondMatrix.Location },
                { buttonSinSecondMatrix, buttonSinSecondMatrix.Location },
                { buttonCosSecondMatrix, buttonCosSecondMatrix.Location },
                { buttonTangSecondMatrix, buttonTangSecondMatrix.Location }
            };
        }
        private void FormForArithmetic_Load(object sender, EventArgs e)
        {
            comboBoxChooseOp.SelectedIndex = 0;
        }

        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            numbers1 = CreateAndDisplayMatrix((int)numericUpDownRowsFirstMatrix.Value, (int)numericUpDownColFirstMatrix.Value, 80, 240, true);
            AdjustButtons(numbers1, true);
        }

        private void buttonDisplaySecondMatrix_Click(object sender, EventArgs e)
        {
            numbers2 = CreateAndDisplayMatrix((int)numericUpDownRowsSecondMatrix.Value, (int)numericUpDownColSecondMatrix.Value, 840, 240, false);
            AdjustButtons(numbers2, false);
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
                controlManager.AddControl((IControl)dataInput);
                ((WinFormTextBox)dataInput).GetTextBox().TextChanged += MatrixTextBox_TextChanged;
            }
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
            SetButtonPositions(newY, controlInitialPositionsMatrix1);
        }

        private void SetRightButtonPositions(int newY)
        {
            SetButtonPositions(newY, controlInitialPositionsMatrix2);
        }

        private void SetButtonPositions(int newY, Dictionary<Control, Point> controlInitialPositions)
        {
            foreach (var entry in controlInitialPositions)
            {
                var control = entry.Key;
                var initialLocation = entry.Value;

                if (control == textBoxForExponent || control == textBoxForSecondExponent ||
                    control == textBoxForSkalyar || control == textBoxForSecondSkalyar)
                {
                    continue;
                }

                control.Location = new Point(initialLocation.X, newY);

                if (control == buttonMatrixPow || control == buttonSecondMatrixPow)
                {
                    if (control == buttonMatrixPow)
                        textBoxForExponent.Location = new Point(textBoxForExponent.Location.X, control.Location.Y);
                    else if (control == buttonSecondMatrixPow)
                        textBoxForSecondExponent.Location = new Point(textBoxForSecondExponent.Location.X, control.Location.Y);
                }
                else if (control == buttonMultSklyar || control == buttonSecondMultSklyar)
                {
                    if (control == buttonMultSklyar)
                        textBoxForSkalyar.Location = new Point(textBoxForSkalyar.Location.X, control.Location.Y);
                    else if (control == buttonSecondMultSklyar)
                        textBoxForSecondSkalyar.Location = new Point(textBoxForSecondSkalyar.Location.X, control.Location.Y);
                }

                newY += control.Height + 10;
            }
        }



        private void DisplayResultMatrix(IMatrix resultMatrix)
        {
            double[,] resultMatrixArray = resultMatrix.MatrixArray;

            if (resultTextBoxMatrix != null)
            {
                controlManager.ClearControls(resultTextBoxMatrix.DataInputs.Cast<IControl>());
            }

            var lastButton = buttonTangMatrix.Location.Y > buttonTangSecondMatrix.Location.Y ? buttonTangMatrix : buttonTangSecondMatrix;
            resultTextBoxMatrix = CreateAndDisplayMatrix(resultMatrix.Rows, resultMatrix.Columns, lastButton.Location.X, lastButton.Location.Y + lastButton.Height + 70, false);

            MatrixProcessor.SetMatrixValues(resultTextBoxMatrix, resultMatrixArray);

            foreach (TextBox textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
            {
                textBox.ReadOnly = true;
            }
        }

        private void buttonSol_Click(object sender, EventArgs e)
        {
            ExecuteMatrixOperation((matrix1, matrix2) =>
            {
                switch (comboBoxChooseOp.SelectedIndex)
                {
                    case 0: return MatrixFacade.Add(matrix1, matrix2);
                    case 1: return MatrixFacade.Subtract(matrix1, matrix2);
                    case 2: return MatrixFacade.Multiply(matrix1, matrix2);
                    case 3:
                        var result = MatrixFacade.Equality(matrix1, matrix2);
                        ShowComparisonResult(result);
                        return null;
                    case 4:
                        result = MatrixFacade.Inequality(matrix1, matrix2);
                        ShowComparisonResult(result);
                        return null;
                    default: return null;
                }
            });
        }

        private void ShowComparisonResult(IMatrix result)
        {
            MessageBox.Show(result.MatrixArray[0, 0] == 1.0 ? "Matrices are equal" : "Matrices are not equal", "Comparison Result", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonMatrixPow_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, textBoxForExponent, (matrix, param) => MatrixFacade.Power(matrix, param));
        }

        private void buttonSecondMatrixPow_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, textBoxForSecondExponent, (matrix, param) => MatrixFacade.Power(matrix, param));
        }

        private void buttonMultSklyar_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, textBoxForSkalyar, (matrix, param) => MatrixFacade.MultiplyByScalar(matrix, param));
        }

        private void buttonSecondMultSklyar_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, textBoxForSecondSkalyar, (matrix, param) => MatrixFacade.MultiplyByScalar(matrix, param));
        }

        private void buttonExpMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, MatrixFacade.Exp);
        }

        private void buttonLogMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, MatrixFacade.Log);
        }

        private void buttonSinMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, MatrixFacade.Sin);
        }

        private void buttonCosMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, MatrixFacade.Cos);
        }

        private void buttonTangMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers1, MatrixFacade.Tan);
        }

        private void buttonExpSecondMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, MatrixFacade.Exp);
        }

        private void buttonLogSecondMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, MatrixFacade.Log);
        }

        private void buttonSinSecondMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, MatrixFacade.Sin);
        }

        private void buttonCosSecondMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, MatrixFacade.Cos);
        }

        private void buttonTangSecondMatrix_Click(object sender, EventArgs e)
        {
            ExecuteSingleMatrixOperation(numbers2, MatrixFacade.Tan);
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            ClearMatrix(ref numbers1, true);
            ResetButtonPositions(true);
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            ClearMatrix(ref numbers2, false);
            ResetButtonPositions(false);
        }

        private void ClearMatrix(ref TextBoxMatrix matrix, bool isFirstMatrix)
        {
            if (matrix != null)
            {
                controlManager.ClearControls(matrix.DataInputs.Cast<IControl>());
                matrix = null;
            }
        }

        private void ExecuteMatrixOperation(Func<IMatrix, IMatrix, IMatrix> operation)
        {
            double[,] matrixValues1 = MatrixProcessor.GetMatrixValues(numbers1);
            double[,] matrixValues2 = MatrixProcessor.GetMatrixValues(numbers2);

            if (matrixValues1 != null && matrixValues2 != null)
            {
                IMatrix matrix1 = new Matrix(numbers1.Rows, numbers1.Columns, matrixValues1);
                IMatrix matrix2 = new Matrix(numbers2.Rows, numbers2.Columns, matrixValues2);

                IMatrix resultMatrix = operation(matrix1, matrix2);

                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ExecuteSingleMatrixOperation(TextBoxMatrix numbers, Func<IMatrix, IMatrix> operation)
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(numbers);

            if (matrixValues != null)
            {
                IMatrix matrix = new Matrix(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
                IMatrix resultMatrix = operation(matrix);

                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private void ExecuteSingleMatrixOperation(TextBoxMatrix numbers, TextBox parameterTextBox, Func<IMatrix, double, IMatrix> operation)
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(numbers);
            double parameterValue = GetParameterValue(parameterTextBox);

            if (matrixValues != null && parameterValue >= 0)
            {
                IMatrix matrix = new Matrix(matrixValues.GetLength(0), matrixValues.GetLength(1), matrixValues);
                IMatrix resultMatrix = operation(matrix, parameterValue);

                if (resultMatrix != null)
                    DisplayResultMatrix(resultMatrix);
            }
        }

        private double GetParameterValue(TextBox parameterTextBox)
        {
            if (!string.IsNullOrEmpty(parameterTextBox.Text) && double.TryParse(parameterTextBox.Text, out double parameter))
                return parameter;

            MessageBox.Show("Введіть значення для параметра", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            return -1;
        }
        private void ResetButtonPositions(bool isFirstMatrix)
        {
            var controlInitialPositions = isFirstMatrix ? controlInitialPositionsMatrix1 : controlInitialPositionsMatrix2;

            foreach (var entry in controlInitialPositions)
            {
                entry.Key.Location = entry.Value;
            }
        }
    }
}
