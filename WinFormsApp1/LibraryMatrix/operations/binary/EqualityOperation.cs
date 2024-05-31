using LibraryMatrix.core;
using LibraryMatrix.interfaces;

namespace LibraryMatrix.operations
{
    public class EqualityOperation : IMatrixBinaryOperation
    {
        public IMatrix Execute(IMatrix matrixA, IMatrix matrixB)
        {
            if (ReferenceEquals(matrixA, matrixB))
                return new Matrix(1, 1, new double[,] { { 1.0 } });

            if (matrixA == null || matrixB == null)
                return new Matrix(1, 1, new double[,] { { 0.0 } });

            if (matrixA.Rows != matrixB.Rows || matrixA.Columns != matrixB.Columns)
                return new Matrix(1, 1, new double[,] { { 0.0 } });

            var equal = true;
            var iterator = new MatrixIterator(matrixA);

            iterator.Iterate((i, j, valueA, valueB) =>
            {
                if (valueA != valueB)
                {
                    equal = false;
                }
            }, matrixB);

            return new Matrix(1, 1, new double[,] { { equal ? 1.0 : 0.0 } });
        }

        public IMatrix Execute(IMatrix matrix)
        {
            throw new NotImplementedException("EqualityOperation requires two matrices.");
        }
    }
}
