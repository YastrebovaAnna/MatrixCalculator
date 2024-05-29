using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class ScalarMultiplicationOperation : IElementOperation
    {
        private readonly double _scalar;

        public ScalarMultiplicationOperation(double scalar)
        {
            _scalar = scalar;
        }

        public double Execute(double value)
        {
            return value * _scalar;
        }
    }
}
