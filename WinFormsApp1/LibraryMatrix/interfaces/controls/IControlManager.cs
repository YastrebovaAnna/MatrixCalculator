

namespace LibraryMatrix.interfaces.controls
{
    public interface IControlManager<T> where T : IControl
    {
        void AddControl(T control);
        void RemoveControl(T control);
        void ClearControls(IEnumerable<T> controls);
        void RemoveReadOnlyControls();
        void ResetButtonPositions(bool isFirstMatrix, Control[] leftButtons, Control[] rightButtons);
    }
}
