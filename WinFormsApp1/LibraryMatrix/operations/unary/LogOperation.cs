﻿using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class LogOperation : IMatrixOperation<IMatrix>
    {
        public IMatrix Execute(IMatrix matrix)
        {
            int rows = matrix.Rows;
            int cols = matrix.Columns;
            double[,] result = new double[rows, cols];
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                result[i, j] = Math.Log(value);
            });

            return new Matrix(rows, cols, result);
        }
    }
}