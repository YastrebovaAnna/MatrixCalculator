using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class FindMaximumElement : MatrixAggregateOperationBase
    {
        protected override double Initialize() => double.MinValue;

        protected override double Aggregate(double accumulator, double value) => Math.Max(accumulator, value);

        protected override double Finalize(double accumulator, int elementCount) => accumulator;
    }
}
