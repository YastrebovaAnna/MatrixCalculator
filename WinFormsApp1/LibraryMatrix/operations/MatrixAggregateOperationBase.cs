using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public abstract class MatrixAggregateOperationBase : IMatrixOperation<double>
    {
        protected abstract double Initialize();
        protected abstract double Aggregate(double accumulator, double value);
        protected abstract double Finalize(double accumulator, int elementCount);

        public double Execute(IMatrix matrix)
        {
            double accumulator = Initialize();
            int elementCount = matrix.Rows * matrix.Columns;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                accumulator = Aggregate(accumulator, value);
            });

            return Finalize(accumulator, elementCount);
        }
    }
}
