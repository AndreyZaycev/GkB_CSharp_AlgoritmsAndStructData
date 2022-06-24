using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<ILessons> tasks = new List<ILessons>()
            {
                new Lesson1Task1(),
                new Lesson1Task2(),
                new Lesson1Task3(),
                new Lesson2Task1(),
                new Lesson2Task2(),
                new Lesson3Task(),
                new Lesson4Task1(),
                new Lesson4Task2(),
                new Lesson5Task1(),
                new Lesson5Task2(),
                new Lesson7Task(), new Lesson8Task()
            };

            bool bExit = true;
            do
            {
                ClassBackgroundInformation.GetBackgroundInformation();

                Console.WriteLine("----------- МЕНЮ ВЫБОРА ЗАДАНИЙ ------------\n");

                foreach (var task in tasks)
                    Console.WriteLine($"Введите '{task.Number}' для вызова => {task.Description}");

                Console.Write("\nВведите номер задания : ");
                string taskNumber = Console.ReadLine();

                foreach (var task in tasks)
                    if (task.Number == taskNumber) task.Run();

                Console.Write("\nДля продолжения работы нажмите любую клавишу, для окончания n : ");
                bExit = (Console.ReadLine() == "n") ? false : true;
                Console.Clear();
            }
            while (bExit);
        }
    }
}
