using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class ScalarMultiplicationOperation : MatrixUnaryOperationBase
    {
        private readonly double _scalar;

        public ScalarMultiplicationOperation(double scalar)
        {
            _scalar = scalar;
        }

        protected override double PerformOperation(double value)
        {
            return value * _scalar;
        }
    }
}
