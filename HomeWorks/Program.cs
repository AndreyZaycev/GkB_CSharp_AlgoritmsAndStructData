using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Program
    {
        #region(ДОПОЛНЯЕМЫЙ МЕТОД - СПИСОК НАИМЕНОВАНИЙ ПУНКТОВ МЕНЮ)
        static List<string> GetListHomeWorkForMenu()
        {
            List<string> outList = new List<string>();
            outList.Add("Урок № 1, домашнее задание № 1");
            outList.Add("Урок № 1, домашнее задание № 2");
            outList.Add("Урок № 1, домашнее задание № 3");
            return outList;
        }
        #endregion

        //Урок № 1, дз № 1: Отдельный метод для проверки, простое число или нет
        static void CheckPrimeNumber()
        {
            //
            Console.WriteLine("Решение домашнего задания № 1 урока № 1");

            //
            int number;
            bool bNumber = false;
            do
            {
                Console.Write("Введите целое положительное (натуральное) число : ");
                bNumber = int.TryParse(Console.ReadLine(), out number);
                if (!bNumber || number < 0)
                {
                    Console.WriteLine("Некорректный ввод! Введите целое положительное (натуральное) число повторно");
                    bNumber = false;
                }
            }
            while (!bNumber);

            //
            ClassCheckingPrimeNumber obCheck = new ClassCheckingPrimeNumber(number);
            Console.WriteLine((obCheck.IsCheckingPrimeNumber()) ? $"Число {number} простое" : $"Число {number} не простое");
        }

        //Урок № 1, дз № 3: Отдельный метод для проверки вычисления числа Фибоначчи
        static void CheckEstimateNumberFibonachi()
        {
            //
            Console.WriteLine("Решение домашнего задания № 3 урока № 1");

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
        
        static void Main(string[] args)
        {
            bool bExit = true;
            do
            {
                ClassBackgroundInformation.GetBackgroundInformation();
                ClassMenu oMenu = new ClassMenu(GetListHomeWorkForMenu());
                oMenu.GetMenu();
                int numPunktMenu = oMenu.GetPunktMenu();
                switch (numPunktMenu)
                {
                    case 1: CheckPrimeNumber(); break;
                    case 2:
                        Console.WriteLine("Решение домашнего задания № 2 урока № 1");
                        Console.WriteLine("Cложность функции StrangeSum(int[] inputArray) = O(3*N*N*N+2) = O(N*N*N)"); break;
                    case 3: CheckEstimateNumberFibonachi(); break;
                }
                Console.Write("\nДля продолжения работы нажмите любую клавишу, для окончания n : ");
                bExit = (Console.ReadLine() == "n") ? false : true;
                Console.Clear();
            }
            while (bExit);
        }
    }
}
