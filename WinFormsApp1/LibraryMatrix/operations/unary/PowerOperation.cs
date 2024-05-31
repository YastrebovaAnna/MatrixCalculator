using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class PowerOperation : MatrixUnaryOperationBase
    {
        private readonly double _power;

        public PowerOperation(double power)
        {
            _power = power;
        }

        protected override double PerformOperation(double value)
        {
            return Math.Pow(value, _power);
        }
    }
}
