using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class SinOperation : MatrixUnaryOperationBase
    {
        protected override double PerformOperation(double value)
        {
            return Math.Sin(value);
        }
    }
}
