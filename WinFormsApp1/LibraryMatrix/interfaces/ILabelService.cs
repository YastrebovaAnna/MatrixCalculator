
namespace LibraryMatrix.interfaces
{
    public interface ILabelService
    {
        void AddResultLabel(object parent, string text, int startX, int startY);
        void ClearResultLabels(object parent);
    }

}
