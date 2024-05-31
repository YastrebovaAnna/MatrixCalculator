using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace LibraryMatrix.facade
{
    public static class MatrixFacade
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateBinaryContext(IMatrixBinaryOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }
        public static double CalculateDeterminant(IMatrix matrix, IMatrixOperation<double> operation)
        {
            return CreateContext(operation).ExecuteOperation<double>(matrix);
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

        public static IMatrix Exp(IMatrix matrix)
        {
            return CreateContext(new ExpOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Log(IMatrix matrix)
        {
            return CreateContext(new LogOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Sin(IMatrix matrix)
        {
            return CreateContext(new SinOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Cos(IMatrix matrix)
        {
            return CreateContext(new CosOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Tan(IMatrix matrix)
        {
            return CreateContext(new TanOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix MultiplyByScalar(IMatrix matrix, double scalar)
        {
            return CreateContext(new ScalarMultiplicationOperation(scalar)).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Power(IMatrix matrix, double power)
        {
            return CreateContext(new PowerOperation(power)).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Transpose(IMatrix matrix)
        {
            return CreateContext(new TransposeOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Invert(IMatrix matrix)
        {
            return CreateContext(new InvertOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix RotateClockwise(IMatrix matrix)
        {
            return CreateContext(new RotateClockwiseOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix RotateCounterClockwise(IMatrix matrix)
        {
            return CreateContext(new RotateCounterClockwiseOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Add(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateBinaryContext(new AddOperation()).ExecuteBinaryOperation(matrix1, matrix2);
        }

        public static IMatrix Subtract(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateBinaryContext(new SubtractionOperation()).ExecuteBinaryOperation(matrix1, matrix2);
        }

        public static IMatrix Multiply(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateBinaryContext(new MultiplicationOperation()).ExecuteBinaryOperation(matrix1, matrix2);
        }

        public static IMatrix Equality(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateBinaryContext(new EqualityOperation()).ExecuteBinaryOperation(matrix1, matrix2);
        }

        public static IMatrix Inequality(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateBinaryContext(new InequalityOperation()).ExecuteBinaryOperation(matrix1, matrix2);
        }
    }
}
