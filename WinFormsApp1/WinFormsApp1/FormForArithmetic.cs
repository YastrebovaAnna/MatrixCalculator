using LibraryMatrix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.AxHost;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ToolTip;

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
            int rows = (int)numericUpDownRowsFirstMatrix.Value;
            int cols = (int)numericUpDownColFirstMatrix.Value;
            numbers1 = new TextBoxMatrix(rows, cols, 80, 240);
            Controls.AddRange(numbers1.GetTextBoxes().OfType<Control>().ToArray());

            foreach (TextBox textBox in numbers1.GetTextBoxes())
            {
                textBox.TextChanged += MatrixTextBox_TextChanged;
            }
            TextBox lastTextBox = numbers1.GetLastTextBox();

            if (lastTextBox != null)
            {
                int newY = lastTextBox.Location.Y + lastTextBox.Height + 10;
                buttonMatrixPow.Location = new Point(buttonMatrixPow.Location.X, newY);

                int newTextBoxForExponentY = newY;
                int newTextBoxForExponentX = buttonMatrixPow.Location.X + buttonMatrixPow.Width + 0;
                textBoxForExponent.Location = new Point(newTextBoxForExponentX, newTextBoxForExponentY);

                int newButtonMultSklyarY = newY + buttonMatrixPow.Height + 10;
                buttonMultSklyar.Location = new Point(buttonMultSklyar.Location.X, newButtonMultSklyarY);

                int newTextBoxForSkalyarY = newTextBoxForExponentY + textBoxForExponent.Height + 10;
                textBoxForSkalyar.Location = new Point(textBoxForSkalyar.Location.X, newTextBoxForSkalyarY);

                int newButtonExpMatrixY = newButtonMultSklyarY + buttonMultSklyar.Height + 10;
                buttonExpMatrix.Location = new Point(buttonExpMatrix.Location.X, newButtonExpMatrixY);

                int newButtonLogMatrixY = newButtonExpMatrixY + buttonExpMatrix.Height + 10;
                buttonLogMatrix.Location = new Point(buttonLogMatrix.Location.X, newButtonLogMatrixY);

                int newButtonSinMatrixY = newButtonLogMatrixY + buttonLogMatrix.Height + 10;
                buttonSinMatrix.Location = new Point(buttonSinMatrix.Location.X, newButtonSinMatrixY);

                int newButtonCosMatrixY = newButtonSinMatrixY + buttonSinMatrix.Height + 10;
                buttonCosMatrix.Location = new Point(buttonCosMatrix.Location.X, newButtonCosMatrixY);

                int newButtonTangMatrixY = newButtonCosMatrixY + buttonCosMatrix.Height + 10;
                buttonTangMatrix.Location = new Point(buttonTangMatrix.Location.X, newButtonTangMatrixY);
            }
        }

        private void buttonDisplaySecondMatrix_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDownRowsSecondMatrix.Value;
            int cols = (int)numericUpDownColSecondMatrix.Value;
            numbers2 = new TextBoxMatrix(rows, cols, 840, 240);
            Controls.AddRange(numbers2.GetTextBoxes().OfType<Control>().ToArray());

            foreach (TextBox textBox in numbers2.GetTextBoxes())
            {
                textBox.TextChanged += MatrixTextBox_TextChanged;
            }
            TextBox lastTextBox = numbers2.GetLastTextBox();

            if (lastTextBox != null)
            {
                int newY = lastTextBox.Location.Y + lastTextBox.Height + 10;
                buttonSecondMatrixPow.Location = new Point(buttonSecondMatrixPow.Location.X, newY);

                int newTextBoxForExponentY = newY;
                int newTextBoxForExponentX = buttonSecondMatrixPow.Location.X + buttonSecondMatrixPow.Width + 0;
                textBoxForSecondExponent.Location = new Point(newTextBoxForExponentX, newTextBoxForExponentY);

                int newButtonMultSklyarY = newY + buttonSecondMatrixPow.Height + 10;
                buttonSecondMultSklyar.Location = new Point(buttonSecondMultSklyar.Location.X, newButtonMultSklyarY);

                int newTextBoxForSkalyarY = newTextBoxForExponentY + textBoxForSecondExponent.Height + 10;
                textBoxForSecondSkalyar.Location = new Point(textBoxForSecondSkalyar.Location.X, newTextBoxForSkalyarY);

                int newButtonExpMatrixY = newButtonMultSklyarY + buttonMultSklyar.Height + 10;
                buttonExpSecondMatrix.Location = new Point(buttonExpSecondMatrix.Location.X, newButtonExpMatrixY);

                int newButtonLogMatrixY = newButtonExpMatrixY + buttonExpSecondMatrix.Height + 10;
                buttonLogSecondMatrix.Location = new Point(buttonLogSecondMatrix.Location.X, newButtonLogMatrixY);

                int newButtonSinMatrixY = newButtonLogMatrixY + buttonLogSecondMatrix.Height + 10;
                buttonSinSecondMatrix.Location = new Point(buttonSinSecondMatrix.Location.X, newButtonSinMatrixY);

                int newButtonCosMatrixY = newButtonSinMatrixY + buttonSinSecondMatrix.Height + 10;
                buttonCosSecondMatrix.Location = new Point(buttonCosSecondMatrix.Location.X, newButtonCosMatrixY);

                int newButtonTangMatrixY = newButtonCosMatrixY + buttonCosSecondMatrix.Height + 10;
                buttonTangSecondMatrix.Location = new Point(buttonTangSecondMatrix.Location.X, newButtonTangMatrixY);
            }
        }


        private void buttonSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            if (matrixValues1 != null && matrixValues2 != null)
            {
                int rows1 = numbers1.Rows;
                int cols1 = numbers1.Columns;
                int rows2 = numbers2.Rows;
                int cols2 = numbers2.Columns;
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp matrix2 = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                Label LabelComparison = new Label();
                LabelComparison.ForeColor = Color.Black;
                LabelComparison.Font = new Font("Times New Roman", 12);
                if (comboBoxChooseOp.SelectedIndex == 0)
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                    {
                        MessageBox.Show("Дві матриці можуть бути додані, якщо вони мають однаковий розмір", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        resultMatrix = matrix1 + matrix2;
                }

                else if (comboBoxChooseOp.SelectedIndex == 1)
                {
                    if (matrix1.Rows != matrix2.Rows || matrix1.Columns != matrix2.Columns)
                    {
                        MessageBox.Show("Віднімання матриць виконується лише за умови, якщо вони однакового розміру", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        resultMatrix = matrix1 - matrix2;
                }
                else if (comboBoxChooseOp.SelectedIndex == 2)
                {

                    if (matrix1.Columns != matrix2.Rows)
                    {
                        MessageBox.Show("Дві матриці можуть бути помножені, якщо кількість стовпців першої матриці співпадає з кількістю рядків другої матриці", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                        resultMatrix = matrix1 * matrix2;
                }
                else if (comboBoxChooseOp.SelectedIndex == 3)
                {

                    if (matrix1 == matrix2)
                    {
                        MessageBox.Show("Матриці рівні", "Перевірка матриць на рівність", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Матриці не рівні", "Перевірка матриць на рівність", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    return;
                }

                resultMatrixArray = resultMatrix.MatrixArray;

                if (resultTextBoxMatrix == null)
                {
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                else
                {
                    foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                    {
                        Controls.Remove(textBox);
                    }
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                    textBox.MinimumSize = new Size(60, textBox.MinimumSize.Height);
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            int exponent = 0;
            if (!string.IsNullOrEmpty(textBoxForExponent.Text))
            {
                exponent = int.Parse(textBoxForExponent.Text);
            }
            else
            {
                MessageBox.Show("Введіть значення для показника степеня", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                resultMatrix = matrix1 ^ exponent;
                resultMatrixArray = resultMatrix.MatrixArray;
                if (resultTextBoxMatrix == null)
                {
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                else
                {
                    foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                    {
                        Controls.Remove(textBox);
                    }
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            int skalyar = 0;
            if (!string.IsNullOrEmpty(textBoxForSkalyar.Text))
            {
                skalyar = int.Parse(textBoxForSkalyar.Text);
            }
            else
            {
                MessageBox.Show("Введіть значення скаляра", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                resultMatrix = matrix1 * skalyar;
                resultMatrixArray = resultMatrix.MatrixArray;
                if (resultTextBoxMatrix == null)
                {
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                else
                {
                    foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                    {
                        Controls.Remove(textBox);
                    }
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSecondMatrixPow_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            int exponent = 0;
            if (!string.IsNullOrEmpty(textBoxForSecondExponent.Text))
            {
                exponent = int.Parse(textBoxForSecondExponent.Text);
            }
            else
            {
                MessageBox.Show("Введіть значення для показника степеня", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                resultMatrix = matrix1 ^ exponent;
                resultMatrixArray = resultMatrix.MatrixArray;
                if (resultTextBoxMatrix == null)
                {
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                else
                {
                    foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                    {
                        Controls.Remove(textBox);
                    }
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSecondMultSklyar_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            double skalyar = 0;
            if (!string.IsNullOrEmpty(textBoxForSecondSkalyar.Text))
            {
                skalyar = double.Parse(textBoxForSecondSkalyar.Text);
            }
            else
            {
                MessageBox.Show("Введіть значення скаляра", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix1 = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                resultMatrix = matrix1 * skalyar;
                resultMatrixArray = resultMatrix.MatrixArray;
                if (resultTextBoxMatrix == null)
                {
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                else
                {
                    foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                    {
                        Controls.Remove(textBox);
                    }
                    resultTextBoxMatrix = new TextBoxMatrix(resultMatrix.Rows, resultMatrix.Columns, buttonTangMatrix.Location.X, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void buttonExpMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp expMatrix = matrix.Exp();
                resultMatrixArray = expMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != expMatrix.Rows || resultTextBoxMatrix.Columns != expMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(expMatrix.Rows, expMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLogMatrix_Click(object sender, EventArgs e)
        {

            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp logMatrix = matrix.Log();
                resultMatrixArray = logMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != logMatrix.Rows || resultTextBoxMatrix.Columns != logMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(logMatrix.Rows, logMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSinMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp sinMatrix = matrix.Sin();
                resultMatrixArray = sinMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != sinMatrix.Rows || resultTextBoxMatrix.Columns != sinMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(sinMatrix.Rows, sinMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCosMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp cosMatrix = matrix.Cos();
                resultMatrixArray = cosMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != cosMatrix.Rows || resultTextBoxMatrix.Columns != cosMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(cosMatrix.Rows, cosMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonTangMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            int rows1 = numbers1.Rows;
            int cols1 = numbers1.Columns;
            if (matrixValues1 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows1, cols1, matrixValues1);
                MatrixArithmeticOp tanMatrix = matrix.Tan();
                resultMatrixArray = tanMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != tanMatrix.Rows || resultTextBoxMatrix.Columns != tanMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(tanMatrix.Rows, tanMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangMatrix.Location.Y + buttonTangMatrix.Height + 70);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonExpSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                MatrixArithmeticOp expMatrix = matrix.Exp();
                resultMatrixArray = expMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != expMatrix.Rows || resultTextBoxMatrix.Columns != expMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(expMatrix.Rows, expMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonLogSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                MatrixArithmeticOp logMatrix = matrix.Log();
                resultMatrixArray = logMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != logMatrix.Rows || resultTextBoxMatrix.Columns != logMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(logMatrix.Rows, logMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonSinSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                MatrixArithmeticOp sinMatrix = matrix.Sin();
                resultMatrixArray = sinMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != sinMatrix.Rows || resultTextBoxMatrix.Columns != sinMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(sinMatrix.Rows, sinMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left =  resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonCosSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                MatrixArithmeticOp cosMatrix = matrix.Cos();
                resultMatrixArray = cosMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != cosMatrix.Rows || resultTextBoxMatrix.Columns != cosMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(cosMatrix.Rows, cosMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonTangSecondMatrix_Click(object sender, EventArgs e)
        {
            double[,] matrixValues2 = TextBoxMatrix.GetMatrixValues(numbers2);
            int rows2 = numbers2.Rows;
            int cols2 = numbers2.Columns;
            if (matrixValues2 != null)
            {
                MatrixArithmeticOp matrix = new MatrixArithmeticOp(rows2, cols2, matrixValues2);
                MatrixArithmeticOp tanMatrix = matrix.Tan();
                resultMatrixArray = tanMatrix.MatrixArray;

                if (resultTextBoxMatrix == null || resultTextBoxMatrix.Rows != tanMatrix.Rows || resultTextBoxMatrix.Columns != tanMatrix.Columns)
                {
                    if (resultTextBoxMatrix != null)
                    {
                        foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                        {
                            Controls.Remove(textBox);
                        }
                    }

                    resultTextBoxMatrix = new TextBoxMatrix(tanMatrix.Rows, tanMatrix.Columns, buttonTangMatrix.Location.X + 320, buttonTangSecondMatrix.Location.Y + buttonTangSecondMatrix.Height + 40);
                    Controls.AddRange(resultTextBoxMatrix.GetTextBoxes().OfType<Control>().ToArray());
                }

                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
                foreach (TextBox textBox in resultTextBoxMatrix.GetTextBoxes())
                {
                    textBox.ReadOnly = true;
                }

                resultTextBoxMatrix.AutoSizeTextBoxes();

                int leftMargin = resultTextBoxMatrix.GetTextBoxes()[0, 0].Left;
                for (int i = 0; i < resultTextBoxMatrix.Rows; i++)
                {
                    for (int j = 1; j < resultTextBoxMatrix.Columns; j++)
                    {
                        resultTextBoxMatrix.GetTextBoxes()[i, j].Left = resultTextBoxMatrix.GetTextBoxes()[i, j - 1].Right + 10;
                    }
                }
                resultTextBoxMatrix.SetMatrixValues(resultMatrixArray);
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (numbers1 != null)
            {
                foreach (TextBox textBox in numbers1.GetTextBoxes())
                {
                    Controls.Remove(textBox);
                    textBox.Dispose();

                }
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
        }

        private void buttonClear2_Click(object sender, EventArgs e)
        {
            if (numbers2 != null)
            {
                foreach (TextBox textBox in numbers2.GetTextBoxes())
                {
                    Controls.Remove(textBox);
                    textBox.Dispose();
                }
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




