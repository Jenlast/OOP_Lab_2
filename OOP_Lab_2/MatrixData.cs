using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OOP_Lab_2
{
    partial class MyMatrix
    {
        public int Height { get; private set; }
        public int Width { get; private set; }
        public MyMatrix() { }
        public int getHeight() => Height;
        public int getWidth() => Width;

        private double[,] matrix;

        public double this[int i, int j]
        {
            get
            {
                if (i < 0 || i >= Height || j < 0 || j >= Width)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                return matrix[i, j];
            }
            set
            {
                if (i < 0 || i >= Height || j < 0 || j >= Width)
                {
                    throw new IndexOutOfRangeException("Index out of range.");
                }
                matrix[i, j] = value;
            }
        }
        public double GetElement(int i, int j) => this[i, j];
        public void SetElement(int i, int j, double value) => this[i, j] = value;
        public override string ToString()
        {
           StringBuilder sb = new StringBuilder();
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    sb.Append(matrix[i, j].ToString("F2"));
                    if (j < Width - 1)
                    {
                        sb.Append("\t");
                    }
                }
                if (i < Height - 1)
                {
                    sb.AppendLine();
                }
            }
            return sb.ToString();
        }
        public MyMatrix(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("Height and Width must be positive integers.");
            }
            matrix = new double[height, width];
            Height = height;
            Width = width;
        }
        public MyMatrix(MyMatrix other)
        {
            Height = other.Height;
            Width = other.Width;
            matrix = new double[Height, Width];
            Buffer.BlockCopy(other.matrix, 0, matrix, 0, sizeof(double) * Height * Width);
        }
        public MyMatrix(double[,] matrix1)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix cannot be null.");
            }
            Height = matrix.GetLength(0);
            Width = matrix.GetLength(1);
            if (Height == 0 || Width == 0)
            {
                throw new ArgumentException("Matrix dimensions must be greater than zero.");
            }
            matrix = new double[Height, Width];
            Buffer.BlockCopy(matrix1, 0, matrix, 0, sizeof(double) * Height * Width);
        }
        public MyMatrix(double[][] jaggedMatrix)
        {
            if (jaggedMatrix == null || jaggedMatrix.Length == 0 || jaggedMatrix[0].Length == 0)
            {
                throw new ArgumentException("Jagged matrix cannot be null or empty.");
            }
            Height = jaggedMatrix.Length;
            Width = jaggedMatrix[0].Length;
            matrix = new double[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                if (jaggedMatrix[i] == null || jaggedMatrix[i].Length != Width)
                {
                    throw new ArgumentException("All rows in the jagged matrix must have the same length.");
                }
                for (int j = 0; j < Width; j++)
                {
                    matrix[i, j] = jaggedMatrix[i][j];
                }
            }
        }
        public MyMatrix(string matrixString)
        {
            if (string.IsNullOrWhiteSpace(matrixString))
            {
                throw new ArgumentException("Matrix string cannot be null or empty.");
            }
            var rows = matrixString.Split(new[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            Height = rows.Length;
            Width = rows[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                var cols = rows[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length != Width)
                {
                    throw new ArgumentException("All rows in the matrix string must have the same number of columns.");
                }
                for (int j = 0; j < Width; j++)
                {
                    if (!double.TryParse(cols[j], out matrix[i, j]))
                    {
                        throw new FormatException($"Invalid number format at row {i + 1}, column {j + 1}.");
                    }
                }
            }
        }
        public MyMatrix(string[] strings)
        {
            if (strings == null || strings.Length == 0)
            {
                throw new ArgumentException("String array cannot be null or empty.");
            }
            Height = strings.Length;
            Width = strings[0].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[Height, Width];
            for (int i = 0; i < Height; i++)
            {
                var cols = strings[i].Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (cols.Length != Width)
                {
                    throw new ArgumentException("All rows in the string array must have the same number of columns.");
                }
                for (int j = 0; j < Width; j++)
                {
                    if (!double.TryParse(cols[j], out matrix[i, j]))
                    {
                        throw new FormatException($"Invalid number format at row {i + 1}, column {j + 1}.");
                    }
                }
            }
        }
    }
}
