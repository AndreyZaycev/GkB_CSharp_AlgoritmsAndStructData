using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //общий класс для всего курса : класс меню
    internal class ClassMenu
    {
        private List<string> _listNamePunktMenu;
        private int _maxPunktMenu;

        public ClassMenu(List<string> listNamePunktMenu)
        {
            _listNamePunktMenu = listNamePunktMenu;
            _maxPunktMenu = _listNamePunktMenu.Count;
        }

        //получить меню 
        public void GetMenu()
        {
            Console.WriteLine("------------------- МЕНЮ -------------------");
            for (int i = 0; i < _listNamePunktMenu.Count; i++)
                Console.WriteLine($"Пункт {i + 1} - {_listNamePunktMenu[i]}");
            Console.WriteLine("--------------------------------------------");
        }

        //получить пункт меню
        public int GetPunktMenu()
        {
            int numPunktMenu;
            do
            {
                Console.Write($"\nВведите пункт меню (число от 1 до {_maxPunktMenu}) : ");
                numPunktMenu = GetCorrectNumber(Console.ReadLine());
                if (numPunktMenu >= 1 && numPunktMenu <= _maxPunktMenu)
                    break;
                else
                    Console.WriteLine($"Пункт меню № {numPunktMenu} в списке отсутствует.");
            }
            while (true);
            return numPunktMenu;
        }

        #region(получить корректное значения при выборе пункта меню)
        private int GetCorrectNumber(string sNumber)
        {
            int outNumber;
            bool bNumber = int.TryParse(sNumber, out outNumber);
            return (bNumber) ? outNumber : 0;
        }
        #endregion
    }
}
