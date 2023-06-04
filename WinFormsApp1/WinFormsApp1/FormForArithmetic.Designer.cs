namespace WinFormsApp1
{
    partial class FormForArithmetic
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormForArithmetic));
            pictureBox2=new PictureBox();
            label2=new Label();
            label3=new Label();
            labelMatrixB=new Label();
            numericUpDownRowsSecondMatrix=new NumericUpDown();
            numericUpDownColSecondMatrix=new NumericUpDown();
            buttonDisplaySecondMatrix=new Button();
            buttonSol=new Button();
            numericUpDownColFirstMatrix=new NumericUpDown();
            numericUpDownRowsFirstMatrix=new NumericUpDown();
            buttonDisplayTextBox=new Button();
            labelrows=new Label();
            labelcolumns=new Label();
            pictureBox1=new PictureBox();
            labelMatrixA=new Label();
            buttonMatrixPow=new Button();
            buttonMultSklyar=new Button();
            textBoxForExponent=new TextBox();
            textBoxForSkalyar=new TextBox();
            textBoxForSecondSkalyar=new TextBox();
            textBoxForSecondExponent=new TextBox();
            buttonSecondMultSklyar=new Button();
            buttonSecondMatrixPow=new Button();
            comboBoxChooseOp=new ComboBox();
            buttonLogMatrix=new Button();
            buttonExpMatrix=new Button();
            buttonSinMatrix=new Button();
            buttonCosMatrix=new Button();
            buttonTangMatrix=new Button();
            buttonTangSecondMatrix=new Button();
            buttonCosSecondMatrix=new Button();
            buttonSinSecondMatrix=new Button();
            buttonLogSecondMatrix=new Button();
            buttonExpSecondMatrix=new Button();
            buttonClear1=new Button();
            buttonClear2=new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsSecondMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColSecondMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsFirstMatrix).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor=Color.FromArgb(217, 204, 195);
            pictureBox2.Image=(Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location=new Point(924, 148);
            pictureBox2.Name="pictureBox2";
            pictureBox2.Size=new Size(25, 24);
            pictureBox2.TabIndex=12;
            pictureBox2.TabStop=false;
            // 
            // label2
            // 
            label2.AutoSize=true;
            label2.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.ForeColor=SystemColors.ActiveCaptionText;
            label2.Location=new Point(937, 109);
            label2.Name="label2";
            label2.Size=new Size(99, 27);
            label2.TabIndex=11;
            label2.Text="Стовпці:";
            // 
            // label3
            // 
            label3.AutoSize=true;
            label3.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.ForeColor=SystemColors.ActiveCaptionText;
            label3.Location=new Point(839, 109);
            label3.Name="label3";
            label3.Size=new Size(79, 27);
            label3.TabIndex=10;
            label3.Text="Рядки:";
            // 
            // labelMatrixB
            // 
            labelMatrixB.AutoSize=true;
            labelMatrixB.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrixB.ForeColor=SystemColors.ActiveCaptionText;
            labelMatrixB.Location=new Point(839, 69);
            labelMatrixB.Name="labelMatrixB";
            labelMatrixB.Size=new Size(130, 27);
            labelMatrixB.TabIndex=9;
            labelMatrixB.Text="Матриця B:";
            // 
            // numericUpDownRowsSecondMatrix
            // 
            numericUpDownRowsSecondMatrix.BackColor=Color.FromArgb(217, 204, 195);
            numericUpDownRowsSecondMatrix.BorderStyle=BorderStyle.None;
            numericUpDownRowsSecondMatrix.Font=new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRowsSecondMatrix.ForeColor=SystemColors.ActiveCaptionText;
            numericUpDownRowsSecondMatrix.Location=new Point(871, 145);
            numericUpDownRowsSecondMatrix.Maximum=new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownRowsSecondMatrix.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRowsSecondMatrix.Name="numericUpDownRowsSecondMatrix";
            numericUpDownRowsSecondMatrix.Size=new Size(38, 26);
            numericUpDownRowsSecondMatrix.TabIndex=8;
            numericUpDownRowsSecondMatrix.TextAlign=HorizontalAlignment.Center;
            numericUpDownRowsSecondMatrix.Value=new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // numericUpDownColSecondMatrix
            // 
            numericUpDownColSecondMatrix.BackColor=Color.FromArgb(217, 204, 195);
            numericUpDownColSecondMatrix.BorderStyle=BorderStyle.None;
            numericUpDownColSecondMatrix.Font=new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownColSecondMatrix.ForeColor=SystemColors.ActiveCaptionText;
            numericUpDownColSecondMatrix.Location=new Point(965, 145);
            numericUpDownColSecondMatrix.Maximum=new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownColSecondMatrix.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownColSecondMatrix.Name="numericUpDownColSecondMatrix";
            numericUpDownColSecondMatrix.Size=new Size(38, 26);
            numericUpDownColSecondMatrix.TabIndex=7;
            numericUpDownColSecondMatrix.TextAlign=HorizontalAlignment.Center;
            numericUpDownColSecondMatrix.Value=new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // buttonDisplaySecondMatrix
            // 
            buttonDisplaySecondMatrix.FlatAppearance.BorderSize=0;
            buttonDisplaySecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonDisplaySecondMatrix.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDisplaySecondMatrix.Location=new Point(808, 186);
            buttonDisplaySecondMatrix.Name="buttonDisplaySecondMatrix";
            buttonDisplaySecondMatrix.Size=new Size(121, 40);
            buttonDisplaySecondMatrix.TabIndex=14;
            buttonDisplaySecondMatrix.Text="Вивести";
            buttonDisplaySecondMatrix.UseVisualStyleBackColor=true;
            buttonDisplaySecondMatrix.Click+=buttonDisplaySecondMatrix_Click;
            // 
            // buttonSol
            // 
            buttonSol.FlatStyle=FlatStyle.Flat;
            buttonSol.Font=new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSol.Location=new Point(493, 153);
            buttonSol.Name="buttonSol";
            buttonSol.Size=new Size(147, 36);
            buttonSol.TabIndex=18;
            buttonSol.Text="Розв'язати";
            buttonSol.UseVisualStyleBackColor=true;
            buttonSol.Click+=buttonSol_Click;
            // 
            // numericUpDownColFirstMatrix
            // 
            numericUpDownColFirstMatrix.BackColor=Color.FromArgb(217, 204, 195);
            numericUpDownColFirstMatrix.BorderStyle=BorderStyle.None;
            numericUpDownColFirstMatrix.Font=new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownColFirstMatrix.ForeColor=SystemColors.ActiveCaptionText;
            numericUpDownColFirstMatrix.Location=new Point(203, 148);
            numericUpDownColFirstMatrix.Maximum=new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownColFirstMatrix.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownColFirstMatrix.Name="numericUpDownColFirstMatrix";
            numericUpDownColFirstMatrix.Size=new Size(38, 26);
            numericUpDownColFirstMatrix.TabIndex=1;
            numericUpDownColFirstMatrix.TextAlign=HorizontalAlignment.Center;
            numericUpDownColFirstMatrix.Value=new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // numericUpDownRowsFirstMatrix
            // 
            numericUpDownRowsFirstMatrix.BackColor=Color.FromArgb(217, 204, 195);
            numericUpDownRowsFirstMatrix.BorderStyle=BorderStyle.None;
            numericUpDownRowsFirstMatrix.Font=new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            numericUpDownRowsFirstMatrix.ForeColor=SystemColors.ActiveCaptionText;
            numericUpDownRowsFirstMatrix.Location=new Point(101, 145);
            numericUpDownRowsFirstMatrix.Maximum=new decimal(new int[] { 7, 0, 0, 0 });
            numericUpDownRowsFirstMatrix.Minimum=new decimal(new int[] { 1, 0, 0, 0 });
            numericUpDownRowsFirstMatrix.Name="numericUpDownRowsFirstMatrix";
            numericUpDownRowsFirstMatrix.Size=new Size(38, 26);
            numericUpDownRowsFirstMatrix.TabIndex=2;
            numericUpDownRowsFirstMatrix.TextAlign=HorizontalAlignment.Center;
            numericUpDownRowsFirstMatrix.Value=new decimal(new int[] { 3, 0, 0, 0 });
            // 
            // buttonDisplayTextBox
            // 
            buttonDisplayTextBox.FlatAppearance.BorderSize=0;
            buttonDisplayTextBox.FlatStyle=FlatStyle.Flat;
            buttonDisplayTextBox.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonDisplayTextBox.Location=new Point(42, 188);
            buttonDisplayTextBox.Name="buttonDisplayTextBox";
            buttonDisplayTextBox.Size=new Size(131, 36);
            buttonDisplayTextBox.TabIndex=13;
            buttonDisplayTextBox.Text="Вивести";
            buttonDisplayTextBox.UseVisualStyleBackColor=true;
            buttonDisplayTextBox.Click+=buttonDisplayTextBox_Click;
            // 
            // labelrows
            // 
            labelrows.AutoSize=true;
            labelrows.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelrows.ForeColor=SystemColors.ActiveCaptionText;
            labelrows.Location=new Point(74, 109);
            labelrows.Name="labelrows";
            labelrows.Size=new Size(79, 27);
            labelrows.TabIndex=4;
            labelrows.Text="Рядки:";
            // 
            // labelcolumns
            // 
            labelcolumns.AutoSize=true;
            labelcolumns.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelcolumns.ForeColor=SystemColors.ActiveCaptionText;
            labelcolumns.Location=new Point(169, 109);
            labelcolumns.Name="labelcolumns";
            labelcolumns.Size=new Size(99, 27);
            labelcolumns.TabIndex=5;
            labelcolumns.Text="Стовпці:";
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor=Color.FromArgb(217, 204, 195);
            pictureBox1.Image=(Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location=new Point(159, 148);
            pictureBox1.Name="pictureBox1";
            pictureBox1.Size=new Size(25, 24);
            pictureBox1.TabIndex=6;
            pictureBox1.TabStop=false;
            // 
            // labelMatrixA
            // 
            labelMatrixA.AutoSize=true;
            labelMatrixA.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            labelMatrixA.ForeColor=SystemColors.ActiveCaptionText;
            labelMatrixA.Location=new Point(74, 69);
            labelMatrixA.Name="labelMatrixA";
            labelMatrixA.Size=new Size(131, 27);
            labelMatrixA.TabIndex=3;
            labelMatrixA.Text="Матриця А:";
            // 
            // buttonMatrixPow
            // 
            buttonMatrixPow.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonMatrixPow.FlatStyle=FlatStyle.Flat;
            buttonMatrixPow.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMatrixPow.Location=new Point(74, 245);
            buttonMatrixPow.Name="buttonMatrixPow";
            buttonMatrixPow.Size=new Size(194, 29);
            buttonMatrixPow.TabIndex=19;
            buttonMatrixPow.Text="Піднести до степеня: ";
            buttonMatrixPow.UseVisualStyleBackColor=true;
            buttonMatrixPow.Click+=buttonMatrixPow_Click;
            // 
            // buttonMultSklyar
            // 
            buttonMultSklyar.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonMultSklyar.FlatStyle=FlatStyle.Flat;
            buttonMultSklyar.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMultSklyar.Location=new Point(74, 280);
            buttonMultSklyar.Name="buttonMultSklyar";
            buttonMultSklyar.Size=new Size(194, 29);
            buttonMultSklyar.TabIndex=20;
            buttonMultSklyar.Text="Помножити на скаляр:";
            buttonMultSklyar.UseVisualStyleBackColor=true;
            buttonMultSklyar.Click+=buttonMultSklyar_Click;
            // 
            // textBoxForExponent
            // 
            textBoxForExponent.BackColor=Color.FromArgb(217, 204, 195);
            textBoxForExponent.BorderStyle=BorderStyle.FixedSingle;
            textBoxForExponent.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxForExponent.Location=new Point(265, 245);
            textBoxForExponent.Multiline=true;
            textBoxForExponent.Name="textBoxForExponent";
            textBoxForExponent.Size=new Size(50, 29);
            textBoxForExponent.TabIndex=21;
            textBoxForExponent.TextAlign=HorizontalAlignment.Center;
            // 
            // textBoxForSkalyar
            // 
            textBoxForSkalyar.BackColor=Color.FromArgb(217, 204, 195);
            textBoxForSkalyar.BorderStyle=BorderStyle.FixedSingle;
            textBoxForSkalyar.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxForSkalyar.Location=new Point(265, 280);
            textBoxForSkalyar.Multiline=true;
            textBoxForSkalyar.Name="textBoxForSkalyar";
            textBoxForSkalyar.Size=new Size(50, 29);
            textBoxForSkalyar.TabIndex=22;
            textBoxForSkalyar.TextAlign=HorizontalAlignment.Center;
            // 
            // textBoxForSecondSkalyar
            // 
            textBoxForSecondSkalyar.BackColor=Color.FromArgb(217, 204, 195);
            textBoxForSecondSkalyar.BorderStyle=BorderStyle.FixedSingle;
            textBoxForSecondSkalyar.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxForSecondSkalyar.Location=new Point(1029, 283);
            textBoxForSecondSkalyar.Multiline=true;
            textBoxForSecondSkalyar.Name="textBoxForSecondSkalyar";
            textBoxForSecondSkalyar.Size=new Size(50, 29);
            textBoxForSecondSkalyar.TabIndex=26;
            // 
            // textBoxForSecondExponent
            // 
            textBoxForSecondExponent.BackColor=Color.FromArgb(217, 204, 195);
            textBoxForSecondExponent.BorderStyle=BorderStyle.FixedSingle;
            textBoxForSecondExponent.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            textBoxForSecondExponent.Location=new Point(1029, 245);
            textBoxForSecondExponent.Multiline=true;
            textBoxForSecondExponent.Name="textBoxForSecondExponent";
            textBoxForSecondExponent.Size=new Size(50, 29);
            textBoxForSecondExponent.TabIndex=25;
            // 
            // buttonSecondMultSklyar
            // 
            buttonSecondMultSklyar.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonSecondMultSklyar.FlatStyle=FlatStyle.Flat;
            buttonSecondMultSklyar.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSecondMultSklyar.Location=new Point(840, 283);
            buttonSecondMultSklyar.Name="buttonSecondMultSklyar";
            buttonSecondMultSklyar.Size=new Size(199, 29);
            buttonSecondMultSklyar.TabIndex=24;
            buttonSecondMultSklyar.Text="Помножити на скаляр:";
            buttonSecondMultSklyar.UseVisualStyleBackColor=true;
            buttonSecondMultSklyar.Click+=buttonSecondMultSklyar_Click;
            // 
            // buttonSecondMatrixPow
            // 
            buttonSecondMatrixPow.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonSecondMatrixPow.FlatStyle=FlatStyle.Flat;
            buttonSecondMatrixPow.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSecondMatrixPow.Location=new Point(839, 245);
            buttonSecondMatrixPow.Name="buttonSecondMatrixPow";
            buttonSecondMatrixPow.Size=new Size(194, 29);
            buttonSecondMatrixPow.TabIndex=23;
            buttonSecondMatrixPow.Text="Піднести до степеня: ";
            buttonSecondMatrixPow.UseVisualStyleBackColor=true;
            buttonSecondMatrixPow.Click+=buttonSecondMatrixPow_Click;
            // 
            // comboBoxChooseOp
            // 
            comboBoxChooseOp.BackColor=Color.FromArgb(217, 204, 195);
            comboBoxChooseOp.DropDownStyle=ComboBoxStyle.DropDownList;
            comboBoxChooseOp.FlatStyle=FlatStyle.System;
            comboBoxChooseOp.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            comboBoxChooseOp.FormattingEnabled=true;
            comboBoxChooseOp.Items.AddRange(new object[] { "+", " -", " *", "== / !=" });
            comboBoxChooseOp.Location=new Point(532, 108);
            comboBoxChooseOp.Name="comboBoxChooseOp";
            comboBoxChooseOp.Size=new Size(67, 28);
            comboBoxChooseOp.TabIndex=17;
            // 
            // buttonLogMatrix
            // 
            buttonLogMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonLogMatrix.FlatStyle=FlatStyle.Flat;
            buttonLogMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogMatrix.Location=new Point(74, 350);
            buttonLogMatrix.Name="buttonLogMatrix";
            buttonLogMatrix.Size=new Size(241, 29);
            buttonLogMatrix.TabIndex=29;
            buttonLogMatrix.Text="Логарифм елементів";
            buttonLogMatrix.UseVisualStyleBackColor=true;
            buttonLogMatrix.Click+=buttonLogMatrix_Click;
            // 
            // buttonExpMatrix
            // 
            buttonExpMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonExpMatrix.FlatStyle=FlatStyle.Flat;
            buttonExpMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExpMatrix.Location=new Point(73, 315);
            buttonExpMatrix.Name="buttonExpMatrix";
            buttonExpMatrix.Size=new Size(242, 29);
            buttonExpMatrix.TabIndex=28;
            buttonExpMatrix.Text="Експонента елементів";
            buttonExpMatrix.UseVisualStyleBackColor=true;
            buttonExpMatrix.Click+=buttonExpMatrix_Click;
            // 
            // buttonSinMatrix
            // 
            buttonSinMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonSinMatrix.FlatStyle=FlatStyle.Flat;
            buttonSinMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSinMatrix.Location=new Point(74, 385);
            buttonSinMatrix.Name="buttonSinMatrix";
            buttonSinMatrix.Size=new Size(241, 29);
            buttonSinMatrix.TabIndex=30;
            buttonSinMatrix.Text="Синус елементів";
            buttonSinMatrix.UseVisualStyleBackColor=true;
            buttonSinMatrix.Click+=buttonSinMatrix_Click;
            // 
            // buttonCosMatrix
            // 
            buttonCosMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonCosMatrix.FlatStyle=FlatStyle.Flat;
            buttonCosMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCosMatrix.Location=new Point(73, 420);
            buttonCosMatrix.Name="buttonCosMatrix";
            buttonCosMatrix.Size=new Size(242, 29);
            buttonCosMatrix.TabIndex=31;
            buttonCosMatrix.Text="Косинус елементів";
            buttonCosMatrix.UseVisualStyleBackColor=true;
            buttonCosMatrix.Click+=buttonCosMatrix_Click;
            // 
            // buttonTangMatrix
            // 
            buttonTangMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonTangMatrix.FlatStyle=FlatStyle.Flat;
            buttonTangMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTangMatrix.Location=new Point(74, 455);
            buttonTangMatrix.Name="buttonTangMatrix";
            buttonTangMatrix.Size=new Size(241, 29);
            buttonTangMatrix.TabIndex=32;
            buttonTangMatrix.Text="Тангенс елементів";
            buttonTangMatrix.UseVisualStyleBackColor=true;
            buttonTangMatrix.Click+=buttonTangMatrix_Click;
            // 
            // buttonTangSecondMatrix
            // 
            buttonTangSecondMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonTangSecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonTangSecondMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonTangSecondMatrix.Location=new Point(840, 458);
            buttonTangSecondMatrix.Name="buttonTangSecondMatrix";
            buttonTangSecondMatrix.Size=new Size(239, 29);
            buttonTangSecondMatrix.TabIndex=37;
            buttonTangSecondMatrix.Text="Тангенс елементів";
            buttonTangSecondMatrix.UseVisualStyleBackColor=true;
            buttonTangSecondMatrix.Click+=buttonTangSecondMatrix_Click;
            // 
            // buttonCosSecondMatrix
            // 
            buttonCosSecondMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonCosSecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonCosSecondMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonCosSecondMatrix.Location=new Point(839, 423);
            buttonCosSecondMatrix.Name="buttonCosSecondMatrix";
            buttonCosSecondMatrix.Size=new Size(240, 29);
            buttonCosSecondMatrix.TabIndex=36;
            buttonCosSecondMatrix.Text="Косинус елементів";
            buttonCosSecondMatrix.UseVisualStyleBackColor=true;
            buttonCosSecondMatrix.Click+=buttonCosSecondMatrix_Click;
            // 
            // buttonSinSecondMatrix
            // 
            buttonSinSecondMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonSinSecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonSinSecondMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonSinSecondMatrix.Location=new Point(840, 388);
            buttonSinSecondMatrix.Name="buttonSinSecondMatrix";
            buttonSinSecondMatrix.Size=new Size(239, 29);
            buttonSinSecondMatrix.TabIndex=35;
            buttonSinSecondMatrix.Text="Синус елементів";
            buttonSinSecondMatrix.UseVisualStyleBackColor=true;
            buttonSinSecondMatrix.Click+=buttonSinSecondMatrix_Click;
            // 
            // buttonLogSecondMatrix
            // 
            buttonLogSecondMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonLogSecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonLogSecondMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonLogSecondMatrix.Location=new Point(840, 353);
            buttonLogSecondMatrix.Name="buttonLogSecondMatrix";
            buttonLogSecondMatrix.Size=new Size(239, 29);
            buttonLogSecondMatrix.TabIndex=34;
            buttonLogSecondMatrix.Text="Логарифм елементів";
            buttonLogSecondMatrix.UseVisualStyleBackColor=true;
            buttonLogSecondMatrix.Click+=buttonLogSecondMatrix_Click;
            // 
            // buttonExpSecondMatrix
            // 
            buttonExpSecondMatrix.FlatAppearance.BorderColor=Color.FromArgb(66, 73, 83);
            buttonExpSecondMatrix.FlatStyle=FlatStyle.Flat;
            buttonExpSecondMatrix.Font=new Font("Times New Roman", 10.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExpSecondMatrix.Location=new Point(839, 318);
            buttonExpSecondMatrix.Name="buttonExpSecondMatrix";
            buttonExpSecondMatrix.Size=new Size(240, 29);
            buttonExpSecondMatrix.TabIndex=33;
            buttonExpSecondMatrix.Text="Експонента елементів";
            buttonExpSecondMatrix.UseVisualStyleBackColor=true;
            buttonExpSecondMatrix.Click+=buttonExpSecondMatrix_Click;
            // 
            // buttonClear1
            // 
            buttonClear1.FlatAppearance.BorderSize=0;
            buttonClear1.FlatStyle=FlatStyle.Flat;
            buttonClear1.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear1.Location=new Point(216, 188);
            buttonClear1.Name="buttonClear1";
            buttonClear1.Size=new Size(131, 36);
            buttonClear1.TabIndex=38;
            buttonClear1.Text="Видалити";
            buttonClear1.UseVisualStyleBackColor=true;
            buttonClear1.Click+=buttonClear1_Click;
            // 
            // buttonClear2
            // 
            buttonClear2.FlatAppearance.BorderSize=0;
            buttonClear2.FlatStyle=FlatStyle.Flat;
            buttonClear2.Font=new Font("Times New Roman", 14F, FontStyle.Regular, GraphicsUnit.Point);
            buttonClear2.Location=new Point(986, 188);
            buttonClear2.Name="buttonClear2";
            buttonClear2.Size=new Size(131, 36);
            buttonClear2.TabIndex=39;
            buttonClear2.Text="Видалити";
            buttonClear2.UseVisualStyleBackColor=true;
            buttonClear2.Click+=buttonClear2_Click;
            // 
            // FormForArithmetic
            // 
            AutoScaleDimensions=new SizeF(8F, 20F);
            AutoScaleMode=AutoScaleMode.Font;
            AutoScroll=true;
            BackColor=Color.FromArgb(217, 204, 195);
            ClientSize=new Size(1357, 636);
            Controls.Add(buttonClear2);
            Controls.Add(buttonClear1);
            Controls.Add(buttonTangSecondMatrix);
            Controls.Add(buttonCosSecondMatrix);
            Controls.Add(buttonSinSecondMatrix);
            Controls.Add(buttonLogSecondMatrix);
            Controls.Add(buttonExpSecondMatrix);
            Controls.Add(buttonTangMatrix);
            Controls.Add(buttonCosMatrix);
            Controls.Add(buttonSinMatrix);
            Controls.Add(buttonLogMatrix);
            Controls.Add(buttonExpMatrix);
            Controls.Add(textBoxForSecondSkalyar);
            Controls.Add(textBoxForSecondExponent);
            Controls.Add(buttonSecondMultSklyar);
            Controls.Add(buttonSecondMatrixPow);
            Controls.Add(textBoxForSkalyar);
            Controls.Add(textBoxForExponent);
            Controls.Add(buttonMultSklyar);
            Controls.Add(buttonMatrixPow);
            Controls.Add(buttonSol);
            Controls.Add(comboBoxChooseOp);
            Controls.Add(buttonDisplaySecondMatrix);
            Controls.Add(buttonDisplayTextBox);
            Controls.Add(pictureBox2);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(labelMatrixB);
            Controls.Add(numericUpDownRowsSecondMatrix);
            Controls.Add(numericUpDownColSecondMatrix);
            Controls.Add(pictureBox1);
            Controls.Add(labelcolumns);
            Controls.Add(labelrows);
            Controls.Add(labelMatrixA);
            Controls.Add(numericUpDownRowsFirstMatrix);
            Controls.Add(numericUpDownColFirstMatrix);
            FormBorderStyle=FormBorderStyle.None;
            Name="FormForArithmetic";
            Text="FormForArithmetic";
            Load+=FormForArithmetic_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsSecondMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColSecondMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownColFirstMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDownRowsFirstMatrix).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private NumericUpDown numericUpDownRows;
        private PictureBox pictureBox2;
        private Label label2;
        private Label label3;
        private Label labelMatrixB;
        private NumericUpDown numericUpDownRowsSecondMatrix;
        private NumericUpDown numericUpDownColSecondMatrix;
        private Button buttonDisplaySecondMatrix;
        private Button buttonSol;
        private NumericUpDown numericUpDownColFirstMatrix;
        private NumericUpDown numericUpDownRowsFirstMatrix;
        private Button buttonDisplayTextBox;
        private Label labelrows;
        private Label labelcolumns;
        private PictureBox pictureBox1;
        private Label labelMatrixA;
        private Button buttonMatrixPow;
        private Button buttonMultSklyar;
        private TextBox textBoxForExponent;
        private TextBox textBoxForSkalyar;
        private TextBox textBoxForSecondSkalyar;
        private TextBox textBoxForSecondExponent;
        private Button buttonSecondMultSklyar;
        private Button buttonSecondMatrixPow;
        private ComboBox comboBoxChooseOp;
        private Button buttonLogMatrix;
        private Button buttonExpMatrix;
        private Button buttonSinMatrix;
        private Button buttonCosMatrix;
        private Button buttonTangMatrix;
        private Button buttonTangSecondMatrix;
        private Button buttonCosSecondMatrix;
        private Button buttonSinSecondMatrix;
        private Button buttonLogSecondMatrix;
        private Button buttonExpSecondMatrix;
        private Button buttonClear1;
        private Button buttonClear2;
    }
}