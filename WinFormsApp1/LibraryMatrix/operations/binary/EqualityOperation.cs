using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.binary
{
    public class EqualityOperation : MatrixBinaryOperationBase
    {
        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA == valueB ? 1 : 0;
        }
    }
}
