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
        public int Height { get => matrix.GetLength(0); }
        public int Width { get => matrix.GetLength(1); }
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
            string s = "";
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    s += matrix[i, j].ToString() + (j + 1 < Width ? "\t" : "");
                }
                if (i + 1 < Height) s += "\n";
            }
            return s;
        }
        public MyMatrix(int height, int width)
        {
            if (height <= 0 || width <= 0)
            {
                throw new ArgumentException("Height and Width must be positive integers.");
            }
            matrix = new double[height, width];
            
        }
        public MyMatrix(MyMatrix other)
        {
            if (other == null)
                throw new ArgumentNullException(nameof(other));

            int h = other.Height;
            int w = other.Width;
            matrix = new double[h, w];
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    matrix[i, j] = other.matrix[i, j];
        }
        public MyMatrix(double[,] array)
        {
            if (matrix == null)
            {
                throw new ArgumentNullException("Matrix cannot be null.");
            }
            int h = array.GetLength(0);
            int w = array.GetLength(1);
            matrix = new double[h, w];
            Array.Copy(array, matrix, array.Length);
        }
        public MyMatrix(double[][] jagged)
        {
            if (jagged == null || jagged.Length == 0 || jagged[0].Length == 0)
            {
                throw new ArgumentException("Jagged matrix cannot be null or empty.");
            }
            int h = jagged.Length;
            int w = jagged[0].Length;

            for (int i = 1; i < h; i++)
            {
                if (jagged[i].Length != w)
                    throw new ArgumentException("Зубчастний масив не прямокутний.", nameof(jagged));

            }
            matrix = new double[h, w];
            for (int i = 0; i < h; i++)
                for (int j = 0; j < w; j++)
                    matrix[i, j] = jagged[i][j];
        }
        public MyMatrix(string multistring)
        {
            if (multistring == null)
                throw new ArgumentNullException(nameof(multistring));

            string[] lines = multistring.Split('\n', StringSplitOptions.RemoveEmptyEntries);
            new MyMatrix(lines).CopyTo(ref matrix);            
        }

        private void CopyTo(ref double[,] target)
        {
            target = new double[Height, Width];
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                    target[i, j] = matrix[i, j];
        }
        public MyMatrix(string[] strings)
        {
            if (strings == null || strings.Length == 0)
            {
                throw new ArgumentException("String array cannot be null or empty.");
            }
            int h = strings.Length;
            int w = strings[0].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Length;
            matrix = new double[h, w];
            for (int i = 0; i < Height; i++)
            {
                var cols = strings[i].Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
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
