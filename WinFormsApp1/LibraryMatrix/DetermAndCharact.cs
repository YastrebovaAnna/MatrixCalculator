using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryMatrix
{
    public class DetermAndCharact : Matrix
    {
        public DetermAndCharact(int rows, int cols, double[,] matrixArray) : base(rows, cols, matrixArray)
        {

        }
        public double Determinant { get; protected set; }
        public double Rank { get; private set; }
        public double Trace { get; private set; }
        public double MinimumElement { get; private set; }
        public double MaximumElement { get; protected set; }
        public double MultElemMatrix { get; protected set; }
        public double SummElemMatrix { get; protected set; }
        public double MatrixNorm { get; protected set; }
        public double AverageElem { get; protected set; }
        public (double determinant, string explanation) CalculateDeterminant()
        {
            string explanation = " ";
            if (Rows != Columns)
            {
                throw new InvalidOperationException("Matrix must be square to calculate determinant.");
            }


            if (Rows == 1)
            {
                Determinant = MatrixArray[0, 0];
                explanation += $"Для матриці першого порядка значення визначника рівне значенню елемента цієї матриці, тобто {MatrixArray[0, 0]}";
            }
            else if (Rows == 2)
            {
                Determinant = MatrixArray[0, 0] * MatrixArray[1, 1] - MatrixArray[0, 1] * MatrixArray[1, 0];
                explanation = $"Для матриці 2×2 значення визначника рівне різниці добутку елементів головної та побічної діагоналей: {MatrixArray[0, 0]}*{MatrixArray[1, 1]} - {MatrixArray[0, 1]}*{MatrixArray[1, 0]} = {Determinant} ";
            }
            return (Determinant, explanation);
        }
        public (double Determinant, string explanation) CalculateDeterminantTriangleMethod()
        {
            string explanation = "";
                Determinant =
            MatrixArray[0, 0] * MatrixArray[1, 1] * MatrixArray[2, 2] +
            MatrixArray[0, 1] * MatrixArray[1, 2] * MatrixArray[2, 0] +
            MatrixArray[0, 2] * MatrixArray[1, 0] * MatrixArray[2, 1] -
            MatrixArray[0, 0] * MatrixArray[1, 2] * MatrixArray[2, 1] -
            MatrixArray[0, 1] * MatrixArray[1, 0] * MatrixArray[2, 2] -
            MatrixArray[0, 2] * MatrixArray[1, 1] * MatrixArray[2, 0];
            explanation += $"Розкладаємо матрицю на три трикутники та обчислюємо добутки по головних та бічних діагоналях:\r" +
                $" {MatrixArray[0, 0]} * {MatrixArray[1, 1]} * {MatrixArray[2, 2]} +" +
                $" {MatrixArray[0, 1]} * {MatrixArray[1, 2]} * {MatrixArray[2, 0]} +" +
                $" {MatrixArray[0, 2]} * {MatrixArray[1, 0]} * {MatrixArray[2, 1]} - " +
                $"{MatrixArray[0, 0]} * {MatrixArray[1, 2]} * {MatrixArray[2, 1]} - " +
                $"{MatrixArray[0, 1]} * {MatrixArray[1, 0]} * {MatrixArray[2, 2]} -" +
                $" {MatrixArray[0, 2]} * {MatrixArray[1, 1]} * {MatrixArray[2, 0]} = {Determinant}";
            return (Determinant, explanation);
        }
        public (double Determinant, string explanation) CalculateDeterminantSarrus()
        {
            string explanation = "";
             Determinant =
            MatrixArray[0, 0] * MatrixArray[1, 1] * MatrixArray[2, 2] +
            MatrixArray[0, 1] * MatrixArray[1, 2] * MatrixArray[2, 0] +
            MatrixArray[0, 2] * MatrixArray[1, 0] * MatrixArray[2, 1] -
            MatrixArray[0, 2] * MatrixArray[1, 1] * MatrixArray[2, 0] -
            MatrixArray[0, 0] * MatrixArray[1, 2] * MatrixArray[2, 1] -
            MatrixArray[0, 1] * MatrixArray[1, 0] * MatrixArray[2, 2];
            explanation += $"Обчислюємо добутки елементів матриці по двом діагоналям та віднімаємо суми добутків одна від одної:\r" +
                $"{MatrixArray[0, 0]} * {MatrixArray[1, 1]} * {MatrixArray[2, 2]} +" +
                $" {MatrixArray[0, 1]} * {MatrixArray[1, 2]} * {MatrixArray[2, 0]} + " +
                $"{MatrixArray[0, 2]} * {MatrixArray[1, 0]} * {MatrixArray[2, 1]} - " +
                $"{MatrixArray[0, 2]} * {MatrixArray[1, 1]} * {MatrixArray[2, 0]} - " +
                $"{MatrixArray[0, 0]} * {MatrixArray[1, 2]} * {MatrixArray[2, 1]} -" +
                $" {MatrixArray[0, 1]} * {MatrixArray[1, 0]} * {MatrixArray[2, 2]} = {Determinant}";
            return (Determinant, explanation);
        }
        public double CalculateDeterminantGauss()
        {
            int size = Rows;
            double[,] matrix = (double[,])MatrixArray.Clone();

            TransposableMatrix transposableMatrix = new TransposableMatrix(Rows, Columns, matrix);
            transposableMatrix.ConvertToTriangularFormGausJordan();

            Determinant = 1.0;

            for (int i = 0; i < size; i++)
            {
                Determinant *= transposableMatrix.MatrixArray[i, i];
            }

            return Determinant;
        }
         public (int rank, string explanation) CalculateRank()
         {
            int rows = Rows;
            int cols = Columns;
            int rank = 0;
            string explanation = "";

            double[,] transformedMatrix = (double[,])MatrixArray.Clone();
            explanation += $"Обчислення рангу матриці {Environment.NewLine}";
            int currentRow = 0;

            for (int col = 0; col < cols; col++)
            {
                int maxRowIndex = currentRow;
                double maxValue = Math.Abs(transformedMatrix[currentRow, col]);

                for (int row = currentRow + 1; row < rows; row++)
                {
                    double value = Math.Abs(transformedMatrix[row, col]);
                    if (value > maxValue)
                    {
                        maxRowIndex = row;
                        maxValue = value;
                    }
                }

                if (maxValue == 0)
                {
                    continue;
                }

                if (maxRowIndex != currentRow)
                {
                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        double temp = transformedMatrix[currentRow, colIndex];
                        transformedMatrix[currentRow, colIndex] = transformedMatrix[maxRowIndex, colIndex];
                        transformedMatrix[maxRowIndex, colIndex] = temp;
                    }

                    explanation += $"Поміняли місцями рядки {currentRow + 1} і {maxRowIndex + 1}{Environment.NewLine}";
                }

                explanation += $"Робимо нульовими всі елементи під діагоналлю в {col + 1} стовпці{Environment.NewLine}";

                for (int row = currentRow + 1; row < rows; row++)
                {
                    double factor = transformedMatrix[row, col] / transformedMatrix[currentRow, col];

                    for (int colIndex = 0; colIndex < cols; colIndex++)
                    {
                        transformedMatrix[row, colIndex] -= factor * transformedMatrix[currentRow, colIndex];
                    }
                    explanation += $"Від рядка {currentRow + 1} відняли {factor} * рядок {row + 1}{Environment.NewLine}";
                }

                rank++;
                currentRow++;
                explanation += $"Матриця після кроку {rank}:{Environment.NewLine}";
                for (int i = 0; i < rows; i++)
                {
                    for (int j = 0; j < cols; j++)
                    {
                        explanation += $"{transformedMatrix[i, j],-8:N2} ";
                    }
                    explanation += Environment.NewLine;
                }
                explanation += Environment.NewLine;
            }

            return (rank, explanation);
        }
        public double[,] CreateSubMatrix(double[,] matrix, int excludeRow, int excludeCol)
        {
            int size = matrix.GetLength(0);
            double[,] subMatrix = new double[size - 1, size - 1];

            int rowIndex = 0;
            for (int row = 0; row < size; row++)
            {
                if (row == excludeRow)
                    continue;

                int colIndex = 0;
                for (int col = 0; col < size; col++)
                {
                    if (col == excludeCol)
                        continue;

                    subMatrix[rowIndex, colIndex] = matrix[row, col];
                    colIndex++;
                }

                rowIndex++;
            }

            return subMatrix;
        }
        public (double Trace, string explanation) CalculateTrace()
        {
            Trace = 0;
            string explanation = " ";

            for (int i = 0; i < Rows; i++)
            {
                Trace += MatrixArray[i, i];
            }
            explanation = $"Слід матриці — це сума усіх її діагональних елементів";
            return (Trace, explanation);
        }
        public void FindMinimumElement()
        {
            double minElement = MatrixArray[0, 0];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (MatrixArray[row, col] < minElement)
                    {
                        minElement = MatrixArray[row, col];
                    }
                }
            }

            MinimumElement = minElement;
        }

        public void FindMaximumElement()
        {
            double maxElement = MatrixArray[0, 0];

            for (int row = 0; row < Rows; row++)
            {
                for (int col = 0; col < Columns; col++)
                {
                    if (MatrixArray[row, col] > maxElement)
                    {
                        maxElement = MatrixArray[row, col];
                    }
                }
            }

            MaximumElement = maxElement;
        }
        public void MatrixNormal()
        {
            double norm = 0;

            for (int i = 0; i < Rows; i++)
            {
                double rowSum = 0;

                for (int j = 0; j < Columns; j++)
                {
                   rowSum += Math.Abs(MatrixArray[i, j]);
                }
                norm = Math.Max(norm, rowSum);
            }
            MatrixNorm = norm;
        }
        public void MultElem()
        {
            double mult = 1;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    mult *= MatrixArray[i, j];
                }
            }
            MultElemMatrix = mult;
        }
        public void SummElem()
        {
            double sum = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    sum += MatrixArray[i, j];
                }
            }
            SummElemMatrix = sum;
        }
        public void Average()
        {
            double sum = 0;
            int count = 0;
            double average = 0;
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    sum += MatrixArray[i, j];
                    count++;
                }
            }
            average = (double)sum / count;
            AverageElem = average;
        }
    }
}


