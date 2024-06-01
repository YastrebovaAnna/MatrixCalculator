using LibraryMatrix.core;
using LibraryMatrix.interfaces;
using LibraryMatrix.interfaces.validation;
using LibraryMatrix.validators;

namespace LibraryMatrix.operations.unary
{
    public class CalculateTrace : IMatrixOperation<double>
    {
        private readonly IUnaryMatrixSizeValidator _sizeValidator;

        public CalculateTrace()
        {
            _sizeValidator = new SquareMatrixValidator();
        }

        public double Execute(IMatrix matrix)
        {
            _sizeValidator.Validate(matrix);

            double trace = 0.0;
            var iterator = new MatrixIterator(matrix);

            iterator.Iterate((i, j, value) =>
            {
                if (i == j)
                {
                    trace += value;
                }
            });

            return trace;
        }
    }
}
