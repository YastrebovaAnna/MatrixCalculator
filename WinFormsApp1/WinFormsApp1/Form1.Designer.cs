namespace WinFormsApp1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            pnlMenu = new Panel();
            buttonExitProg = new Button();
            buttonMin = new Button();
            buttonbackpagehome = new Button();
            panelForDeter = new Panel();
            bttnMaxElem = new Button();
            bttnMinElem = new Button();
            bttnTraceOfTheMatrix = new Button();
            bttnRank = new Button();
            bttnDeterminant = new Button();
            bttnDeter = new Button();
            panelTransformSubMenu = new Panel();
            bttnInversion = new Button();
            bttnTransformMat = new Button();
            bttnTransform = new Button();
            bttnArithmeticOp = new Button();
            panel1 = new Panel();
            panelForwx = new Panel();
            panelForChildForm = new Panel();
            label1 = new Label();
            pnlMenu.SuspendLayout();
            panelForDeter.SuspendLayout();
            panelTransformSubMenu.SuspendLayout();
            panelForChildForm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMenu
            // 
            pnlMenu.AutoScroll = true;
            pnlMenu.BackColor = Color.FromArgb(141, 155, 164);
            pnlMenu.Controls.Add(buttonExitProg);
            pnlMenu.Controls.Add(buttonMin);
            pnlMenu.Controls.Add(buttonbackpagehome);
            pnlMenu.Controls.Add(panelForDeter);
            pnlMenu.Controls.Add(bttnDeter);
            pnlMenu.Controls.Add(panelTransformSubMenu);
            pnlMenu.Controls.Add(bttnTransform);
            pnlMenu.Controls.Add(bttnArithmeticOp);
            pnlMenu.Controls.Add(panel1);
            pnlMenu.Dock = DockStyle.Left;
            pnlMenu.Location = new Point(0, 0);
            pnlMenu.Margin = new Padding(3, 4, 3, 4);
            pnlMenu.Name = "pnlMenu";
            pnlMenu.Size = new Size(285, 829);
            pnlMenu.TabIndex = 0;
            pnlMenu.Paint += pnlMenu_Paint;
            // 
            // buttonExitProg
            // 
            buttonExitProg.BackColor = Color.FromArgb(141, 155, 164);
            buttonExitProg.Dock = DockStyle.Top;
            buttonExitProg.FlatAppearance.BorderSize = 0;
            buttonExitProg.FlatStyle = FlatStyle.Flat;
            buttonExitProg.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonExitProg.ForeColor = SystemColors.ActiveCaptionText;
            buttonExitProg.Image = CalcMatrix.Properties.Resources.icon_exit;
            buttonExitProg.ImageAlign = ContentAlignment.TopLeft;
            buttonExitProg.Location = new Point(0, 780);
            buttonExitProg.Margin = new Padding(0, 4, 3, 4);
            buttonExitProg.Name = "buttonExitProg";
            buttonExitProg.Padding = new Padding(10, 20, 0, 0);
            buttonExitProg.Size = new Size(264, 58);
            buttonExitProg.TabIndex = 12;
            buttonExitProg.Text = "        Вихід";
            buttonExitProg.TextAlign = ContentAlignment.MiddleLeft;
            buttonExitProg.UseVisualStyleBackColor = false;
            buttonExitProg.Click += buttonExitProg_Click;
            // 
            // buttonMin
            // 
            buttonMin.BackColor = Color.FromArgb(141, 155, 164);
            buttonMin.Dock = DockStyle.Top;
            buttonMin.FlatAppearance.BorderSize = 0;
            buttonMin.FlatStyle = FlatStyle.Flat;
            buttonMin.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonMin.ForeColor = SystemColors.ActiveCaptionText;
            buttonMin.Image = (Image)resources.GetObject("buttonMin.Image");
            buttonMin.ImageAlign = ContentAlignment.MiddleLeft;
            buttonMin.Location = new Point(0, 711);
            buttonMin.Margin = new Padding(0, 4, 3, 4);
            buttonMin.Name = "buttonMin";
            buttonMin.Padding = new Padding(10, 20, 0, 0);
            buttonMin.Size = new Size(264, 69);
            buttonMin.TabIndex = 11;
            buttonMin.Text = "        Згорнути";
            buttonMin.TextAlign = ContentAlignment.MiddleLeft;
            buttonMin.UseVisualStyleBackColor = false;
            buttonMin.Click += buttonExit_Click_1;
            // 
            // buttonbackpagehome
            // 
            buttonbackpagehome.BackColor = Color.FromArgb(141, 155, 164);
            buttonbackpagehome.Dock = DockStyle.Top;
            buttonbackpagehome.FlatAppearance.BorderSize = 0;
            buttonbackpagehome.FlatStyle = FlatStyle.Flat;
            buttonbackpagehome.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            buttonbackpagehome.ForeColor = SystemColors.ActiveCaptionText;
            buttonbackpagehome.Image = CalcMatrix.Properties.Resources.icon_homepage;
            buttonbackpagehome.ImageAlign = ContentAlignment.MiddleLeft;
            buttonbackpagehome.Location = new Point(0, 626);
            buttonbackpagehome.Margin = new Padding(0, 4, 3, 4);
            buttonbackpagehome.Name = "buttonbackpagehome";
            buttonbackpagehome.Padding = new Padding(10, 20, 0, 0);
            buttonbackpagehome.Size = new Size(264, 85);
            buttonbackpagehome.TabIndex = 10;
            buttonbackpagehome.Text = "       Повернутись на                      головну";
            buttonbackpagehome.TextAlign = ContentAlignment.MiddleLeft;
            buttonbackpagehome.UseVisualStyleBackColor = false;
            buttonbackpagehome.Click += buttonbackpagehome_Click;
            // 
            // panelForDeter
            // 
            panelForDeter.BackColor = Color.FromArgb(196, 201, 205);
            panelForDeter.Controls.Add(bttnMaxElem);
            panelForDeter.Controls.Add(bttnMinElem);
            panelForDeter.Controls.Add(bttnTraceOfTheMatrix);
            panelForDeter.Controls.Add(bttnRank);
            panelForDeter.Controls.Add(bttnDeterminant);
            panelForDeter.Dock = DockStyle.Top;
            panelForDeter.Location = new Point(0, 430);
            panelForDeter.Margin = new Padding(3, 4, 3, 4);
            panelForDeter.Name = "panelForDeter";
            panelForDeter.Size = new Size(264, 196);
            panelForDeter.TabIndex = 6;
            // 
            // bttnMaxElem
            // 
            bttnMaxElem.Dock = DockStyle.Top;
            bttnMaxElem.FlatAppearance.BorderSize = 0;
            bttnMaxElem.FlatStyle = FlatStyle.Flat;
            bttnMaxElem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnMaxElem.ForeColor = Color.FromArgb(64, 64, 64);
            bttnMaxElem.Location = new Point(0, 157);
            bttnMaxElem.Margin = new Padding(3, 4, 3, 4);
            bttnMaxElem.Name = "bttnMaxElem";
            bttnMaxElem.Padding = new Padding(30, 0, 0, 0);
            bttnMaxElem.Size = new Size(264, 40);
            bttnMaxElem.TabIndex = 7;
            bttnMaxElem.Text = "Максимальний елемент";
            bttnMaxElem.TextAlign = ContentAlignment.MiddleLeft;
            bttnMaxElem.UseVisualStyleBackColor = true;
            bttnMaxElem.Click += bttnMaxElem_Click;
            // 
            // bttnMinElem
            // 
            bttnMinElem.Dock = DockStyle.Top;
            bttnMinElem.FlatAppearance.BorderSize = 0;
            bttnMinElem.FlatStyle = FlatStyle.Flat;
            bttnMinElem.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnMinElem.ForeColor = Color.FromArgb(64, 64, 64);
            bttnMinElem.Location = new Point(0, 117);
            bttnMinElem.Margin = new Padding(3, 4, 3, 4);
            bttnMinElem.Name = "bttnMinElem";
            bttnMinElem.Padding = new Padding(30, 0, 0, 0);
            bttnMinElem.Size = new Size(264, 40);
            bttnMinElem.TabIndex = 6;
            bttnMinElem.Text = "Мінімальний елемент";
            bttnMinElem.TextAlign = ContentAlignment.MiddleLeft;
            bttnMinElem.UseVisualStyleBackColor = true;
            bttnMinElem.Click += bttnMinElem_Click;
            // 
            // bttnTraceOfTheMatrix
            // 
            bttnTraceOfTheMatrix.Dock = DockStyle.Top;
            bttnTraceOfTheMatrix.FlatAppearance.BorderSize = 0;
            bttnTraceOfTheMatrix.FlatStyle = FlatStyle.Flat;
            bttnTraceOfTheMatrix.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnTraceOfTheMatrix.ForeColor = Color.FromArgb(64, 64, 64);
            bttnTraceOfTheMatrix.Location = new Point(0, 78);
            bttnTraceOfTheMatrix.Margin = new Padding(3, 4, 3, 4);
            bttnTraceOfTheMatrix.Name = "bttnTraceOfTheMatrix";
            bttnTraceOfTheMatrix.Padding = new Padding(30, 0, 0, 0);
            bttnTraceOfTheMatrix.Size = new Size(264, 39);
            bttnTraceOfTheMatrix.TabIndex = 3;
            bttnTraceOfTheMatrix.Text = "Слід матриці";
            bttnTraceOfTheMatrix.TextAlign = ContentAlignment.MiddleLeft;
            bttnTraceOfTheMatrix.UseVisualStyleBackColor = true;
            bttnTraceOfTheMatrix.Click += bttnTraceOfTheMatrix_Click;
            // 
            // bttnRank
            // 
            bttnRank.Dock = DockStyle.Top;
            bttnRank.FlatAppearance.BorderSize = 0;
            bttnRank.FlatStyle = FlatStyle.Flat;
            bttnRank.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnRank.ForeColor = Color.FromArgb(64, 64, 64);
            bttnRank.Location = new Point(0, 39);
            bttnRank.Margin = new Padding(3, 4, 3, 4);
            bttnRank.Name = "bttnRank";
            bttnRank.Padding = new Padding(30, 0, 0, 0);
            bttnRank.Size = new Size(264, 39);
            bttnRank.TabIndex = 2;
            bttnRank.Text = "Ранг";
            bttnRank.TextAlign = ContentAlignment.MiddleLeft;
            bttnRank.UseVisualStyleBackColor = true;
            bttnRank.Click += bttnRank_Click;
            // 
            // bttnDeterminant
            // 
            bttnDeterminant.Dock = DockStyle.Top;
            bttnDeterminant.FlatAppearance.BorderSize = 0;
            bttnDeterminant.FlatStyle = FlatStyle.Flat;
            bttnDeterminant.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDeterminant.ForeColor = Color.FromArgb(64, 64, 64);
            bttnDeterminant.Location = new Point(0, 0);
            bttnDeterminant.Margin = new Padding(3, 4, 3, 4);
            bttnDeterminant.Name = "bttnDeterminant";
            bttnDeterminant.Padding = new Padding(30, 0, 0, 0);
            bttnDeterminant.Size = new Size(264, 39);
            bttnDeterminant.TabIndex = 1;
            bttnDeterminant.Text = "Детермінант";
            bttnDeterminant.TextAlign = ContentAlignment.MiddleLeft;
            bttnDeterminant.UseVisualStyleBackColor = true;
            bttnDeterminant.Click += bttnDeterminant_Click;
            // 
            // bttnDeter
            // 
            bttnDeter.BackColor = Color.FromArgb(141, 155, 164);
            bttnDeter.Dock = DockStyle.Top;
            bttnDeter.FlatAppearance.BorderSize = 0;
            bttnDeter.FlatStyle = FlatStyle.Flat;
            bttnDeter.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            bttnDeter.ForeColor = SystemColors.ActiveCaptionText;
            bttnDeter.Image = (Image)resources.GetObject("bttnDeter.Image");
            bttnDeter.ImageAlign = ContentAlignment.TopLeft;
            bttnDeter.Location = new Point(0, 344);
            bttnDeter.Margin = new Padding(3, 4, 3, 4);
            bttnDeter.Name = "bttnDeter";
            bttnDeter.Padding = new Padding(0, 20, 0, 0);
            bttnDeter.Size = new Size(264, 86);
            bttnDeter.TabIndex = 5;
            bttnDeter.Text = "Визначники / характеристичні числа";
            bttnDeter.UseVisualStyleBackColor = false;
            bttnDeter.Click += bttnDeter_Click;
            // 
            // panelTransformSubMenu
            // 
            panelTransformSubMenu.BackColor = Color.FromArgb(196, 201, 205);
            panelTransformSubMenu.Controls.Add(bttnInversion);
            panelTransformSubMenu.Controls.Add(bttnTransformMat);
            panelTransformSubMenu.Dock = DockStyle.Top;
            panelTransformSubMenu.Location = new Point(0, 259);
            panelTransformSubMenu.Margin = new Padding(3, 4, 3, 4);
            panelTransformSubMenu.Name = "panelTransformSubMenu";
            panelTransformSubMenu.Size = new Size(264, 85);
            panelTransformSubMenu.TabIndex = 4;
            // 
            // bttnInversion
            // 
            bttnInversion.Dock = DockStyle.Top;
            bttnInversion.FlatAppearance.BorderSize = 0;
            bttnInversion.FlatStyle = FlatStyle.Flat;
            bttnInversion.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnInversion.ForeColor = Color.FromArgb(66, 73, 83);
            bttnInversion.Location = new Point(0, 39);
            bttnInversion.Margin = new Padding(3, 4, 3, 4);
            bttnInversion.Name = "bttnInversion";
            bttnInversion.Padding = new Padding(30, 0, 0, 0);
            bttnInversion.Size = new Size(264, 46);
            bttnInversion.TabIndex = 2;
            bttnInversion.Text = "Обернена матриця";
            bttnInversion.TextAlign = ContentAlignment.MiddleLeft;
            bttnInversion.UseVisualStyleBackColor = true;
            bttnInversion.Click += bttnInversion_Click;
            // 
            // bttnTransformMat
            // 
            bttnTransformMat.Dock = DockStyle.Top;
            bttnTransformMat.FlatAppearance.BorderSize = 0;
            bttnTransformMat.FlatStyle = FlatStyle.Flat;
            bttnTransformMat.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point);
            bttnTransformMat.ForeColor = Color.FromArgb(66, 73, 83);
            bttnTransformMat.Location = new Point(0, 0);
            bttnTransformMat.Margin = new Padding(3, 4, 3, 4);
            bttnTransformMat.Name = "bttnTransformMat";
            bttnTransformMat.Padding = new Padding(30, 0, 0, 0);
            bttnTransformMat.Size = new Size(264, 39);
            bttnTransformMat.TabIndex = 1;
            bttnTransformMat.Text = "Транспонована матриця";
            bttnTransformMat.TextAlign = ContentAlignment.MiddleLeft;
            bttnTransformMat.UseVisualStyleBackColor = true;
            bttnTransformMat.Click += bttnTransformMat_Click;
            // 
            // bttnTransform
            // 
            bttnTransform.BackColor = Color.FromArgb(141, 155, 164);
            bttnTransform.Dock = DockStyle.Top;
            bttnTransform.FlatAppearance.BorderSize = 0;
            bttnTransform.FlatStyle = FlatStyle.Flat;
            bttnTransform.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            bttnTransform.ForeColor = Color.Black;
            bttnTransform.Image = (Image)resources.GetObject("bttnTransform.Image");
            bttnTransform.ImageAlign = ContentAlignment.MiddleLeft;
            bttnTransform.Location = new Point(0, 187);
            bttnTransform.Margin = new Padding(30, 4, 3, 4);
            bttnTransform.Name = "bttnTransform";
            bttnTransform.Padding = new Padding(0, 20, 0, 0);
            bttnTransform.Size = new Size(264, 72);
            bttnTransform.TabIndex = 3;
            bttnTransform.Text = "  Трансформаційні дії";
            bttnTransform.UseVisualStyleBackColor = false;
            bttnTransform.Click += bttnTransform_Click;
            // 
            // bttnArithmeticOp
            // 
            bttnArithmeticOp.BackColor = Color.FromArgb(141, 155, 164);
            bttnArithmeticOp.Dock = DockStyle.Top;
            bttnArithmeticOp.FlatAppearance.BorderSize = 0;
            bttnArithmeticOp.FlatStyle = FlatStyle.Flat;
            bttnArithmeticOp.Font = new Font("Times New Roman", 13.8F, FontStyle.Regular, GraphicsUnit.Point);
            bttnArithmeticOp.ForeColor = Color.Black;
            bttnArithmeticOp.Image = (Image)resources.GetObject("bttnArithmeticOp.Image");
            bttnArithmeticOp.ImageAlign = ContentAlignment.MiddleLeft;
            bttnArithmeticOp.Location = new Point(0, 102);
            bttnArithmeticOp.Margin = new Padding(3, 4, 3, 4);
            bttnArithmeticOp.Name = "bttnArithmeticOp";
            bttnArithmeticOp.Size = new Size(264, 85);
            bttnArithmeticOp.TabIndex = 1;
            bttnArithmeticOp.Text = "Арифметичні дії";
            bttnArithmeticOp.UseVisualStyleBackColor = false;
            bttnArithmeticOp.Click += bttnArithmeticOp_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(141, 155, 164);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(264, 102);
            panel1.TabIndex = 1;
            // 
            // panelForwx
            // 
            panelForwx.BackColor = Color.FromArgb(141, 155, 164);
            panelForwx.Dock = DockStyle.Top;
            panelForwx.Location = new Point(285, 0);
            panelForwx.Name = "panelForwx";
            panelForwx.Size = new Size(1383, 44);
            panelForwx.TabIndex = 1;
            // 
            // panelForChildForm
            // 
            panelForChildForm.BackColor = Color.FromArgb(217, 204, 195);
            panelForChildForm.Controls.Add(label1);
            panelForChildForm.ForeColor = Color.Black;
            panelForChildForm.Location = new Point(285, 0);
            panelForChildForm.Name = "panelForChildForm";
            panelForChildForm.Size = new Size(1371, 804);
            panelForChildForm.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Vivaldi", 36F, FontStyle.Italic, GraphicsUnit.Point);
            label1.Location = new Point(297, 308);
            label1.Name = "label1";
            label1.Size = new Size(645, 71);
            label1.TabIndex = 0;
            label1.Text = "Калькулятор Матриць";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 223, 215);
            ClientSize = new Size(1668, 829);
            ControlBox = false;
            Controls.Add(panelForwx);
            Controls.Add(panelForChildForm);
            Controls.Add(pnlMenu);
            ForeColor = Color.FromArgb(66, 73, 83);
            HelpButton = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            TransparencyKey = Color.Transparent;
            Resize += Form1_Resize;
            pnlMenu.ResumeLayout(false);
            panelForDeter.ResumeLayout(false);
            panelTransformSubMenu.ResumeLayout(false);
            panelForChildForm.ResumeLayout(false);
            panelForChildForm.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Button bttnArithmeticOp;
        private System.Windows.Forms.Panel panel1;
        private Button bttnTransform;
        private Panel panelTransformSubMenu;
        private Button bttnInversion;
        private Button bttnTransformMat;
        private Panel panelForwx;
        private Panel panelForChildForm;
        private Panel panelForDeter;
        private Button bttnTraceOfTheMatrix;
        private Button bttnRank;
        private Button bttnDeterminant;
        private Button bttnDeter;
        private Button bttnMaxElem;
        private Button bttnMinElem;
        private Button buttonbackpagehome;
        private Button buttonMin;
        private Button buttonExitProg;
        private Label label1;
    }
    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    #endregion
}
