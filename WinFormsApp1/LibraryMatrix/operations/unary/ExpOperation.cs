using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class ExpOperation : MatrixUnaryOperationBase
    {
        protected override double PerformOperation(double value)
        {
            return Math.Exp(value);
        }
    }
}
