using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class LogOperation : MatrixUnaryOperationBase
    {
        protected override double PerformOperation(double value)
        {
            return Math.Log(value);
        }
    }
}
