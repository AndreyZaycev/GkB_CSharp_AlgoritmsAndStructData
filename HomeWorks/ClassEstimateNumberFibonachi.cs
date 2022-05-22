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
}
