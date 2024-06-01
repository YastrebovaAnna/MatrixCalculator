

namespace LibraryMatrix.interfaces.controls
{
    public interface IControlManagerFactory<T> where T : IControl
    {
        IControlManager<T> CreateControlManager(Control parentControl);
    }
}
