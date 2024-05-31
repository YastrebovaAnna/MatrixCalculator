
namespace LibraryMatrix.interfaces
{
    public interface IIterator
    {
        void Iterate(Action<int, int, double> action);
        void Iterate(Action<int, int, double, double> action, IMatrix otherMatrix);
    }
}
