using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations.unary
{
    public class CalculateSum : MatrixAggregateOperationBase
    {
        protected override double Initialize() => 0.0;

        protected override double Aggregate(double accumulator, double value) => accumulator += value;

        protected override double Finalize(double accumulator, int elementCount) => accumulator;
    }
}
