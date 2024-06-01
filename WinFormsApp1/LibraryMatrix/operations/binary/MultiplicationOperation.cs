using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.binary
{
    public class MultiplicationOperation : MatrixBinaryOperationBase
    {
        public MultiplicationOperation() : base(new MultiplicationSizeValidator()) { }

        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA * valueB;
        }
    }
}
