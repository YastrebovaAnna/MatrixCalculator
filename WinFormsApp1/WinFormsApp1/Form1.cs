using System.Windows.Forms;
using System.Drawing;
using System.Runtime.InteropServices;
using CalcMatrix;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn
            (
            int nLeftRect,
            int nTopRect,
            int nRightRect,
            int nBottomRect,
            int nWidthEllipse,
            int nHeightEllipse);
        private bool isDragging;

        private Point dragStartPoint;
        public Form1()
        {
            InitializeComponent();
            customDesign();
            this.MouseDown += MainForm_MouseDown;
            this.MouseMove += MainForm_MouseMove;
            this.MouseUp += MainForm_MouseUp;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 60, 60));
        }
        private void MainForm_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = true;
                dragStartPoint = new Point(e.X, e.Y);
            }
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point currentPoint = PointToScreen(new Point(e.X, e.Y));
                Location = new Point(currentPoint.X - dragStartPoint.X, currentPoint.Y - dragStartPoint.Y);
            }
        }

        private void MainForm_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDragging = false;
            }
        }
        private void customDesign()
        {
            panelTransformSubMenu.Visible = false;
            panelForDeter.Visible = false;
        }
        private void hideSubMenu()
        {
            if (panelTransformSubMenu.Visible == true)
                panelTransformSubMenu.Visible = false;
            if (panelForDeter.Visible == true)
                panelForDeter.Visible = false;
        }
        private void showSubMenu(Panel submenu)
        {
            if (submenu.Visible == false)
            {
                hideSubMenu();
                submenu.Visible = true;
            }
            else
                submenu.Visible = false;
        }
        #region TransformMatrix
        private void bttnTransform_Click(object sender, EventArgs e)
        {
            showSubMenu(panelTransformSubMenu);

            openChildForm(new FormForTransposing());
        }

        private void bttnTransformMat_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttnInversion_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttn3view_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttnDiagonalView_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        #endregion

        private Form activeForm = null;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelForChildForm.Controls.Add(childForm);
            panelForChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void bttnArithmeticOp_Click(object sender, EventArgs e)
        {
            openChildForm(new FormForArithmetic());
        }

        private void bttnDeter_Click(object sender, EventArgs e)
        {
            showSubMenu(panelForDeter);
            openChildForm(new FormDetermCharactNumb());
        }
        private void pnlMenu_Paint(object sender, PaintEventArgs e)
        {
            hideSubMenu();
        }

        private void bttnDeterminant_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttnRank_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttnTraceOfTheMatrix_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }
        private void bttnMinElem_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void bttnMaxElem_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void buttonExit_Click_1(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void buttonbackpagehome_Click(object sender, EventArgs e)
        {
            panelForChildForm.Controls.Clear();
        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            Invalidate();
        }

        private void buttonSubMenuLu_Click(object sender, EventArgs e)
        {
            hideSubMenu();
        }

        private void buttonExitProg_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
