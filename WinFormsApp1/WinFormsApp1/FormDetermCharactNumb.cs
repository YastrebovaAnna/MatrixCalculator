using LibraryMatrix;
using LibraryMatrix.core;
using LibraryMatrix.facade;
using LibraryMatrix.implementations;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;
using LibraryMatrix.operations.determinant;
using Label = System.Windows.Forms.Label;

namespace CalcMatrix
{
    public partial class FormDetermCharactNumb : Form
    {
        public TextBoxMatrix textBoxMatrix;
        private readonly ILabelService labelService;
        public FormDetermCharactNumb()
        {
            InitializeComponent();
            labelService = new WinFormsLabelService();
        }

        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDownRowsMatrix.Value;
            int cols = (int)numericUpDownColMatrix.Value;

            IDataInputFactory dataInputFactory = new WinFormDataInputFactory();
            textBoxMatrix = new TextBoxMatrix(rows, cols, 80, 250, dataInputFactory);

            foreach (var dataInput in textBoxMatrix.DataInputs)
            {
                Controls.Add(((WinFormTextBox)dataInput).GetTextBox());
            }
        }
        private void buttonDetermSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues = MatrixProcessor.GetMatrixValues(textBoxMatrix);
            if (matrixValues != null)
            {
                int rows = textBoxMatrix.Rows;
                int cols = textBoxMatrix.Columns;
                IMatrix matrix = new Matrix(rows, cols, matrixValues);
                labelService.ClearResultLabels(this);
                double determinant = 0.0;
                if (checkBoxDeterm.Checked)
                {
                    if (rows == 1 && cols == 1 || rows == 2 && cols == 2 || (rows == 3 && cols == 3))
                    {
                        if (rows == 1 && cols == 1 || rows == 2 && cols == 2)
                        {
                            determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                            labelService.AddResultLabel(this, "Детермінант: " + determinant.ToString(), 800, 300);
                        }
                        else if (rows == 3 && cols == 3)
                        {
                            if (radioButtonTriangle.Checked)
                            {
                                determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantTriangleMethod());
                                labelService.AddResultLabel(this, "Детермінант: " + determinant.ToString(), 800, 300);
                            }
                            else if (radioButtonSar.Checked)
                            {
                                determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantSarrus());
                                labelService.AddResultLabel(this, "Детермінант: " + determinant.ToString(), 800, 300);
                            }
                            else if (radioButtonRoz.Checked)
                            {
                                determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
                                labelService.AddResultLabel(this, $"Детермінант: " + determinant.ToString(), 800, 300);
                            }
                        }
                    }
                    else
                    {
                        determinant = MatrixFacade.CalculateDeterminant(matrix, new CalculateDeterminantGauss());
                        labelService.AddResultLabel(this, $"Детермінант: " + determinant.ToString(), 800, 300);
                    }
                }
                if (checkBoxRank.Checked)
                {
                    int rank = MatrixFacade.CalculateRank(matrix);
                    labelService.AddResultLabel(this, "Ранг: " + rank.ToString(), 800, 300);
                }

                if (checkBoxShall.Checked)
                {
                    double trace = MatrixFacade.CalculateTrace(matrix);
                    labelService.AddResultLabel(this, $"Слід матриці: {trace}", 800, 300);
                }

                if (checkBoxMinelem.Checked)
                {
                    double minimumElement = MatrixFacade.FindMinimumElement(matrix);
                    labelService.AddResultLabel(this, $"Мінімальний елемент: {minimumElement}", 800, 300);
                }

                if (checkBoxMaxElem.Checked)
                {
                    double maximumElement = MatrixFacade.FindMaximumElement(matrix);
                    labelService.AddResultLabel(this, $"Максимальний елемент: {maximumElement}", 800, 300);
                }

                if (checkBoxNorm.Checked)
                {
                    double normal = MatrixFacade.CalculateMatrixNorm(matrix);
                    labelService.AddResultLabel(this, $"Норма матриці: {normal}", 800, 300);
                }

                if (checkBoxAverage.Checked)
                {
                    double average = MatrixFacade.CalculateAverage(matrix);
                    labelService.AddResultLabel(this, $"Середнє значення: {average}", 800, 300);
                }

                if (checkBoxSum.Checked)
                {
                    double sum = MatrixFacade.CalculateSum(matrix);
                    labelService.AddResultLabel(this, $"Сума елементів: {sum}", 800, 300);
                }

                if (checkBoxProd.Checked)
                {
                    double product = MatrixFacade.CalculateProduct(matrix);
                    labelService.AddResultLabel(this, $"Добуток елементів: {product}", 800, 300);
                }
            }
            else
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (textBoxMatrix != null)
            {
                foreach (var dataInput in textBoxMatrix.DataInputs)
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
