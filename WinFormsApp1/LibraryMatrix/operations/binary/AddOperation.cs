using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.binary
{
    public class AddOperation : MatrixBinaryOperationBase
    {
        public AddOperation() : base(new SameSizeValidator()) { }

        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA + valueB;
        }

    }
}
