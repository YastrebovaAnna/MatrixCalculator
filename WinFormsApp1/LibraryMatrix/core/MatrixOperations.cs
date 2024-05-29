using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace LibraryMatrix.core
{
    public static class MatrixOperations
    {
        private static IMatrixContext CreateContext(IMatrixBinaryOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static IMatrix PerformMatrixAddition(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateContext(new AddOperation()).ExecuteOperation(matrix1, matrix2);
        }

        public static IMatrix PerformMatrixSubtraction(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateContext(new SubtractionOperation()).ExecuteOperation(matrix1, matrix2);
        }

        public static IMatrix PerformMatrixMultiplication(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateContext(new MultiplicationOperation()).ExecuteOperation(matrix1, matrix2);
        }

        public static IMatrix PerformMatrixEquality(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateContext(new EqualityOperation()).ExecuteOperation(matrix1, matrix2);
        }

        public static IMatrix PerformMatrixInequality(IMatrix matrix1, IMatrix matrix2)
        {
            return CreateContext(new InequalityOperation()).ExecuteOperation(matrix1, matrix2);
        }
    }
}
