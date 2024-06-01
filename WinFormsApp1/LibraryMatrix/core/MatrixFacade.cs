using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations.binary;
using LibraryMatrix.operations.inversion;
using LibraryMatrix.operations.rotation;
using LibraryMatrix.operations.unary;

namespace LibraryMatrix.facade
{
    public static class MatrixFacade
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            var context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateBinaryContext(IMatrixBinaryOperation operation)
        {
            var context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }
        private static TResult ExecuteOperation<TResult>(IMatrix matrix, IMatrixOperation<TResult> operation)
        {
            return CreateContext(operation).ExecuteOperation<TResult>(matrix);
        }

        private static IMatrix ExecuteBinaryOperation(IMatrix matrix1, IMatrix matrix2, IMatrixBinaryOperation operation)
        {
            return CreateBinaryContext(operation).ExecuteBinaryOperation(matrix1, matrix2);
        }

        public static double CalculateDeterminant(IMatrix matrix, IMatrixOperation<double> operation) => ExecuteOperation(matrix, operation);
        public static int CalculateRank(IMatrix matrix) => ExecuteOperation(matrix, new CalculateRank());
        public static double CalculateTrace(IMatrix matrix) => ExecuteOperation(matrix, new CalculateTrace());
        public static double FindMinimumElement(IMatrix matrix) => ExecuteOperation(matrix, new FindMinimumElement());
        public static double FindMaximumElement(IMatrix matrix) => ExecuteOperation(matrix, new FindMaximumElement());
        public static double CalculateMatrixNorm(IMatrix matrix) => ExecuteOperation(matrix, new MatrixNormal());
        public static double CalculateAverage(IMatrix matrix) => ExecuteOperation(matrix, new CalculateAverage());
        public static double CalculateSum(IMatrix matrix) => ExecuteOperation(matrix, new CalculateSum());
        public static double CalculateProduct(IMatrix matrix) => ExecuteOperation(matrix, new CalculateProduct());
        public static IMatrix Exp(IMatrix matrix) => ExecuteOperation(matrix, new ExpOperation());
        public static IMatrix Log(IMatrix matrix) => ExecuteOperation(matrix, new LogOperation());
        public static IMatrix Sin(IMatrix matrix) => ExecuteOperation(matrix, new SinOperation());
        public static IMatrix Cos(IMatrix matrix) => ExecuteOperation(matrix, new CosOperation());
        public static IMatrix Tan(IMatrix matrix) => ExecuteOperation(matrix, new TanOperation());
        public static IMatrix MultiplyByScalar(IMatrix matrix, double scalar) => ExecuteOperation(matrix, new ScalarMultiplicationOperation(scalar));
        public static IMatrix Power(IMatrix matrix, double power) => ExecuteOperation(matrix, new PowerOperation(power));
        public static IMatrix Transpose(IMatrix matrix) => ExecuteOperation(matrix, new TransposeOperation());
        public static IMatrix Invert(IMatrix matrix) => ExecuteOperation(matrix, new InvertOperation());
        public static IMatrix RotateClockwise(IMatrix matrix) => ExecuteOperation(matrix, new RotateClockwiseOperation());
        public static IMatrix RotateCounterClockwise(IMatrix matrix) => ExecuteOperation(matrix, new RotateCounterClockwiseOperation());
        public static IMatrix Add(IMatrix matrix1, IMatrix matrix2) => ExecuteBinaryOperation(matrix1, matrix2, new AddOperation());
        public static IMatrix Subtract(IMatrix matrix1, IMatrix matrix2) => ExecuteBinaryOperation(matrix1, matrix2, new SubtractionOperation());
        public static IMatrix Multiply(IMatrix matrix1, IMatrix matrix2) => ExecuteBinaryOperation(matrix1, matrix2, new MultiplicationOperation());
        public static IMatrix Equality(IMatrix matrix1, IMatrix matrix2) => ExecuteBinaryOperation(matrix1, matrix2, new EqualityOperation());
        public static IMatrix Inequality(IMatrix matrix1, IMatrix matrix2) => ExecuteBinaryOperation(matrix1, matrix2, new InequalityOperation());

    }
}
