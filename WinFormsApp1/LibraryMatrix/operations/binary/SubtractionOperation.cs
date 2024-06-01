using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.binary
{
    public class SubtractionOperation : MatrixBinaryOperationBase
    {
        public SubtractionOperation() : base(new SameSizeValidator()) { }

        protected override double PerformOperation(double valueA, double valueB)
        {
            return valueA - valueB;
        }
    }
}
