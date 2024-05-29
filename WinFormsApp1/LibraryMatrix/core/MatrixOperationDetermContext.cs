using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.core
{
    public class MatrixOperationDetermContext
    {
        private static IMatrixContext CreateContext(IMatrixDeterminantOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }
        public static double CalculateDeterminant(IMatrix matrix, IMatrixDeterminantOperation operation)
        {
            return CreateContext(operation).ExecuteDeterminantOperation(matrix);
        }
    }
}
