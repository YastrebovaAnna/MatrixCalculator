using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.core
{
    public class MatrixOperationDetermContext
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static double CalculateDeterminant(IMatrix matrix, IMatrixOperation<double> operation)
        {
            return CreateContext(operation).ExecuteOperation<double>(matrix);
        }
    }
}
