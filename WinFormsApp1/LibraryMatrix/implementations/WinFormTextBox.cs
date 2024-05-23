using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.implementations
{
    public class WinFormTextBox : IDataInput
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
    }
}
