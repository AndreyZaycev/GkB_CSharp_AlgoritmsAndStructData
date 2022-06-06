using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Lesson1Task2 : ILessons
    {
        public string Number => "2";

        public string Description => "Урок № 1, дз № 2 : cложность функции StrangeSum(int[] inputArray)";

        public void Run()
        {
            Console.WriteLine("\nРешение домашнего задания № 2 урока № 1");
            Console.WriteLine("Cложность функции StrangeSum(int[] inputArray) = O(3*N*N*N+2) = O(N*N*N)");
        }
    }
}
