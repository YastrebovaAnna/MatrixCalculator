using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class CalculateTrace : IMatrixTraceOperation
    {
        public double Execute(IMatrix matrix)
        {
            if (matrix.Rows != matrix.Columns)
                throw new InvalidOperationException("Matrix must be square.");

            double trace = 0.0;
            for (int i = 0; i < matrix.Rows; i++)
                trace += matrix.MatrixArray[i, i];

            return trace;
        }
    }
}
