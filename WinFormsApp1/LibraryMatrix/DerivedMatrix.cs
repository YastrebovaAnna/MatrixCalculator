using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix
{
    public class TransposableMatrix : DetermAndCharact
    {
        public Matrix L { get; private set; }
        public Matrix U { get; private set; }
        public double[,] TriangularMatrix { get; set; }
        public string Explanation { get; set; }
        public TransposableMatrix(int rows, int cols, double[,] matrixArray) : base(rows, cols, matrixArray)
        {

        }
        public TransposableMatrix Transpose()
        {
            int transposedRows = Columns;
            int transposedCols = Rows;
            double[,] transposedMatrixArray = new double[transposedRows, transposedCols];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    transposedMatrixArray[j, i] = MatrixArray[i, j];
                }
            }

            TransposableMatrix transposedMatrix = new TransposableMatrix(transposedRows, transposedCols, transposedMatrixArray);
            return transposedMatrix;
        }
        public double CalculateDeterminantRecursive(double[,] matrix)
        {
            int size = matrix.GetLength(0);

            if (size == 1)
            {
                return matrix[0, 0];
            }
            else
            {
                double determinant = 0;

                for (int j = 0; j < size; j++)
                {
                    double[,] subMatrix = CreateSubMatrix(matrix, 0, j);
                    double subDeterminant = CalculateDeterminantRecursive(subMatrix);

                    determinant += Math.Pow(-1, j) * matrix[0, j] * subDeterminant;
                }

                return determinant;
            }
        }
        public TransposableMatrix Invert()
        {
            int size = Rows;
            string explanation = "";
            double[,] invertedMatrixArray = new double[size, size];

            double determinant = CalculateDeterminantRecursive(MatrixArray);
            explanation += $"Детермінант вихідної матриці: {determinant}  {Environment.NewLine}\r";

            if (determinant == 0)
            {
                MessageBox.Show("Детермінант дорівнює 0", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null; 
            }

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    double[,] subMatrix = CreateSubMatrix(MatrixArray, i, j);
                    double subDeterminant = CalculateDeterminantRecursive(subMatrix);

                    double cofactor = Math.Pow(-1, i + j) * subDeterminant;
                    invertedMatrixArray[j, i] = cofactor / determinant; 
                }
            }

            TransposableMatrix invertedMatrix = new TransposableMatrix(size, size, invertedMatrixArray)
            {
                Explanation = explanation
            };
            return invertedMatrix;
        }

        public TransposableMatrix RotateClockwise() 
        {
            double[,] rotatedMatrixArray = new double[Columns, Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    rotatedMatrixArray[j, Rows - 1 - i] = MatrixArray[i, j];
                }
            }

            TransposableMatrix rotatedMatrix = new TransposableMatrix(Columns, Rows, rotatedMatrixArray);
            return rotatedMatrix;
        }
        public TransposableMatrix RotateCounterClockwise() 
        {
            double[,] rotatedMatrixArray = new double[Columns, Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    rotatedMatrixArray[Columns - 1 - j, i] = MatrixArray[i, j];
                }
            }
            TransposableMatrix rotatedMatrix = new TransposableMatrix(Columns, Rows, rotatedMatrixArray);
            return rotatedMatrix;
        }
        public TransposableMatrix ConvertToTriangularFormGausJordan()
        {
            string explanation = "";
            for (int k = 0; k < Math.Min(Rows, Columns); k++)
            {
                int maxRowIndex = k;
                double maxRowValue = Math.Abs(MatrixArray[k, k]);

                for (int i = k + 1; i < Rows; i++)
                {
                    double currentValue = Math.Abs(MatrixArray[i, k]);
                    if (currentValue > maxRowValue)
                    {
                        maxRowIndex = i;
                        maxRowValue = currentValue;
                    }
                }

                if (maxRowValue == 0)
                {
                    continue;
                }

                SwapRows(k, maxRowIndex);
                explanation += $"Обміняли рядок {k} і рядок з найбільшим елементом {maxRowIndex } у стовпці {k} {Environment.NewLine}\r";

                double pivot = MatrixArray[k, k];

                for (int i = k + 1; i < Rows; i++)
                {
                    double factor = MatrixArray[i, k] / pivot;

                    for (int j = k; j < Columns; j++)
                    {
                        MatrixArray[i, j] -= factor * MatrixArray[k, j];
                    }
                    explanation += $"Від рядка {k} відняли {factor} * рядок {i} {Environment.NewLine}\r";
                }
                explanation += $"Матриця після кроку {k + 1}:{Environment.NewLine}\r";

                for (int i = 0; i < Rows; i++)
                {
                    for (int j = 0; j < Columns; j++)
                    {
                        explanation += $"{MatrixArray[i, j],-8:N2} ";
                    }
                    explanation += Environment.NewLine;
                }
                explanation += Environment.NewLine;
            }

            return new TransposableMatrix(Rows, Columns, MatrixArray)
            {
                TriangularMatrix = MatrixArray,
                Explanation = explanation
            };
        }
        public TransposableMatrix ConvertToDiagonalForm()
        {
            string explanation = "";

            for (int col = 0; col < Columns; col++)
            {
                int nonzeroRow = -1;
                for (int row = col; row < Rows; row++)
                {
                    if (Math.Abs(MatrixArray[row, col]) > double.Epsilon)
                    {
                        nonzeroRow = row;
                        break;
                    }
                }
                if (nonzeroRow != -1)
                {
                    SwapRows(col, nonzeroRow);
                    explanation += $"Обміняли стовбець {col + 1} і рядок {nonzeroRow + 1} {Environment.NewLine}\r";
                    double factor = 1.0 / MatrixArray[col, col];
                    ScaleRow(col, factor);
                    explanation += $"Масштабували рядок {col + 1} на {factor} {Environment.NewLine}\r";
                    for (int row = 0; row < Rows; row++)
                    {
                        if (row != col)
                        {
                            double multiplier = -MatrixArray[row, col];
                            AddMultipleOfRow(row, col, multiplier);
                            explanation += $"До рядка {row + 1} додали {multiplier} * рядок {col + 1} {Environment.NewLine}\r";
                        }
                    }
                }
                explanation += $"Матриця після кроку {col + 1}:{Environment.NewLine}\r";
                for (int row = 0; row < Rows; row++)
                {
                    for (int c = 0; c < Columns; c++)
                    {
                        explanation += $"{MatrixArray[row, c],-8:N2} ";
                    }
                    explanation += Environment.NewLine;
                }
                explanation += Environment.NewLine;
            }
            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    MatrixArray[row, col] = Math.Abs(MatrixArray[row, col]) < double.Epsilon ? 0 : MatrixArray[row, col];
                }
            }
            return new TransposableMatrix(Rows, Columns, MatrixArray)
            {
                TriangularMatrix = MatrixArray,
                Explanation = explanation
            };
        }
        public void PerformLUDecomposition()
        {
            double[,] L = new double[Rows, Rows];

            double[,] U = new double[Rows, Rows];

            for (int i = 0; i < Rows; i++)
            {
                for (int j = i; j <Rows; j++)
                {
                    double sum = 0.0;
                    for (int k = 0; k < i; k++)
                    {
                        sum += L[i, k] * U[k, j];
                    }
                    U[i, j] = MatrixArray[i, j] - sum;
                }

                for (int j = i; j < Rows; j++)
                {
                    if (i == j)
                    {
                        L[i, i] = 1.0;
                    }
                    else
                    {
                        double sum = 0.0;
                        for (int k = 0; k < i; k++)
                        {
                            sum += L[j, k] * U[k, i];
                        }
                        L[j, i] = (MatrixArray[j, i] - sum) / U[i, i];
                    }
                }
            }
        }
            public void ScaleRow(int rowIndex, double scaleFactor)
            {
                for (int col = 0; col < Columns; col++)
                {
                    MatrixArray[rowIndex, col] *= scaleFactor;
                }
            }

            public void AddMultipleOfRow(int targetRowIndex, int sourceRowIndex, double multiplier)
            {
                for (int col = 0; col < Columns; col++)
                {
                    MatrixArray[targetRowIndex, col] += multiplier * MatrixArray[sourceRowIndex, col];
                }
            }
        public void SwapRows(int row1, int row2)
            {
                for (int j = 0; j < Columns; j++)
                {
                    double temp = MatrixArray[row1, j];
                    MatrixArray[row1, j] = MatrixArray[row2, j];
                    MatrixArray[row2, j] = temp;
                }
            }
        public void SwapColumns(int column1, int column2)
        {
            for (int i = 0; i < Rows; i++)
            {
                double temp = MatrixArray[i, column1];
                MatrixArray[i, column1] = MatrixArray[i, column2];
                MatrixArray[column2, i] = temp;
            }
        }
    }
}

