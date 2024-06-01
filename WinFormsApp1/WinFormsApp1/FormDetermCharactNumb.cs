using LibraryMatrix.core;
using LibraryMatrix.facade;
using LibraryMatrix.implementations.controls;
using LibraryMatrix.implementations.dataInputs;
using LibraryMatrix.implementations.labels;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.controls;
using LibraryMatrix.interfaces.dataInputs;
using LibraryMatrix.interfaces.labels;
using LibraryMatrix.operations.determinant;

namespace CalcMatrix
{
    public partial class FormDetermCharactNumb : Form
    {
        private IControlManager<IControl> controlManager;
        public TextBoxMatrix textBoxMatrix;
        private readonly ILabelService labelService;
        public FormDetermCharactNumb()
        {
            InitializeComponent();
            IControlManagerFactory<IControl> factory = new WinFormControlManagerFactory<IControl>();
            controlManager = factory.CreateControlManager(this);
            labelService = new WinFormsLabelService();
            MessageBoxHelper.ShowMessage = message => MessageBox.Show(message);
        }

        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            try
            {
                int rows = (int)numericUpDownRowsMatrix.Value;
                int cols = (int)numericUpDownColMatrix.Value;

                IDataInputFactory dataInputFactory = new WinFormDataInputFactory();
                textBoxMatrix = new TextBoxMatrix(rows, cols, 80, 250, dataInputFactory);

                foreach (var dataInput in textBoxMatrix.DataInputs)
                {
                    controlManager.AddControl((IControl)dataInput);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error when creating the matrix: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonDetermSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(textBoxMatrix);
            if (matrixValues == null)
            {
                MessageBox.Show("The data entered is incorrect, please check and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            int rows = textBoxMatrix.Rows;
            int cols = textBoxMatrix.Columns;
            IMatrix matrix = new Matrix(rows, cols, matrixValues);
            labelService.ClearResultLabels(this);

            double determinant = 0.0;
            if (checkBoxDeterm.Checked)
            {
                bool isSmallMatrix = (rows == 1 && cols == 1) || (rows == 2 && cols == 2);
                bool isThreeByThreeMatrix = rows == 3 && cols == 3;

                if (isSmallMatrix || isThreeByThreeMatrix)
                {
                    if (isThreeByThreeMatrix)
                    {
                        if (radioButtonTriangle.Checked)
                        {
                            determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                        }
                        else if (radioButtonSar.Checked)
                        {
                            determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantSarrus());
                        }
                        else if (radioButtonRoz.Checked)
                        {
                            determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
                        }
                    }
                    else
                    {
                        determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                    }
                }
                else
                {
                    determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
                }

                labelService.AddResultLabel(this, "Determinant: " + determinant.ToString(), 800, 300);
            }
            CalculateAndDisplayMetrics(matrix);
        }
        private void CalculateAndDisplayMetrics(IMatrix matrix)
        {
            var metrics = new (CheckBox, Func<IMatrix, double>, string)[]
            {
                (checkBoxRank, m => MatrixFacade.CalculateRank(m), "Rank: "),
                (checkBoxShall, m => MatrixFacade.CalculateTrace(m), "Trace matrix: "),
                (checkBoxMinelem, m => MatrixFacade.FindMinimumElement(m), "Minimal element: "),
                (checkBoxMaxElem, m => MatrixFacade.FindMaximumElement(m), "Maximum element: "),
                (checkBoxNorm, m => MatrixFacade.CalculateMatrixNorm(m), "Matrix norm: "),
                (checkBoxAverage, m => MatrixFacade.CalculateAverage(m), "Average value: "),
                (checkBoxSum, m => MatrixFacade.CalculateSum(m), "Sum of elements: "),
                (checkBoxProd, m => MatrixFacade.CalculateProduct(m), "Product of elements: ")
            };

            foreach (var (checkBox, calculation, label) in metrics)
            {
                if (checkBox.Checked)
                {
                    var result = calculation(matrix);
                    labelService.AddResultLabel(this, $"{label} {result}", 800, 300);
                }
            }
        }
        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (textBoxMatrix != null)
            {
                controlManager.ClearControls(textBoxMatrix.DataInputs.Cast<IControl>());
                textBoxMatrix = null;
            }
        }                                               
    }
}
