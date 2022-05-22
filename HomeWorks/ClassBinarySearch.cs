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
}
