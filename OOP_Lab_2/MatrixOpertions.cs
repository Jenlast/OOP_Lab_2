using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    partial class MyMatrix
    {
        public void Input()
        {
            Console.Write("Enter number of rows (Height): ");
            Height = int.Parse(Console.ReadLine());
            Console.Write("Enter number of columns (Width): ");
            Width = int.Parse(Console.ReadLine());
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    Console.Write($"Enter element [{i}, {j}]: ");
                    string input = Console.ReadLine();
                    if (double.TryParse(input, out double value))
                    {
                        matrix[i, j] = value;
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                        j--; // Decrement j to repeat the input for this element
                    }
                }
            }
        }
        public static MyMatrix operator +(MyMatrix a, MyMatrix b)
        {
            if (a.Height != b.Height || a.Width != b.Width)
            {
                throw new InvalidOperationException("Matrices must have the same dimensions for addition.");
            }
            MyMatrix result = new MyMatrix(a.Height, a.Width);
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < a.Width; j++)
                {
                    result[i, j] = a[i, j] + b[i, j];
                }
            }
            return result;
        }
        public static MyMatrix operator *(MyMatrix a, MyMatrix b)
        {
            if (a.Width != b.Height)
            {
                throw new InvalidOperationException("Number of columns in the first matrix must equal the number of rows in the second matrix for multiplication.");
            }
            MyMatrix result = new MyMatrix(a.Height, b.Width);
            for (int i = 0; i < a.Height; i++)
            {
                for (int j = 0; j < b.Width; j++)
                {
                    double sum = 0;
                    for (int k = 0; k < a.Width; k++)
                    {
                        sum += a[i, k] * b[k, j];
                    }
                    result[i, j] = sum;
                }
            }
            return result;
        }
        private double[,] GetTransponedArray()
        {
            double[,] transponed = new double[Width, Height];
            for (int i = 0; i < Height; i++)
            {
                for (int j = 0; j < Width; j++)
                {
                    transponed[j, i] = matrix[i, j];
                }
            }
            return transponed;
        }
        public MyMatrix GetTransponedCopy()
        {
            double[,] transponedArray = GetTransponedArray();
            return new MyMatrix(transponedArray);
        }
        public void TransponeMe()
        {
            matrix = GetTransponedArray();
            int temp = Height;
            Height = Width;
            Width = temp;
        }
    }
}
