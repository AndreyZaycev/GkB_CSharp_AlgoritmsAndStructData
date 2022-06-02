using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 2, дз № 2 : класс алгоритма бинарного поиска
    internal class ClassBinarySearch
    {
        private List<int> _inList;
        private int _searchValue;

        public ClassBinarySearch(List<int> inList, int searchValue)
        {
            //предусловие для алгоритма бинарного поиска - сортировка (сортировка через LINK)
            _inList = inList.OrderBy(i => i).ToList();
            _searchValue = searchValue;
        }

        public int BinarySearch()
        {
            int min = 0, max = _inList.Count - 1, mid;
            while (min <= max)
            {
                mid = (min + max) / 2;
                if (_searchValue == _inList[mid]) return mid;
                if (_searchValue < _inList[mid]) max = mid - 1; else min = mid + 1;
            }
            return -1;

            /*
            return _inList.BinarySearch(_searchValue);  //ИЛИ ТАК
            */
        }
    }

    internal class Lesson2Task2 : ILessons
    {
        public string Number => "5";

        public string Description => "Урок № 2, дз № 2 : проверка работы алгоритма бинарного поиска";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 2 урока № 2");

            //
            List<int> inList = new List<int> { 1, 0, -3, 12, 45, 7, 14, -98, 111, -33 };
            string sList = string.Join(" ", inList);

            //
            Console.WriteLine("Асимптотическая сложность алгоритма бинарного поиска = O(log n) — логарифмическая сложность");

            //отрицательный сценарий (в inArray отсутствует searchValue)
            _Check(29);

            //положительный сценарий (в inArray присутствует searchValue)
            _Check(111);

            //положительный сценарий (в inArray присутствует searchValue)
            _Check(-98);

            //положительный сценарий (в inArray присутствует searchValue)
            _Check(12);

            //локальная функция
            void _Check(int _searchValue)
            {
                ClassBinarySearch obBinSearch = new ClassBinarySearch(inList, _searchValue);
                string sResult = (obBinSearch.BinarySearch() >= 0) ? $"Значение {_searchValue} в списке {sList} присутствует"
                                                                   : $"Значение {_searchValue} в списке {sList} отсутствует";
                Console.WriteLine(sResult);
            }
        }
    }

}
