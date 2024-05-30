using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace LibraryMatrix.core
{
    public static class MatrixOperationOtherContext
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static int CalculateRank(IMatrix matrix)
        {
            return CreateContext(new CalculateRank()).ExecuteOperation<int>(matrix);
        }

        public static double CalculateTrace(IMatrix matrix)
        {
            return CreateContext(new CalculateTrace()).ExecuteOperation<double>(matrix);
        }

        public static double FindMinimumElement(IMatrix matrix)
        {
            return CreateContext(new FindMinimumElement()).ExecuteOperation<double>(matrix);
        }

        public static double FindMaximumElement(IMatrix matrix)
        {
            return CreateContext(new FindMaximumElement()).ExecuteOperation<double>(matrix);
        }

        public static double CalculateMatrixNorm(IMatrix matrix)
        {
            return CreateContext(new MatrixNormal()).ExecuteOperation<double>(matrix);
        }

        public static double CalculateAverage(IMatrix matrix)
        {
            return CreateContext(new CalculateAverage()).ExecuteOperation<double>(matrix);
        }

        public static double CalculateSum(IMatrix matrix)
        {
            return CreateContext(new CalculateSum()).ExecuteOperation<double>(matrix);
        }

        public static double CalculateProduct(IMatrix matrix)
        {
            return CreateContext(new CalculateProduct()).ExecuteOperation<double>(matrix);
        }
    }
}
