namespace LibraryMatrix.interfaces.labels
{
    public interface ILabelService
    {
        void AddResultLabel(object parent, string text, int startX, int startY);
        void ClearResultLabels(object parent);
    }

}
