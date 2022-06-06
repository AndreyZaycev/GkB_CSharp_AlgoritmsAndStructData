using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace HomeWorks
{
    //Урок № 4, дз № 2: Класс для определения времени проверки наличия строки в HashSet, массиве, списке (List)
    internal class ClassTimePerformanceHashMassivList
    {
        //поле - количество элементов в коллекции
        private int _totalElements;

        //поле - количество символов (букв) в случайной строке
        private int _nSymbols;

        //поле - массив символов (букв), из которых будем формировать случайную строку
        private char[] _letters;

        //поле - количество символов (букв) в массиве _letters
        private int _nLetters;

        //поле - список случайных строк
        private List<string> _listRandomString;

        //поле - строка поиска
        private string _findString;

        //поля - время выполнения кода
        private string _timePerformanceHash, _timePerformanceMassiv, _timePerformanceList;

        //свойства
        public string TimePerformanceHash { get => _timePerformanceHash; set => _timePerformanceHash = value; }
        public string TimePerformanceMassiv { get => _timePerformanceMassiv; set => _timePerformanceMassiv = value; }
        public string TimePerformanceList { get => _timePerformanceList; set => _timePerformanceList = value; }

        //конструктор
        public ClassTimePerformanceHashMassivList(int totalElements)
        {
            _totalElements = totalElements;
            _nSymbols = 20;
            _letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ".ToCharArray();
            _nLetters = _letters.Length - 1;
            _listRandomString = GetListRandomString();
            _findString = _listRandomString[_listRandomString.Count / 2];
        }

        //метод - получение списка случайных строк
        private List<string> GetListRandomString()
        {
            //генератор случайных чисел
            Random rand = new Random();

            //формирование списка случайных строк
            List<string> outListData = new List<string>();
            for (int j = 0; j < _totalElements; j++)
            {
                string tempWord = "";
                for (int i = 0; i < _nSymbols; i++) tempWord += _letters[rand.Next(0, _nLetters)];
                outListData.Add(tempWord);
            }

            return outListData;
        }

        //метод - вычисление времени для HashSet
        private void SetTimePerformanceHash()
        {
            //создание и инициализация HashSet<string>
            HashSet<string> Data = new HashSet<string>(_listRandomString);

            //измерение времени поиска строки
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool isFind = Data.Contains(_findString);
            stopwatch.Stop();

            //установка времени выполнения
            TimePerformanceHash = string.Format("{0:f10}", stopwatch.Elapsed.TotalSeconds);
        }

        //метод - вычисление времени для массива string[]
        private void SetTimePerformanceMassiv()
        {
            //создание и инициализация 
            string[] Data = _listRandomString.ToArray();

            //измерение времени поиска строки
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool isFind = Data.Contains(_findString);
            stopwatch.Stop();

            //установка времени выполнения
            TimePerformanceMassiv = string.Format("{0:f10}", stopwatch.Elapsed.TotalSeconds);
        }

        //метод - вычисление времени для массива List
        private void SetTimePerformanceList()
        {
            //создание и инициализация 
            List<string> Data = new List<string>(_listRandomString);

            //измерение времени поиска строки
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            bool isFind = Data.Contains(_findString);
            stopwatch.Stop();

            //установка времени выполнения
            TimePerformanceList = string.Format("{0:f10}", stopwatch.Elapsed.TotalSeconds);
        }

        //метод - вычисление времени
        public void SetTimePerformance()
        {
            SetTimePerformanceHash();
            SetTimePerformanceMassiv();
            SetTimePerformanceList();
        }
    }

    internal class Lesson4Task2 : ILessons
    {
        public string Number => "8";

        public string Description => "Урок № 4, дз № 2 : проверка методов для определения времени поиска строки в HashSet, массиве, списке (List)";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 2 урока № 4");

            //
            Console.WriteLine("\nТаблица - Затраченное время для проверки наличия строки в HashSet, string[] и List, секунд");
            Console.WriteLine("---------------- | --------------| --------------- | -----------------");
            Console.WriteLine("Количество точек | Время HashSet | Время string[]  |  Время List");
            Console.WriteLine("---------------- | --------------| --------------- | -----------------");
            _Check(10000);
            _Check(30000);
            _Check(50000);
            _Check(70000);
            _Check(90000);

            void _Check(int _totalElements)
            {
                var ob = new ClassTimePerformanceHashMassivList(_totalElements);
                ob.SetTimePerformance();
                Console.WriteLine("{0, 16} | {1, 13} | {2, 15} | {3, 13}",
                                  _totalElements, ob.TimePerformanceHash, ob.TimePerformanceMassiv, ob.TimePerformanceList);
                Console.WriteLine("---------------- | --------------| --------------- | -----------------");
            }
        }
    }
}
