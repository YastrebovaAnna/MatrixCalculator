using LibraryMatrix.interfaces;

namespace LibraryMatrix.implementations
{
    public class WinFormsUIFactory : IUIFactory
    {
        public ILabel CreateLabel()
        {
            return new WinFormsLabel();
        }

        public ILabelService CreateLabelService()
        {
            return new WinFormsLabelService();
        }
    }
}
