
namespace LibraryMatrix.interfaces.dataInputs
{
    public interface IDataInput
    {
        string Text { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        Point Location { get; set; }
        Color BackColor { get; set; }
    }
}
