namespace CalcMatrix
{
    partial class FormForTransposing
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForTransposing));
            buttonDisplayTextBox = new Button();
            pictureBox1 = new PictureBox();
            labelcolumns = new Label();
            labelrows = new Label();
            labelMatrixA = new Label();
            numericUpDownRowsMatrix = new NumericUpDown();
            numericUpDownColMatrix = new NumericUpDown();
            buttonTranspositionMatrix = new Button();
            checkBoxTransp = new CheckBox();
            checkBoxInvers = new CheckBox();
            checkBoxRotate = new CheckBox();
            checkBoxSpinsFor = new CheckBox();
            checkBoxRotationCounter = new CheckBox();
            checkBoxSwapRows = new CheckBox();
            numericUpDownRows2Swap = new NumericUpDown();
            numericUpDownRows1Swap = new NumericUpDown();
            labelRows1 = new Label();
            labelRows2 = new Label();
            label1 = new Label();
            label2 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            checkBox1 = new CheckBox();
            buttonClear = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows2Swap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows1Swap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // buttonDisplayTextBox
            // 
            buttonDisplayTextBox.FlatAppearance.BorderSize = 0;
            buttonDisplayTextBox.FlatStyle = FlatStyle.Flat;
            buttonDisplayTextBox.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDisplayTextBox.Location = new Point(76, 208);
            buttonDisplayTextBox.Name = "buttonDisplayTextBox";
            buttonDisplayTextBox.Size = new Size(110, 32);
            buttonDisplayTextBox.TabIndex = 20;
            buttonDisplayTextBox.Text = "Вивести:";
            buttonDisplayTextBox.UseVisualStyleBackColor = true;
            buttonDisplayTextBox.Click += buttonDisplayTextBox_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(217, 204, 195);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(169, 163);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(25, 24);
            pictureBox1.TabIndex = 19;
            pictureBox1.TabStop = false;
            // 
            // labelcolumns
            // 
            labelcolumns.AutoSize = true;
            labelcolumns.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelcolumns.ForeColor = SystemColors.ActiveCaptionText;
            labelcolumns.Location = new Point(180, 125);
            labelcolumns.Name = "labelcolumns";
            labelcolumns.Size = new Size(99, 27);
            labelcolumns.TabIndex = 18;
            labelcolumns.Text = "Стовпці:";
            // 
            // labelrows
            // 
            labelrows.AutoSize = true;
            labelrows.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelrows.ForeColor = SystemColors.ActiveCaptionText;
            labelrows.Location = new Point(85, 125);
            labelrows.Name = "labelrows";
            labelrows.Size = new Size(79, 27);
            labelrows.TabIndex = 17;
            labelrows.Text = "Рядки:";
            // 
            // labelMatrixA
            // 
            labelMatrixA.AutoSize = true;
            labelMatrixA.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrixA.ForeColor = SystemColors.ActiveCaptionText;
            labelMatrixA.Location = new Point(85, 85);
            labelMatrixA.Name = "labelMatrixA";
            labelMatrixA.Size = new Size(131, 27);
            labelMatrixA.TabIndex = 16;
            labelMatrixA.Text = "Матриця А:";
            // 
            // numericUpDownRowsMatrix
            // 
            numericUpDownRowsMatrix.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDownRowsMatrix.BorderStyle = BorderStyle.None;
            numericUpDownRowsMatrix.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRowsMatrix.ForeColor = SystemColors.ActiveCaptionText;
            numericUpDownRowsMatrix.Location = new Point(112, 161);
            numericUpDownRowsMatrix.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownRowsMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRowsMatrix.Name = "numericUpDownRowsMatrix";
            numericUpDownRowsMatrix.Size = new Size(38, 26);
            numericUpDownRowsMatrix.TabIndex = 15;
            numericUpDownRowsMatrix.TextAlign = HorizontalAlignment.Center;
            numericUpDownRowsMatrix.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // numericUpDownColMatrix
            // 
            numericUpDownColMatrix.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDownColMatrix.BorderStyle = BorderStyle.None;
            numericUpDownColMatrix.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownColMatrix.ForeColor = SystemColors.ActiveCaptionText;
            numericUpDownColMatrix.Location = new Point(214, 163);
            numericUpDownColMatrix.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownColMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownColMatrix.Name = "numericUpDownColMatrix";
            numericUpDownColMatrix.Size = new Size(38, 26);
            numericUpDownColMatrix.TabIndex = 14;
            numericUpDownColMatrix.TextAlign = HorizontalAlignment.Center;
            numericUpDownColMatrix.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // buttonTranspositionMatrix
            // 
            buttonTranspositionMatrix.FlatAppearance.BorderSize = 0;
            buttonTranspositionMatrix.FlatStyle = FlatStyle.Flat;
            buttonTranspositionMatrix.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTranspositionMatrix.Location = new Point(772, 361);
            buttonTranspositionMatrix.Name = "buttonTranspositionMatrix";
            buttonTranspositionMatrix.Size = new Size(194, 36);
            buttonTranspositionMatrix.TabIndex = 21;
            buttonTranspositionMatrix.Text = "Обрахувати:";
            buttonTranspositionMatrix.UseVisualStyleBackColor = true;
            buttonTranspositionMatrix.Click += buttonTranspositionMatrix_Click_1;
            // 
            // checkBoxTransp
            // 
            checkBoxTransp.AutoSize = true;
            checkBoxTransp.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxTransp.Location = new Point(569, 82);
            checkBoxTransp.Name = "checkBoxTransp";
            checkBoxTransp.Size = new Size(269, 30);
            checkBoxTransp.TabIndex = 25;
            checkBoxTransp.Text = "Транспонована матриця";
            checkBoxTransp.UseVisualStyleBackColor = true;
            // 
            // checkBoxInvers
            // 
            checkBoxInvers.AutoSize = true;
            checkBoxInvers.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxInvers.Location = new Point(569, 128);
            checkBoxInvers.Name = "checkBoxInvers";
            checkBoxInvers.Size = new Size(216, 30);
            checkBoxInvers.TabIndex = 26;
            checkBoxInvers.Text = "Обернена матриця";
            checkBoxInvers.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotate
            // 
            checkBoxRotate.AutoSize = true;
            checkBoxRotate.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxRotate.Location = new Point(954, 85);
            checkBoxRotate.Name = "checkBoxRotate";
            checkBoxRotate.Size = new Size(229, 31);
            checkBoxRotate.TabIndex = 31;
            checkBoxRotate.Text = "Обертання матриці";
            checkBoxRotate.UseVisualStyleBackColor = true;
            // 
            // checkBoxSpinsFor
            // 
            checkBoxSpinsFor.AutoSize = true;
            checkBoxSpinsFor.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSpinsFor.Location = new Point(986, 149);
            checkBoxSpinsFor.Name = "checkBoxSpinsFor";
            checkBoxSpinsFor.Size = new Size(263, 26);
            checkBoxSpinsFor.TabIndex = 32;
            checkBoxSpinsFor.Text = "За годинниковою стрілкою";
            checkBoxSpinsFor.UseVisualStyleBackColor = true;
            // 
            // checkBoxRotationCounter
            // 
            checkBoxRotationCounter.AutoSize = true;
            checkBoxRotationCounter.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxRotationCounter.Location = new Point(986, 117);
            checkBoxRotationCounter.Name = "checkBoxRotationCounter";
            checkBoxRotationCounter.Size = new Size(262, 26);
            checkBoxRotationCounter.TabIndex = 33;
            checkBoxRotationCounter.Text = "Проти годинникої стрілки ";
            checkBoxRotationCounter.UseVisualStyleBackColor = true;
            // 
            // checkBoxSwapRows
            // 
            checkBoxSwapRows.AutoSize = true;
            checkBoxSwapRows.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSwapRows.Location = new Point(954, 191);
            checkBoxSwapRows.Name = "checkBoxSwapRows";
            checkBoxSwapRows.Size = new Size(332, 31);
            checkBoxSwapRows.TabIndex = 34;
            checkBoxSwapRows.Text = "Перестановка рядків матриці";
            checkBoxSwapRows.UseVisualStyleBackColor = true;
            // 
            // numericUpDownRows2Swap
            // 
            numericUpDownRows2Swap.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDownRows2Swap.BorderStyle = BorderStyle.None;
            numericUpDownRows2Swap.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRows2Swap.Location = new Point(1160, 249);
            numericUpDownRows2Swap.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownRows2Swap.Name = "numericUpDownRows2Swap";
            numericUpDownRows2Swap.Size = new Size(49, 24);
            numericUpDownRows2Swap.TabIndex = 36;
            // 
            // numericUpDownRows1Swap
            // 
            numericUpDownRows1Swap.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDownRows1Swap.BorderStyle = BorderStyle.None;
            numericUpDownRows1Swap.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRows1Swap.Location = new Point(1042, 249);
            numericUpDownRows1Swap.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDownRows1Swap.Name = "numericUpDownRows1Swap";
            numericUpDownRows1Swap.Size = new Size(45, 24);
            numericUpDownRows1Swap.TabIndex = 35;
            // 
            // labelRows1
            // 
            labelRows1.AutoSize = true;
            labelRows1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRows1.Location = new Point(1000, 223);
            labelRows1.Name = "labelRows1";
            labelRows1.Size = new Size(74, 22);
            labelRows1.TabIndex = 37;
            labelRows1.Text = "Рядок 1";
            // 
            // labelRows2
            // 
            labelRows2.AutoSize = true;
            labelRows2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            labelRows2.Location = new Point(1129, 223);
            labelRows2.Name = "labelRows2";
            labelRows2.Size = new Size(74, 22);
            labelRows2.TabIndex = 38;
            labelRows2.Text = "Рядок 2";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(1119, 318);
            label1.Name = "label1";
            label1.Size = new Size(105, 22);
            label1.TabIndex = 43;
            label1.Text = "Стовбець 2";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(986, 318);
            label2.Name = "label2";
            label2.Size = new Size(105, 22);
            label2.TabIndex = 42;
            label2.Text = "Стовбець 1";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDown1.BorderStyle = BorderStyle.None;
            numericUpDown1.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown1.Location = new Point(1175, 343);
            numericUpDown1.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(49, 24);
            numericUpDown1.TabIndex = 41;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDown2.BorderStyle = BorderStyle.None;
            numericUpDown2.Font = new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDown2.Location = new Point(1057, 343);
            numericUpDown2.Maximum = new decimal(new int[] { 6, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(45, 24);
            numericUpDown2.TabIndex = 40;
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBox1.Location = new Point(954, 282);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(354, 31);
            checkBox1.TabIndex = 39;
            checkBox1.Text = "Перестановка стовбців матриці";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            buttonClear.FlatAppearance.BorderSize = 0;
            buttonClear.FlatStyle = FlatStyle.Flat;
            buttonClear.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear.Location = new Point(214, 208);
            buttonClear.Name = "buttonClear";
            buttonClear.Size = new Size(124, 35);
            buttonClear.TabIndex = 45;
            buttonClear.Text = "Видалити";
            buttonClear.UseVisualStyleBackColor = true;
            buttonClear.Click += buttonClear_Click;
            // 
            // FormForTransposing
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(217, 204, 195);
            ClientSize = new Size(1371, 804);
            Controls.Add(buttonClear);
            Controls.Add(label1);
            Controls.Add(label2);
            Controls.Add(numericUpDown1);
            Controls.Add(numericUpDown2);
            Controls.Add(checkBox1);
            Controls.Add(labelRows2);
            Controls.Add(labelRows1);
            Controls.Add(numericUpDownRows2Swap);
            Controls.Add(numericUpDownRows1Swap);
            Controls.Add(checkBoxSwapRows);
            Controls.Add(checkBoxRotationCounter);
            Controls.Add(checkBoxSpinsFor);
            Controls.Add(checkBoxRotate);
            Controls.Add(checkBoxInvers);
            Controls.Add(checkBoxTransp);
            Controls.Add(buttonTranspositionMatrix);
            Controls.Add(buttonDisplayTextBox);
            Controls.Add(pictureBox1);
            Controls.Add(labelcolumns);
            Controls.Add(labelrows);
            Controls.Add(labelMatrixA);
            Controls.Add(numericUpDownRowsMatrix);
            Controls.Add(numericUpDownColMatrix);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormForTransposing";
            Text = "FormForTransposing";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows2Swap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRows1Swap).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button buttonDisplayTextBox;
        private PictureBox pictureBox1;
        private Label labelcolumns;
        private Label labelrows;
        private Label labelMatrixA;
        private NumericUpDown numericUpDownRowsMatrix;
        private NumericUpDown numericUpDownColMatrix;
        private Button buttonTranspositionMatrix;
        private CheckBox checkBoxTransp;
        private CheckBox checkBoxInvers;
        private CheckBox checkBoxRotate;
        private CheckBox checkBoxSpinsFor;
        private CheckBox checkBoxRotationCounter;
        private CheckBox checkBoxSwapRows;
        private NumericUpDown numericUpDownRows2Swap;
        private NumericUpDown numericUpDownRows1Swap;
        private Label labelRows1;
        private Label labelRows2;
        private Label label1;
        private Label label2;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private CheckBox checkBox1;
        private Button buttonClear;
    }
}