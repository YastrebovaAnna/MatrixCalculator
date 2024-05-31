using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.binary
{
    public class MultiplicationOperation : MatrixBinaryOperationBase
    {
        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA * valueB;
        }
    }
}
