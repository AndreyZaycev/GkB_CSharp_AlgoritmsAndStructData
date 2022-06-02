using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 1, дз № 1 : класс проверки, простое число или нет
    internal class ClassCheckingPrimeNumber
    {
        private int _number;

        public ClassCheckingPrimeNumber(int number)
        {
            _number = number;
        }

        public bool IsCheckingPrimeNumber()
        {
            int d = 0, i = 2;
            while (i < _number)
            {
                if (_number % i == 0)
                {
                    d++;
                    i++;
                }
                else
                {
                    i++;
                }
            }
            return (d == 0) ? true : false;
        }
    }

    internal class Lesson1Task1 : ILessons
    {
        public string Number => "1";

        public string Description => "Урок № 1, дз № 1 : проверка, простое число или нет";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 1 урока № 1");

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
    }


}
