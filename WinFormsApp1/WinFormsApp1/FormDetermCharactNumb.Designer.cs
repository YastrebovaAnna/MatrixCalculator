namespace CalcMatrix
{
    partial class FormDetermCharactNumb
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDetermCharactNumb));
            buttonDisplayTextBox = new Button();
            pictureBox1 = new PictureBox();
            labelcolumns = new Label();
            labelrows = new Label();
            labelMatrixA = new Label();
            numericUpDownRowsMatrix = new NumericUpDown();
            numericUpDownColMatrix = new NumericUpDown();
            buttonDetermSol = new Button();
            checkBoxDeterm = new CheckBox();
            checkBoxRank = new CheckBox();
            checkBoxShall = new CheckBox();
            checkBoxMinelem = new CheckBox();
            checkBoxMaxElem = new CheckBox();
            radioButtonTriangle = new RadioButton();
            radioButtonSar = new RadioButton();
            radioButtonRoz = new RadioButton();
            checkBoxNorm = new CheckBox();
            buttonClear1 = new Button();
            label1 = new Label();
            label2 = new Label();
            checkBoxSum = new CheckBox();
            checkBoxProd = new CheckBox();
            checkBoxAverage = new CheckBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColMatrix).BeginInit();
            SuspendLayout();
            // 
            // buttonDisplayTextBox
            // 
            buttonDisplayTextBox.FlatAppearance.BorderSize = 0;
            buttonDisplayTextBox.FlatStyle = FlatStyle.Flat;
            buttonDisplayTextBox.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDisplayTextBox.Location = new Point(28, 197);
            buttonDisplayTextBox.Name = "buttonDisplayTextBox";
            buttonDisplayTextBox.Size = new Size(110, 36);
            buttonDisplayTextBox.TabIndex = 20;
            buttonDisplayTextBox.Text = "Output";
            buttonDisplayTextBox.UseVisualStyleBackColor = true;
            buttonDisplayTextBox.Click += buttonDisplayTextBox_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(217, 204, 195);
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(157, 157);
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
            labelcolumns.Location = new Point(167, 120);
            labelcolumns.Name = "labelcolumns";
            labelcolumns.Size = new Size(103, 27);
            labelcolumns.TabIndex = 18;
            labelcolumns.Text = "Columns:";
            // 
            // labelrows
            // 
            labelrows.AutoSize = true;
            labelrows.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelrows.ForeColor = SystemColors.ActiveCaptionText;
            labelrows.Location = new Point(72, 120);
            labelrows.Name = "labelrows";
            labelrows.Size = new Size(66, 27);
            labelrows.TabIndex = 17;
            labelrows.Text = "Rows";
            // 
            // labelMatrixA
            // 
            labelMatrixA.AutoSize = true;
            labelMatrixA.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrixA.ForeColor = SystemColors.ActiveCaptionText;
            labelMatrixA.Location = new Point(72, 80);
            labelMatrixA.Name = "labelMatrixA";
            labelMatrixA.Size = new Size(105, 27);
            labelMatrixA.TabIndex = 16;
            labelMatrixA.Text = "Matrix A:";
            // 
            // numericUpDownRowsMatrix
            // 
            numericUpDownRowsMatrix.BackColor = Color.FromArgb(217, 204, 195);
            numericUpDownRowsMatrix.BorderStyle = BorderStyle.None;
            numericUpDownRowsMatrix.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRowsMatrix.ForeColor = SystemColors.ActiveCaptionText;
            numericUpDownRowsMatrix.Location = new Point(99, 155);
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
            numericUpDownColMatrix.Location = new Point(202, 157);
            numericUpDownColMatrix.Maximum = new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownColMatrix.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownColMatrix.Name = "numericUpDownColMatrix";
            numericUpDownColMatrix.Size = new Size(38, 26);
            numericUpDownColMatrix.TabIndex = 14;
            numericUpDownColMatrix.TextAlign = HorizontalAlignment.Center;
            numericUpDownColMatrix.Value = new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // buttonDetermSol
            // 
            buttonDetermSol.FlatAppearance.BorderSize = 0;
            buttonDetermSol.FlatStyle = FlatStyle.Flat;
            buttonDetermSol.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDetermSol.Location = new Point(396, 221);
            buttonDetermSol.Margin = new Padding(3, 4, 3, 4);
            buttonDetermSol.Name = "buttonDetermSol";
            buttonDetermSol.Size = new Size(194, 56);
            buttonDetermSol.TabIndex = 21;
            buttonDetermSol.Text = "Calculate:";
            buttonDetermSol.UseVisualStyleBackColor = true;
            buttonDetermSol.Click += buttonDetermSol_Click;
            // 
            // checkBoxDeterm
            // 
            checkBoxDeterm.AutoSize = true;
            checkBoxDeterm.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxDeterm.Location = new Point(417, 76);
            checkBoxDeterm.Name = "checkBoxDeterm";
            checkBoxDeterm.Size = new Size(154, 31);
            checkBoxDeterm.TabIndex = 23;
            checkBoxDeterm.Text = "Determinant";
            checkBoxDeterm.UseVisualStyleBackColor = true;
            // 
            // checkBoxRank
            // 
            checkBoxRank.AutoSize = true;
            checkBoxRank.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxRank.Location = new Point(1088, 76);
            checkBoxRank.Name = "checkBoxRank";
            checkBoxRank.Size = new Size(85, 31);
            checkBoxRank.TabIndex = 24;
            checkBoxRank.Text = "Rank";
            checkBoxRank.UseVisualStyleBackColor = true;
            // 
            // checkBoxShall
            // 
            checkBoxShall.AutoSize = true;
            checkBoxShall.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxShall.Location = new Point(1088, 115);
            checkBoxShall.Name = "checkBoxShall";
            checkBoxShall.Size = new Size(221, 31);
            checkBoxShall.TabIndex = 25;
            checkBoxShall.Text = "Trace of the Matrix";
            checkBoxShall.UseVisualStyleBackColor = true;
            // 
            // checkBoxMinelem
            // 
            checkBoxMinelem.AutoSize = true;
            checkBoxMinelem.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxMinelem.Location = new Point(729, 76);
            checkBoxMinelem.Name = "checkBoxMinelem";
            checkBoxMinelem.Size = new Size(196, 31);
            checkBoxMinelem.TabIndex = 26;
            checkBoxMinelem.Text = "Minimal element";
            checkBoxMinelem.UseVisualStyleBackColor = true;
            // 
            // checkBoxMaxElem
            // 
            checkBoxMaxElem.AutoSize = true;
            checkBoxMaxElem.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxMaxElem.Location = new Point(729, 116);
            checkBoxMaxElem.Name = "checkBoxMaxElem";
            checkBoxMaxElem.Size = new Size(214, 31);
            checkBoxMaxElem.TabIndex = 27;
            checkBoxMaxElem.Text = "Maximum element";
            checkBoxMaxElem.UseVisualStyleBackColor = true;
            // 
            // radioButtonTriangle
            // 
            radioButtonTriangle.AutoSize = true;
            radioButtonTriangle.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonTriangle.Location = new Point(441, 130);
            radioButtonTriangle.Name = "radioButtonTriangle";
            radioButtonTriangle.Size = new Size(162, 26);
            radioButtonTriangle.TabIndex = 28;
            radioButtonTriangle.TabStop = true;
            radioButtonTriangle.Text = "The triangle rule";
            radioButtonTriangle.UseVisualStyleBackColor = true;
            // 
            // radioButtonSar
            // 
            radioButtonSar.AutoSize = true;
            radioButtonSar.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonSar.Location = new Point(441, 159);
            radioButtonSar.Name = "radioButtonSar";
            radioButtonSar.Size = new Size(122, 26);
            radioButtonSar.TabIndex = 29;
            radioButtonSar.TabStop = true;
            radioButtonSar.Text = "Sarrus' rule";
            radioButtonSar.UseVisualStyleBackColor = true;
            // 
            // radioButtonRoz
            // 
            radioButtonRoz.AutoSize = true;
            radioButtonRoz.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            radioButtonRoz.Location = new Point(441, 188);
            radioButtonRoz.Name = "radioButtonRoz";
            radioButtonRoz.Size = new Size(277, 26);
            radioButtonRoz.TabIndex = 30;
            radioButtonRoz.TabStop = true;
            radioButtonRoz.Text = "According to the Gauss method";
            radioButtonRoz.UseVisualStyleBackColor = true;
            // 
            // checkBoxNorm
            // 
            checkBoxNorm.AutoSize = true;
            checkBoxNorm.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxNorm.Location = new Point(729, 153);
            checkBoxNorm.Name = "checkBoxNorm";
            checkBoxNorm.Size = new Size(155, 31);
            checkBoxNorm.TabIndex = 31;
            checkBoxNorm.Text = "Matrix norm";
            checkBoxNorm.UseVisualStyleBackColor = true;
            // 
            // buttonClear1
            // 
            buttonClear1.FlatAppearance.BorderSize = 0;
            buttonClear1.FlatStyle = FlatStyle.Flat;
            buttonClear1.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear1.Location = new Point(202, 197);
            buttonClear1.Name = "buttonClear1";
            buttonClear1.Size = new Size(131, 36);
            buttonClear1.TabIndex = 39;
            buttonClear1.Text = "Delete";
            buttonClear1.UseVisualStyleBackColor = true;
            buttonClear1.Click += buttonClear1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(585, 84);
            label1.Name = "label1";
            label1.Size = new Size(64, 17);
            label1.TabIndex = 40;
            label1.Text = "(1*1/2*2)";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Times New Roman", 9F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(441, 110);
            label2.Name = "label2";
            label2.Size = new Size(102, 17);
            label2.TabIndex = 41;
            label2.Text = "Larger matrices";
            // 
            // checkBoxSum
            // 
            checkBoxSum.AutoSize = true;
            checkBoxSum.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxSum.Location = new Point(729, 190);
            checkBoxSum.Name = "checkBoxSum";
            checkBoxSum.Size = new Size(193, 31);
            checkBoxSum.TabIndex = 42;
            checkBoxSum.Text = "Sum of elements";
            checkBoxSum.UseVisualStyleBackColor = true;
            // 
            // checkBoxProd
            // 
            checkBoxProd.AutoSize = true;
            checkBoxProd.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxProd.Location = new Point(1088, 152);
            checkBoxProd.Name = "checkBoxProd";
            checkBoxProd.Size = new Size(227, 31);
            checkBoxProd.TabIndex = 43;
            checkBoxProd.Text = "Product of elements";
            checkBoxProd.UseVisualStyleBackColor = true;
            // 
            // checkBoxAverage
            // 
            checkBoxAverage.AutoSize = true;
            checkBoxAverage.Font = new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            checkBoxAverage.Location = new Point(1088, 190);
            checkBoxAverage.Name = "checkBoxAverage";
            checkBoxAverage.Size = new Size(171, 31);
            checkBoxAverage.TabIndex = 44;
            checkBoxAverage.Text = "Average value";
            checkBoxAverage.UseVisualStyleBackColor = true;
            // 
            // FormDetermCharactNumb
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoScroll = true;
            BackColor = Color.FromArgb(217, 204, 195);
            ClientSize = new Size(1357, 636);
            Controls.Add(checkBoxAverage);
            Controls.Add(checkBoxProd);
            Controls.Add(checkBoxSum);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(buttonClear1);
            Controls.Add(checkBoxNorm);
            Controls.Add(radioButtonRoz);
            Controls.Add(radioButtonSar);
            Controls.Add(radioButtonTriangle);
            Controls.Add(checkBoxMaxElem);
            Controls.Add(checkBoxMinelem);
            Controls.Add(checkBoxShall);
            Controls.Add(checkBoxRank);
            Controls.Add(checkBoxDeterm);
            Controls.Add(buttonDetermSol);
            Controls.Add(buttonDisplayTextBox);
            Controls.Add(pictureBox1);
            Controls.Add(labelcolumns);
            Controls.Add(labelrows);
            Controls.Add(labelMatrixA);
            Controls.Add(numericUpDownRowsMatrix);
            Controls.Add(numericUpDownColMatrix);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FormDetermCharactNumb";
            Text = "FormDetermCharactNumb";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColMatrix).EndInit();
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
        private Button buttonDetermSol;
        private CheckBox checkBoxDeterm;
        private CheckBox checkBoxRank;
        private CheckBox checkBoxShall;
        private CheckBox checkBoxMinelem;
        private CheckBox checkBoxMaxElem;
        private RadioButton radioButtonTriangle;
        private RadioButton radioButtonSar;
        private RadioButton radioButtonRoz;
        private CheckBox checkBoxNorm;
        private Button buttonClear1;
        private Label label1;
        private Label label2;
        private CheckBox checkBoxSum;
        private CheckBox checkBoxProd;
        private CheckBox checkBoxAverage;
    }
}