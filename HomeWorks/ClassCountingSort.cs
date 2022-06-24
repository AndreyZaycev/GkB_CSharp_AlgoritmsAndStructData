using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 8, дз : реализация класса сортировки подсчетом
    internal class ClassCountingSort
    {
        private int[] _inArray;
        private int _countElements;

        public ClassCountingSort(int[] inArray)
        {
            _inArray = inArray;
            _countElements = inArray.Length;
        }

        public int[] CountingSort()
        {
            //массив счетчиков
            int[] countArray = new int[_countElements];

            //заполнение массива счетчиков
            for (int i = 0; i < _countElements; i++)
            {
                for (int j = i + 1; j < _countElements; j++)
                {
                    if (_inArray[i] > _inArray[j])
                        countArray[i]++;
                    else
                        countArray[j]++;
                }
            }

            //отсортированный массив
            int[] outSortedArray = new int[_countElements];
            for (int i = 0; i < _countElements; i++) outSortedArray[countArray[i]] = _inArray[i];

            //
            return outSortedArray;
        }
    }

    internal class Lesson8Task : ILessons
    {
        public string Number => "12";

        public string Description => "Урок № 8, дз : проверка алгоритма сортировки подсчетом";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания урока № 8");

            //входной массив данных
            int[] inArray = new int[] { 10, -2, 3, 15, 24, -67, 45, 0, 1, 18, 0, 3, 15, 3 };
            Console.WriteLine($"Массив до сортировки : {string.Join(" ", inArray)}");

            //сортировка
            ClassCountingSort oSort = new ClassCountingSort(inArray);
            int[] sortArray = oSort.CountingSort();
            Console.WriteLine($"Массив после сортировки : {string.Join(" ", sortArray)}");
        }
    }
}
