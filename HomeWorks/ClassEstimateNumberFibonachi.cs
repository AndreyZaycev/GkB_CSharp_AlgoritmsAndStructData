using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 1, дз № 3 : класс вычисления числа Фибоначчи
    internal class ClassEstimateNumberFibonachi
    {
        public static long GetNumberFibonachiRecursivMetod(long n)
        {
            if (n == 0 || n == 1) return n;
            return GetNumberFibonachiRecursivMetod(n - 1) + GetNumberFibonachiRecursivMetod(n - 2);
        }

        public static long GetNumberFibonachiNonRecursivMetod(long n)
        {
            long result = 0, number = 1, temp;
            for (long i = 0; i < n; i++)
            {
                temp = result;
                result = number;
                number += temp;
            }
            return result;
        }
    }

    internal class Lesson1Task3 : ILessons
    {
        public string Number => "3";

        public string Description => "Урок № 1, дз № 3 : вычисление числа Фибоначчи";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 3 урока № 1");

            //
            long number;
            bool bNumber = false;
            do
            {
                Console.Write("Введите член последовательности Фибоначчи (целое положительное число) : ");
                bNumber = long.TryParse(Console.ReadLine(), out number);
                if (!bNumber || number < 0)
                {
                    Console.WriteLine("Некорректный ввод! Введите член последовательности Фибоначчи (целое положительное число) повторно");
                    bNumber = false;
                }
            }
            while (!bNumber);

            //
            long numFibonachiRecursivMetod = ClassEstimateNumberFibonachi.GetNumberFibonachiRecursivMetod(number);
            long numFibonachiNonRecursivMetod = ClassEstimateNumberFibonachi.GetNumberFibonachiNonRecursivMetod(number);
            Console.WriteLine($"{number} член последовательности Фибоначчи, определенный рекурсивным методом, равен {numFibonachiRecursivMetod}");
            Console.WriteLine($"{number} член последовательности Фибоначчи, определенный не рекурсивным методом, равен {numFibonachiNonRecursivMetod}");
        }
    }


}
