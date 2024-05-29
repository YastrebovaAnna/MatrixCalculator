using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class PowerOperation : IElementOperation
    {
        private readonly double _power;

        public PowerOperation(double power)
        {
            _power = power;
        }

        public double Execute(double value)
        {
            return Math.Pow(value, _power);
        }
    }
}
