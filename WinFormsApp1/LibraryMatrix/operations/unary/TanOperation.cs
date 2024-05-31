using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class TanOperation : MatrixUnaryOperationBase
    {
        protected override double PerformOperation(double value)
        {
            return Math.Tan(value);
        }
    }
}
