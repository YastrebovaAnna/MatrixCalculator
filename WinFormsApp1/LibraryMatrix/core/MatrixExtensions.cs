﻿using LibraryMatrix.calculator;
using LibraryMatrix.interfaces;
using LibraryMatrix.operations;

namespace LibraryMatrix.core
{
    public static class MatrixExtensions
    {
        private static IMatrixContext CreateContext<T>(IMatrixOperation<T> operation)
        {
            IMatrixContext context = new MatrixContext();
            context.SetStrategy(operation);
            return context;
        }

        public static IMatrix Exp(this IMatrix matrix)
        {
            return CreateContext(new ExpOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Log(this IMatrix matrix)
        {
            return CreateContext(new LogOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Sin(this IMatrix matrix)
        {
            return CreateContext(new SinOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Cos(this IMatrix matrix)
        {
            return CreateContext(new CosOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Tan(this IMatrix matrix)
        {
            return CreateContext(new TanOperation()).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix MultiplyByScalar(this IMatrix matrix, double scalar)
        {
            return CreateContext(new ScalarMultiplicationOperation(scalar)).ExecuteOperation<IMatrix>(matrix);
        }

        public static IMatrix Power(this IMatrix matrix, double power)
        {
            return CreateContext(new PowerOperation(power)).ExecuteOperation<IMatrix>(matrix);
        }
    }
}
