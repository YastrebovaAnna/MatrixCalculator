using LibraryMatrix.interfaces.dataInputs;

namespace LibraryMatrix.core
{
    public class TextBoxMatrix
    {
        public IDataInput[,] DataInputs { get; private set; }

        public int Rows => DataInputs.GetLength(0);
        public int Columns => DataInputs.GetLength(1);

        public TextBoxMatrix(int rows, int columns, int startX, int startY, IDataInputFactory dataInputFactory)
        {
            DataInputs = new IDataInput[rows, columns];
            InitializeDataInputs(startX, startY, dataInputFactory, 60, new Size(70, 35), Color.FromArgb(244, 245, 240));
        }

        private void InitializeDataInputs(int startX, int startY, IDataInputFactory dataInputFactory, int width, Size locationOffset, Color backColor)
        {
            var iterator = new MatrixIterator(new TextBoxMatrixWrapper(this));
            iterator.Iterate((row, col, value) =>
            {
                DataInputs[row, col] = CreateAndInitializeDataInput(dataInputFactory, startX, startY, row, col, width, locationOffset, backColor);
            });
        }

        private IDataInput CreateAndInitializeDataInput(IDataInputFactory dataInputFactory, int startX, int startY, int row, int col, int width, Size locationOffset, Color backColor)
        {
            var dataInput = dataInputFactory.CreateDataInput();
            dataInput.Width = width;
            dataInput.Location = new Point(startX + col * locationOffset.Width, startY + row * locationOffset.Height);
            dataInput.BackColor = backColor;
            return dataInput;
        }

        public IDataInput GetLastDataInput()
        {
            return (Rows > 0 && Columns > 0) ? DataInputs[Rows - 1, Columns - 1] : null;
        }
    }
}