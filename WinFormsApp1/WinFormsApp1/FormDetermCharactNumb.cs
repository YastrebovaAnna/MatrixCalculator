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
            CreateAndDisplayTextBoxMatrix((int)numericUpDownRowsMatrix.Value, (int)numericUpDownColMatrix.Value);
        }
        private void CreateAndDisplayTextBoxMatrix(int rows, int cols)
        {
            try
            {
                IDataInputFactory dataInputFactory = new WinFormDataInputFactory();
                textBoxMatrix = new TextBoxMatrix(rows, cols, FormConstantsDigital.TextBoxMatrixX, FormConstantsDigital.TextBoxMatrixY, dataInputFactory);

                foreach (var dataInput in textBoxMatrix.DataInputs)
                {
                    controlManager.AddControl((IControl)dataInput);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(string.Format(FormConstantsString.MatrixCreationErrorMessage, ex.Message), FormConstantsString.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void buttonDetermSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(textBoxMatrix);
            if (matrixValues == null)
            {
                MessageBox.Show(FormConstantsString.IncorrectDataMessage, FormConstantsString.ErrorMessageTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            IMatrix matrix = new Matrix(textBoxMatrix.Rows, textBoxMatrix.Columns, matrixValues);
            labelService.ClearResultLabels(this);
            CalculateAndDisplayResults(matrix);
        }
        private void CalculateAndDisplayResults(IMatrix matrix)
        {
            if (checkBoxDeterm.Checked)
            {
                double determinant = CalculateDeterminant(matrix);
                labelService.AddResultLabel(this, $"{FormConstantsString.DeterminantLabelPrefix}{determinant}", FormConstantsDigital.ResultLabelX, FormConstantsDigital.ResultLabelY);
            }

            CalculateAndDisplayMetrics(matrix);
        }

        private double CalculateDeterminant(IMatrix matrix)
        {
            if (IsSmallOrThreeByThreeMatrix(matrix))
            {
                if (matrix.Rows == 3)
                {
                    if (radioButtonTriangle.Checked)
                    {
                        return MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                    }
                    else if (radioButtonSar.Checked)
                    {
                        return MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantSarrus());
                    }
                    else if (radioButtonRoz.Checked)
                    {
                        return MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
                    }
                }
                else
                {
                    return MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                }
            }
            else
            {
                return MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
            }

            return 0.0;
        }

        private bool IsSmallOrThreeByThreeMatrix(IMatrix matrix)
        {
            return (matrix.Rows == 1 && matrix.Columns == 1) || (matrix.Rows == 2 && matrix.Columns == 2) || (matrix.Rows == 3 && matrix.Columns == 3);
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
                    Double result = calculation(matrix);
                    labelService.AddResultLabel(this, $"{label} {result}", FormConstantsDigital.ResultLabelX, FormConstantsDigital.ResultLabelY);
                }
            }
        }
        private void buttonClear1_Click(object sender, EventArgs e)
        {
            ClearMatrixControls();
        }

        private void ClearMatrixControls()
        {
            if (textBoxMatrix != null)
            {
                controlManager.ClearControls(textBoxMatrix.DataInputs.Cast<IControl>());
                textBoxMatrix = null;
            }
        }
    }
}
