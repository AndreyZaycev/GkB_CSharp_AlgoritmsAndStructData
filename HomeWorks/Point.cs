using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

namespace HomeWorks
{
    //Урок № 3, дз : замеры длительности выполнения кода (вычисление дистанции)

    //структура - точка
    public struct PointStructDouble
    {
        private double _x, _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }

    //класс - точка
    public class PointClassDouble
    {
        private double _x, _y;

        public double X { get => _x; set => _x = value; }
        public double Y { get => _y; set => _y = value; }
    }

    //класс - вычисление длительности выполнения кода (заполнение массивов данных + вычисление дистанции)
    public class CheckTimeEstimateDistance
    {
        //поле: количество точек
        private int _numberPoint;

        //конструктор
        public CheckTimeEstimateDistance(int numberPoint)
        {
            _numberPoint = numberPoint;
        }

        //метод расчёта дистанции с входными параметрами значимого (struct) типа
        private void EstimateDistancePointStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            double result = Math.Sqrt((x * x) + (y * y));
        }

        //метод расчёта дистанции с входными параметрами ссылочного (class) типа
        private void EstimateDistancePointClass(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            double result = Math.Sqrt((x * x) + (y * y));
        }

        //получить массив точек значимого (struct) типа
        private List<PointStructDouble> GetListPointStruct()
        {
            List<PointStructDouble> outlist = new List<PointStructDouble>();
            Random rnd = new Random();
            for (int i = 0; i < _numberPoint; i++)
            {
                PointStructDouble tempPoint = new PointStructDouble() { X = rnd.NextDouble(), Y = rnd.NextDouble() };
                outlist.Add(tempPoint);
            }
            return outlist;
        }

        //получить массив точек ссылочного (class) типа
        private List<PointClassDouble> GetListPointClass()
        {
            List<PointClassDouble> outlist = new List<PointClassDouble>();
            Random rnd = new Random();
            for (int i = 0; i < _numberPoint; i++)
            {
                PointClassDouble tempPoint = new PointClassDouble() { X = rnd.NextDouble(), Y = rnd.NextDouble() };
                outlist.Add(tempPoint);
            }
            return outlist;
        }

        //получить время расчета дистанции для массива точек значимого (struct) типа
        public double GetTimeEstimateDistancePointStruct()
        {
            //создание и запуск таймера
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //формирование массивов точек
            List<PointStructDouble> listPointOne = GetListPointStruct();
            List<PointStructDouble> listPointTwo = GetListPointStruct();

            //расчёт дистанции
            for (int i = 0; i < _numberPoint; i++) EstimateDistancePointStruct(listPointOne[i], listPointTwo[i]);

            //остановка таймера
            stopwatch.Stop();

            //
            return Math.Round(stopwatch.Elapsed.TotalSeconds, 6);
        }

        //получить время расчета дистанции для массива точек ссылочного (class) типа
        public double GetTimeEstimateDistancePointClass()
        {
            //создание и запуск таймера
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            //формирование массивов точек
            List<PointClassDouble> listPointOne = GetListPointClass();
            List<PointClassDouble> listPointTwo = GetListPointClass();

            //расчёта дистанции
            for (int i = 0; i < _numberPoint; i++) EstimateDistancePointClass(listPointOne[i], listPointTwo[i]);

            //остановка таймера
            stopwatch.Stop();

            //
            return Math.Round(stopwatch.Elapsed.TotalSeconds, 6);
        }
    }

    internal class Lesson3Task : ILessons
    {
        public string Number => "6";

        public string Description => "Урок № 3, дз : проверка времени выполнения кода для массивов точек значимого и ссылочного типов";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания урока № 3");

            //
            Console.WriteLine("\nКоличество точек | Время timeStruct | Время timeClass | Ratio (timeClass/timeStruct)");
            Console.WriteLine("---------------- | ---------------- | --------------- | ----------------------------");
            _Check(100000);
            _Check(200000);
            _Check(300000);
            _Check(400000);

            void _Check(int _numberPoint)
            {
                CheckTimeEstimateDistance obCheck = new CheckTimeEstimateDistance(_numberPoint);
                double timeStruct = obCheck.GetTimeEstimateDistancePointStruct();
                double timeClass = obCheck.GetTimeEstimateDistancePointClass();
                double ratio = Math.Round(timeClass / timeStruct, 6);
                Console.WriteLine("{0, 16} | {1, 16} | {2, 15} | {3, 27}", _numberPoint, timeStruct, timeClass, ratio);
                Console.WriteLine("---------------- | ---------------- | --------------- | ----------------------------");
            }
        }
    }

}
