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
}
