using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace LibraryMatrix.core
{
    public static class MatrixOperationOtherContext
    {
        private static IMatrixContext CreateContext(IMatrixRankOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IMatrixTraceOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IMatrixElementFinder operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IMatrixNormOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static int CalculateRank(IMatrix matrix)
        {
            return CreateContext(new CalculateRank()).ExecuteRankOperation(matrix);
        }

        public static double CalculateTrace(IMatrix matrix)
        {
            return CreateContext(new CalculateTrace()).ExecuteTraceOperation(matrix);
        }

        public static double FindMinimumElement(IMatrix matrix)
        {
            return CreateContext(new FindMinimumElement()).ExecuteElementFinderOperation(matrix);
        }

        public static double FindMaximumElement(IMatrix matrix)
        {
            return CreateContext(new FindMaximumElement()).ExecuteElementFinderOperation(matrix);
        }

        public static double CalculateMatrixNorm(IMatrix matrix)
        {
            return CreateContext(new MatrixNormal()).ExecuteNormOperation(matrix);
        }

        public static double CalculateAverage(IMatrix matrix)
        {
            return CreateContext(new CalculateAverage()).ExecuteElementFinderOperation(matrix);
        }

        public static double CalculateSum(IMatrix matrix)
        {
            return CreateContext(new CalculateSum()).ExecuteElementFinderOperation(matrix);
        }

        public static double CalculateProduct(IMatrix matrix)
        {
            return CreateContext(new CalculateProduct()).ExecuteElementFinderOperation(matrix);
        }
    }
}
