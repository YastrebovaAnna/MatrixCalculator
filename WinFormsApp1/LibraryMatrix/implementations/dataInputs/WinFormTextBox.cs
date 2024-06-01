using LibraryMatrix.interfaces.controls;
using LibraryMatrix.interfaces.dataInputs;

namespace LibraryMatrix.implementations.dataInputs
{
    public class WinFormTextBox : IDataInput, IControl
    {
        private readonly TextBox textBox;

        public WinFormTextBox()
        {
            textBox = new TextBox();
        }

        public string Text
        {
            get => textBox.Text;
            set => textBox.Text = value;
        }

        public int Width
        {
            get => textBox.Width;
            set => textBox.Width = value;
        }

        public int Height
        {
            get => textBox.Height;
            set => textBox.Height = value;
        }

        public Point Location
        {
            get => textBox.Location;
            set => textBox.Location = value;
        }

        public Color BackColor
        {
            get => textBox.BackColor;
            set => textBox.BackColor = value;
        }

        public TextBox GetTextBox() => textBox;

        public void AddToParent(object parent)
        {
            if (parent is Form form)
            {
                form.Controls.Add(textBox);
            }
        }

        public void RemoveFromParent(object parent)
        {
            if (parent is Form form)
            {
                form.Controls.Remove(textBox);
            }
        }
        public void SetLocation(int x, int y)
        {
            textBox.Location = new Point(x, y);
        }

        public void SetFont(string fontFamily, int fontSize)
        {
            textBox.Font = new Font(fontFamily, fontSize);
        }
    }
}
