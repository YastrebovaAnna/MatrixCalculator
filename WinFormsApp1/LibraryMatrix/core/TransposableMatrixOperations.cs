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
        private static IMatrixContext CreateContext(ITransposeOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IInvertOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IRotateClockwiseOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        private static IMatrixContext CreateContext(IRotateCounterClockwiseOperation operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static IMatrix Transpose(IMatrix matrix)
        {
            return CreateContext(new TransposeOperation()).ExecuteTransposeOperation(matrix);
        }

        public static IMatrix Invert(IMatrix matrix)
        {
            return CreateContext(new InvertOperation()).ExecuteInvertOperation(matrix);
        }

        public static IMatrix RotateClockwise(IMatrix matrix)
        {
            return CreateContext(new RotateClockwiseOperation()).ExecuteRotateClockwiseOperation(matrix);
        }

        public static IMatrix RotateCounterClockwise(IMatrix matrix)
        {
            return CreateContext(new RotateCounterClockwiseOperation()).ExecuteRotateCounterClockwiseOperation(matrix);
        }
    }
}
