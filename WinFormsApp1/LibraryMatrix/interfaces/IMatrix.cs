namespace LibraryMatrix.interfaces
{
    public interface IMatrix
    {
        int Rows { get; }
        int Columns { get; }
        double[,] MatrixArray { get; }
    }
}
