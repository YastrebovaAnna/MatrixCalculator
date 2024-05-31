
namespace LibraryMatrix.interfaces
{
    public interface ILabel
    {
        string Text { get; set; }
        void SetLocation(int x, int y);
        void SetFont(string fontFamily, int fontSize);
        void AddToParent(object parent);
        void RemoveFromParent(object parent);
    }
}
