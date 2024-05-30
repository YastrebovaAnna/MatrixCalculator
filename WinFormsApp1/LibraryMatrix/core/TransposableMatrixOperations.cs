using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix.core
{
    public static class TransposableMatrixOperations
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
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
    }
}
