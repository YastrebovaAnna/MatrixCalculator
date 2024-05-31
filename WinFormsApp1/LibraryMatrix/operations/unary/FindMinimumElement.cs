using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class FindMinimumElement : MatrixAggregateOperationBase
    {
        protected override double Initialize() => double.MaxValue;

        protected override double Aggregate(double accumulator, double value) => Math.Min(accumulator, value);

        protected override double Finalize(double accumulator, int elementCount) => accumulator;
    }
}
