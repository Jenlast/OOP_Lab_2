using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFrac
{
    public class MyFracMenu
    {
        public static void Display()
        {
            MyFrac? f1 = null;
            MyFrac? f2 = null;

            while (true)
            {
                Console.WriteLine("\n==== МЕНЮ ЗАВДАННЯ 2 – Клас MyFrac ====");
                Console.WriteLine("1. Створити дріб f1");
                Console.WriteLine("2. Створити дріб f2");
                Console.WriteLine("3. Вивести дроби f1 та f2 (звичайний формат)");
                Console.WriteLine("4. Вивести f1 та f2 як ціла частина + дріб");
                Console.WriteLine("5. Вивести f1 та f2 у вигляді десяткового числа");
                Console.WriteLine("6. f1 + f2");
                Console.WriteLine("7. f1 - f2");
                Console.WriteLine("8. f1 * f2");
                Console.WriteLine("9. f1 / f2");
                Console.WriteLine("10. Обчислити CalcExpr1(n)");
                Console.WriteLine("11. Обчислити CalcExpr2(n)");
                Console.WriteLine("0. Повернутися до головного меню");

                Console.Write("Виберіть дію (0–11): ");
                string choice = Console.ReadLine()!;
                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case "1":
                            f1 = ReadFrac("f1");
                            break;

                        case "2":
                            f2 = ReadFrac("f2");
                            break;

                        case "3":
                            Console.WriteLine("f1: " + (f1 != null ? f1.ToString() : "Не створений."));
                            Console.WriteLine("f2: " + (f2 != null ? f2.ToString() : "Не створений."));
                            break;

                        case "4":
                            if (CheckFracs(f1, f2))
                            {
                                Console.WriteLine("f1 = " + f1!.ToStringWithIntPart());
                                Console.WriteLine("f2 = " + f2!.ToStringWithIntPart());
                            }
                            break;

                        case "5":
                            if (CheckFracs(f1, f2))
                            {
                                Console.WriteLine("f1 = " + f1!.ToDouble());
                                Console.WriteLine("f2 = " + f2!.ToDouble());
                            }
                            break;

                        case "6":
                            if (CheckFracs(f1, f2))
                                Console.WriteLine("f1 + f2 = " + (f1! + f2!));
                            break;

                        case "7":
                            if (CheckFracs(f1, f2))
                                Console.WriteLine("f1 - f2 = " + (f1! - f2!));
                            break;

                        case "8":
                            if (CheckFracs(f1, f2))
                                Console.WriteLine("f1 * f2 = " + (f1! * f2!));
                            break;

                        case "9":
                            if (CheckFracs(f1, f2))
                                Console.WriteLine("f1 / f2 = " + (f1! / f2!));
                            break;

                        case "10":
                            Console.Write("Введіть n: ");
                            int n1 = int.Parse(Console.ReadLine()!);
                            Console.WriteLine("CalcExpr1(n) = " + MyFrac.CalcExpr1(n1));
                            break;

                        case "11":
                            Console.Write("Введіть n: ");
                            int n2 = int.Parse(Console.ReadLine()!);
                            Console.WriteLine("CalcExpr2(n) = " + MyFrac.CalcExpr2(n2));
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


            static MyFrac ReadFrac(string name)
            {
                Console.WriteLine($"Введіть дріб {name}:");

                Console.Write("Чисельник: ");
                long nom = long.Parse(Console.ReadLine()!);

                Console.Write("Знаменник: ");
                long denom = long.Parse(Console.ReadLine()!);

                return new MyFrac(nom, denom);
            }

            static bool CheckFracs(MyFrac? f1, MyFrac? f2)
            {
                if (f1 == null || f2 == null)
                {
                    Console.WriteLine("Потрібно створити обидва дроби.");
                    return false;
                }
                return true;
            }
        }
    }
}