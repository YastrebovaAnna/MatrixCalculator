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
            MessageBoxHelper.ShowMessage = message => MessageBox.Show(message);
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
                MessageBoxHelper.Show("The data entered is incorrect, please check and try again!");
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
            double determinant;
            determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
            labelService.AddResultLabel(this, "Determinant: " + determinant.ToString(), 100, 500);

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
                return;
            }

            double[,] resultMatrixArray = resultMatrix.MatrixArray;
            int resultRows = resultMatrix.Rows;
            int resultCols = resultMatrix.Columns;

            if (resultTextBoxMatrix != null)
            {
                controlManager.ClearControls(resultTextBoxMatrix.DataInputs.Cast<IControl>());
            }

            int labelX = 750;
            int labelY = 480;
            labelService.ClearResultLabels(this);
            labelService.AddResultLabel(this, "Result", labelX, labelY);

            int matrixX = 750;
            int matrixY = labelY + 30;

            resultTextBoxMatrix = CreateAndDisplayMatrix(resultRows, resultCols, matrixX, matrixY);
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
