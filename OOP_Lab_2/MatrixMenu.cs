using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_Lab_2
{
    public class MatrixMenu
    {
        static MyMatrix? A = null;
        static MyMatrix? B = null;
        public static void Display()
        {
            while (true)
            {
                Console.WriteLine("\n==== МЕНЮ ЗАВДАННЯ 1 - Клас MyMatrix ====");
                Console.WriteLine("1. Створити матрицю A");
                Console.WriteLine("2. Створиит матрицю B");
                Console.WriteLine("3. Вивести матриці A і B");
                Console.WriteLine("4. A + B");
                Console.WriteLine("5. A * B");
                Console.WriteLine("6. Транспонувати A");
                Console.WriteLine("7. Транспонувати B");
                Console.WriteLine("0. Повернутися до головного меню");
                Console.Write("Виберіть дію (0-7): ");

                string choice = Console.ReadLine()!;
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            A = CreateMatrix("A");
                            break;
                        case "2":
                            B = CreateMatrix("B");
                            break;
                        case "3":
                            PrintMatrices();
                            break;
                        case "4":
                            if (CheckAB())
                                Console.WriteLine("A + B = \n" + (A + B));
                            break;
                        case "5":
                            if (CheckAB())
                                Console.WriteLine("A * B = \n" + (A * B));
                            break;
                        case "6":
                            if (A != null)
                            {
                                A.TransponeMe();
                                Console.WriteLine("Матриця A транспонована.");
                            }
                            else Console.WriteLine("Матриця A не створена.");
                            break;
                        case "7":
                            if (B != null)
                            {
                                B.TransponeMe();
                                Console.WriteLine("Матриця B транспонована.");
                            }
                            else Console.WriteLine("Матриця B не створена.");
                            break;
                        case "0":
                            return;
                        default:
                            Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка: " + ex.Message);
                }
            }
            static MyMatrix CreateMatrix(string name)
            {
                Console.WriteLine($"Введіть матрицю {name} у форматі рядків:");
                string input = "";
                string line;
                Console.WriteLine("Вводьте рядки. Пустий рядок - завершити:");
                while (true)
                {
                    line = Console.ReadLine()!;
                    if (string.IsNullOrWhiteSpace(line))
                        break;
                    input += line + "\n";
                }

                try
                {
                    MyMatrix m = new MyMatrix(input);
                    Console.WriteLine($"Матриця {name} створена ({m.Height}x{m.Width}).");
                    return m;
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Помилка створення матриці: " + ex.Message);
                    return null;
                }
            }

            static void PrintMatrices()
            {
                Console.WriteLine("Матриця A:");
                Console.WriteLine(A != null ? A : "Не створена.");

                Console.WriteLine("Матриця B:");
                Console.WriteLine(B != null ? B : "Не створена.");
            }

            static bool CheckAB()
            {
                if (A == null || B == null)
                {
                    Console.WriteLine("Обидві матриці повинні бути створені.");
                    return false;
                }
                return true;
            }
        }
    }
}
