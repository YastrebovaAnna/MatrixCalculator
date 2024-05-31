using LibraryMatrix.interfaces;

namespace LibraryMatrix.implementations
{
    public class WinFormsLabel : ILabel
    {
        private Label label;

        public WinFormsLabel()
        {
            label = new Label
            {
                AutoSize = true
            };
        }

        public string Text
        {
            get => label.Text;
            set => label.Text = value;
        }

        public void SetLocation(int x, int y)
        {
            label.Location = new Point(x, y);
        }

        public void SetFont(string fontFamily, int fontSize)
        {
            label.Font = new Font(fontFamily, fontSize);
        }

        public void AddToParent(object parent)
        {
            if (parent is Form form)
            {
                form.Controls.Add(label);
            }
        }

        public void RemoveFromParent(object parent)
        {
            if (parent is Form form)
            {
                form.Controls.Remove(label);
            }
        }
    }
}
