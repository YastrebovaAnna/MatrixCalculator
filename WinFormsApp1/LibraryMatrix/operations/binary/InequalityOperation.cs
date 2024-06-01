using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.binary
{
    public class InequalityOperation : MatrixBinaryOperationBase
    {
        public InequalityOperation() : base(new SameSizeValidator()) { }

        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA != valueB ? 1 : 0;
        }
    }
}
