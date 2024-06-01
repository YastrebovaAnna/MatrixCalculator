using LibraryMatrix.interfaces;

namespace LibraryMatrix.core
{
    public class TextBoxMatrixWrapper : IMatrix
    {
        private readonly TextBoxMatrix _textBoxMatrix;

        public TextBoxMatrixWrapper(TextBoxMatrix textBoxMatrix)
        {
            _textBoxMatrix = textBoxMatrix;
        }

        public int Rows => _textBoxMatrix.Rows;
        public int Columns => _textBoxMatrix.Columns;
        public double[,] MatrixArray
        {
            get
            {
                var values = new double[_textBoxMatrix.Rows, _textBoxMatrix.Columns];
                for (int i = 0; i < _textBoxMatrix.Rows; i++)
                {
                    for (int j = 0; j < _textBoxMatrix.Columns; j++)
                    {
                        var dataInput = _textBoxMatrix.DataInputs[i, j];
                        if (dataInput != null && double.TryParse(dataInput.Text, out double value))
                        {
                            values[i, j] = value;
                        }
                        else
                        {
                            values[i, j] = 0;
                        }
                    }
                }
                return values;
            }
        }
    }
}
