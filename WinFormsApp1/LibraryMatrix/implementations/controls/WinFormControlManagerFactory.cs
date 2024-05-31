using LibraryMatrix.interfaces.controls;

namespace LibraryMatrix.implementations.controls
{
    public class WinFormControlManagerFactory<T> : IControlManagerFactory<T> where T : IControl
    {
        public IControlManager<T> CreateControlManager(Control parentControl)
        {
            return new WinFormControlManager<T>(parentControl);
        }
    }
}
