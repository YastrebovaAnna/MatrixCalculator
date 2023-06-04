﻿using LibraryMatrix;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using Label = System.Windows.Forms.Label;

namespace CalcMatrix
{
    public partial class FormDetermCharactNumb : Form
    {
        public TextBoxMatrix numbers1;

        private DetermAndCharact matrix;

        List<Label> resultLabels = new List<Label>();

        int explanationMargin = 20;
        int labelX = 80;
        int labelWidth = 350;
        int currentY = 400;
        public FormDetermCharactNumb()
        {
            InitializeComponent();
        }

        private void buttonDisplayTextBox_Click(object sender, EventArgs e)
        {
            int rows = (int)numericUpDownRowsMatrix.Value;
            int cols = (int)numericUpDownColMatrix.Value;
            numbers1 = new TextBoxMatrix(rows, cols, 80, 250);
            Controls.AddRange(numbers1.GetTextBoxes().OfType<Control>().ToArray());
        }
        private void buttonDetermSol_Click(object sender, EventArgs e)
        {
            double[,] matrixValues1 = TextBoxMatrix.GetMatrixValues(numbers1);
            if (matrixValues1 != null)
            {
                int rows1 = numbers1.Rows;
                int cols1 = numbers1.Columns;
                DetermAndCharact matrix = new DetermAndCharact(rows1, cols1, matrixValues1);
                ClearResultLabels();
                if (checkBoxDeterm.Checked)
                {
                    if ((int)numericUpDownRowsMatrix.Value == 1 && (int)numericUpDownColMatrix.Value == 1 || (int)numericUpDownRowsMatrix.Value == 2 && (int)numericUpDownColMatrix.Value == 2)
                    {
                        (double Determinant, string explanation) = matrix.CalculateDeterminant();
                        AddResultLabel("Детермінант: " + Determinant.ToString(), explanation);
                    }

                    if ((int)numericUpDownRowsMatrix.Value == 3 && (int)numericUpDownColMatrix.Value == 3)
                    {
                        if (radioButtonTriangle.Checked)
                        {
                            (double Determinant, string explanation) = matrix.CalculateDeterminantTriangleMethod();
                            AddResultLabel("Детермінант: " + Determinant.ToString(), explanation);
                        }
                        else if (radioButtonSar.Checked)
                        {
                            (double Determinant, string explanation) = matrix.CalculateDeterminantSarrus();
                            AddResultLabel("Детермінант: " + Determinant.ToString(), explanation);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Для виконання цієї дії матриця має бути розміром 3*3", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    if (radioButtonRoz.Checked)
                    {
                        double Determinant = matrix.CalculateDeterminantGauss();
                        AddResultLabel($"Детермінант: " + Determinant.ToString());
                    }
                }

                if (checkBoxRank.Checked)
                {
                    (int rank, string explanation) = matrix.CalculateRank();
                    AddResultLabel("Ранг: " + rank.ToString(), explanation);
                }

                if (checkBoxShall.Checked)
                {
                    (double Trace, string explanation) = matrix.CalculateTrace();
                    AddResultLabel($"Слід матриці: " + Trace.ToString(), explanation);
                }

                if (checkBoxMinelem.Checked)
                {
                    matrix.FindMinimumElement();
                    double minimumElement = matrix.MinimumElement;
                    AddResultLabel($"Мінімальний елемент: {minimumElement}");
                }

                if (checkBoxMaxElem.Checked)
                {
                    matrix.FindMaximumElement();
                    double maximumElement = matrix.MaximumElement;
                    AddResultLabel($"Максимальний елемент: {maximumElement}");
                }
                if (checkBoxNorm.Checked)
                {
                    matrix.MatrixNormal();
                    double normal = matrix.MatrixNorm;
                    AddResultLabel($"Норма матриці: {normal}");
                }
                if (checkBoxAverage.Checked)
                {
                    matrix.Average();
                    double average = matrix.AverageElem;
                    AddResultLabel($"Середня значення: {average}");
                }
                if (checkBoxSum.Checked)
                {
                    matrix.SummElem();
                    double sum = matrix.SummElemMatrix;
                    AddResultLabel($"Сумма елементів: {sum}");
                }
                if (checkBoxProd.Checked)
                {
                    matrix.MultElem();
                    double mult = matrix.MultElemMatrix;
                    AddResultLabel($"Добуток елементів: {mult}");
                }
            }
            else
            {
                MessageBox.Show("Не правильно введені дані, перевірте та повторіть спробу ще раз!", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        public void AddResultLabel(string text, string explanation = "")
        {
            Label labelResult = new Label();
            labelResult.Font = new Font("Times New Roman", 12);
            labelResult.AutoSize = true;
            labelResult.Text = text;
            labelResult.Location = new Point(800, resultLabels.Count * 20 + 300);
            resultLabels.Add(labelResult);
            this.Controls.Add(labelResult);

            if (!string.IsNullOrEmpty(explanation))
            {
                Label labelExplanation = new Label();
                labelExplanation.AutoSize = true;
                labelExplanation.TextAlign = ContentAlignment.TopLeft;
                labelExplanation.Location = new Point(labelX, resultLabels.Count * 40 + 450);
                labelExplanation.Width = labelWidth;
                labelExplanation.Font = new Font("Times New Roman", 12);
                labelExplanation.Text = explanation;
                resultLabels.Add(labelExplanation);
                this.Controls.Add(labelExplanation);
            }
        }
        private void ClearResultLabels()
        {
            if (resultLabels != null)
            {
                foreach (Label label in resultLabels)
                {
                    this.Controls.Remove(label);
                    label.Dispose();
                }
            }

            resultLabels = new List<Label>();
        }
        private void FormDetermCharactNumb_Load(object sender, EventArgs e)
        {

        }

        private void buttonClear1_Click(object sender, EventArgs e)
        {
            if (numbers1 != null)
            {
                foreach (System.Windows.Forms.TextBox textBox in numbers1.GetTextBoxes())
                {
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