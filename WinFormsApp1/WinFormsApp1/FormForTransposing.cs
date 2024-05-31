using LibraryMatrix.core;
using LibraryMatrix.facade;
using LibraryMatrix.implementations;
using LibraryMatrix.implementations.controls;
using LibraryMatrix.implementations.dataInputs;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.controls;
using LibraryMatrix.interfaces.dataInputs;
using LibraryMatrix.interfaces.labels;
using LibraryMatrix.operations.determinant;

namespace CalcMatrix
{
    public partial class FormForTransposing : Form
    {
        private TextBoxMatrix numbers1;
        private IMatrix matrixs;
        private readonly ILabelService labelService;
        private IControlManager<IControl> controlManager;
        public TextBoxMatrix resultTextBoxMatrix;
        public EventHandler MatrixTextBox_TextChanged { get; private set; }

        public FormForTransposing()
        {
            InitializeComponent();
            IControlManagerFactory<IControl> factory = new WinFormControlManagerFactory<IControl>();
            controlManager = factory.CreateControlManager(this);
            IUIFactory uiFactory = new WinFormsUIFactory();
            labelService = uiFactory.CreateLabelService();
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
            labelService.ClearResultLabels(this);
            controlManager.RemoveReadOnlyControls();
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
                matrixs = MatrixFacade.Transpose(matrix);
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
                determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
            }
            else
            {
                determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
            }

            labelService.AddResultLabel(this, "Детермінант: " + determinant.ToString(), 100, 500);

            matrixs = MatrixFacade.Invert(matrix);
        }


        private void HandleMatrixRotation(IMatrix matrix)
        {
            if (checkBoxSpinsFor.Checked)
                matrixs = MatrixFacade.RotateClockwise(matrix);
            else
                matrixs = MatrixFacade.RotateCounterClockwise(matrix);
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
                controlManager.ClearControls(resultTextBoxMatrix.DataInputs.Cast<IControl>());
            }

            resultTextBoxMatrix = CreateAndDisplayMatrix(resultRows, resultCols, 750, 500);
            MatrixProcessor.SetMatrixValues(resultTextBoxMatrix, resultMatrixArray);
            foreach (TextBox textBox in resultTextBoxMatrix.DataInputs.Cast<WinFormTextBox>().Select(wft => wft.GetTextBox()))
            {
                textBox.ReadOnly = true;
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            if (numbers1 != null)
            {
                controlManager.ClearControls(numbers1.DataInputs.Cast<IControl>());
                numbers1 = null;
            }
        }
    }
}
