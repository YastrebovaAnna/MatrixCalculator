using LibraryMatrix.interfaces;

namespace LibraryMatrix.implementations
{
    public class WinFormsLabelService : ILabelService
    {
        private List<ILabel> resultLabels = new List<ILabel>();

        public void AddResultLabel(object parent, string text, int startX, int startY)
        {
            ILabel label = new WinFormsLabel();
            label.Text = text;
            label.SetFont("Times New Roman", 12);
            label.SetLocation(startX, startY + resultLabels.Count * 20);
            resultLabels.Add(label);
            label.AddToParent(parent);
        }

        public void ClearResultLabels(object parent)
        {
            foreach (ILabel label in resultLabels)
            {
                label.RemoveFromParent(parent);
            }
            resultLabels.Clear();
        }
    }
}
