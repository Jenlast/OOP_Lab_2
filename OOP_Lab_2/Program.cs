using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            MyMatrix matrixA = new MyMatrix();
            //matrixA.Input();
            Console.WriteLine($"Matrix A:{matrixA}");
        }
    }
}