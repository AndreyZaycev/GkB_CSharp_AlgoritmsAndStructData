using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class Program
    {
        #region(ДОПОЛНЯЕМЫЙ МЕТОД - СПИСОК НАИМЕНОВАНИЙ ПУНКТОВ МЕНЮ)
        static List<string> GetListHomeWorkForMenu()
        {
            List<string> outList = new List<string>();
            outList.Add("Урок № 1, домашнее задание № 1");
            outList.Add("Урок № 1, домашнее задание № 2");
            outList.Add("Урок № 1, домашнее задание № 3");
            outList.Add("Урок № 2, домашнее задание № 1");
            outList.Add("Урок № 2, домашнее задание № 2");
            outList.Add("Урок № 3, домашнее задание");
            outList.Add("Урок № 4, домашнее задание № 1");
            outList.Add("Урок № 4, домашнее задание № 2");
            return outList;
        }
        #endregion

        //Урок № 1, дз № 1: Отдельный метод для проверки, простое число или нет
        static void CheckPrimeNumber()
        {
            //
            Console.WriteLine("Решение домашнего задания № 1 урока № 1");

            //
            int number;
            bool bNumber = false;
            do
            {
                Console.Write("Введите целое положительное (натуральное) число : ");
                bNumber = int.TryParse(Console.ReadLine(), out number);
                if (!bNumber || number < 0)
                {
                    Console.WriteLine("Некорректный ввод! Введите целое положительное (натуральное) число повторно");
                    bNumber = false;
                }
            }
            while (!bNumber);

            //
            ClassCheckingPrimeNumber obCheck = new ClassCheckingPrimeNumber(number);
            Console.WriteLine((obCheck.IsCheckingPrimeNumber()) ? $"Число {number} простое" : $"Число {number} не простое");
        }

        //Урок № 1, дз № 3: Отдельный метод для проверки вычисления числа Фибоначчи
        static void CheckEstimateNumberFibonachi()
        {
            //
            Console.WriteLine("Решение домашнего задания № 3 урока № 1");

            //
            long number;
            bool bNumber = false;
            do
            {
                Console.Write("Введите член последовательности Фибоначчи (целое положительное число) : ");
                bNumber = long.TryParse(Console.ReadLine(), out number);
                if (!bNumber || number < 0)
                {
                    Console.WriteLine("Некорректный ввод! Введите член последовательности Фибоначчи (целое положительное число) повторно");
                    bNumber = false;
                }
            }
            while (!bNumber);

            //
            long numFibonachiRecursivMetod = ClassEstimateNumberFibonachi.GetNumberFibonachiRecursivMetod(number);
            long numFibonachiNonRecursivMetod = ClassEstimateNumberFibonachi.GetNumberFibonachiNonRecursivMetod(number);
            Console.WriteLine($"{number} член последовательности Фибоначчи, определенный рекурсивным методом, равен {numFibonachiRecursivMetod}");
            Console.WriteLine($"{number} член последовательности Фибоначчи, определенный не рекурсивным методом, равен {numFibonachiNonRecursivMetod}");
        }

        //Урок № 2, дз № 1: Отдельный метод для проверки работы класса двусвязного списка
        static void CheckDoublyLinkedList()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 1 урока № 2\n");

            //создание списка
            DoublyLinkedList list = new DoublyLinkedList();
            Console.WriteLine("Список создан...\n");

            //проверка метода AddNode(int value)
            Console.WriteLine("Проверка метода 'void AddNode(int value)'...");
            Console.WriteLine("Добавлено 5 значений.  ");
            list.AddNode(4);
            list.AddNode(11);
            list.AddNode(17);
            list.AddNode(39);
            list.AddNode(72);
            Console.Write($"Текущий список : {list.GetStringValueNode()}  ");

            //проверка метода int GetCount()
            Console.WriteLine("\n\nПроверка метода 'int GetCount()'...");
            Console.WriteLine($"Количество узлов в списке = {list.GetCount()}");

            //проверка метода Node GetFindNodeByValue(int searchValue)
            Console.WriteLine("\nПроверка метода 'Node GetFindNodeByValue(int searchValue)'...");
            _CheckFindNode(17);
            _CheckFindNode(15);
            _CheckFindNode(39);

            //проверка метода void AddNodeAfter(Node node, int value)
            Console.WriteLine("\nПроверка метода 'void AddNodeAfter(Node node, int value)'...");
            _CheckAddNodeAfter(4, 44);   //после нулевого элемента  
            _CheckAddNodeAfter(17, 177); //в середине
            _CheckAddNodeAfter(72, 722); //после последнего элемента

            //проверка метода void RemoveNodeByIndex(int index)
            Console.WriteLine("\nПроверка метода 'void RemoveNodeByIndex(int index)'...");
            _CheckRemoveNodeByIndex(0);  //нулевой
            _CheckRemoveNodeByIndex(3);  //в середине
            _CheckRemoveNodeByIndex(5);  //последний
            _CheckRemoveNodeByIndex(20); //узла с индексом 20 нет, поэтому список остается неизменным
            Console.WriteLine("Узла с индексом 20 нет, поэтому список остается неизменным");

            //проверка метода void RemoveNodeByNode(Node node)
            Console.WriteLine("\nПроверка метода 'void RemoveNodeByNode(Node node)'...");
            _CheckRemoveNodeByNode(44);  //нулевой узел со значением 44
            _CheckRemoveNodeByNode(17);  //узел в середине со значением 17
            _CheckRemoveNodeByNode(72);  //последний узел со значением 72
            _CheckRemoveNodeByNode(100); //узла со значением 100 нет, поэтому список остается неизменным
            Console.WriteLine("Узла со значением 100 нет, поэтому список остается неизменным");

            void _CheckFindNode(int _searchValue)
            {
                Node searchNode = list.GetFindNodeByValue(_searchValue);
                string sResult = (searchNode != null) ? $"Узел со значением {_searchValue} в списке {list.GetStringValueNode()} найден"
                                                      : $"Узел со значением {_searchValue} в списке {list.GetStringValueNode()} не найден (отсутствует)";
                Console.WriteLine(sResult);
            }

            void _CheckAddNodeAfter(int _valueNode, int _addValueNode)
            {
                Console.Write($"\nТекущий список : {list.GetStringValueNode()}  ");
                Console.WriteLine($"Количество узлов в списке = {list.GetCount()}");
                list.AddNodeAfter(list.GetFindNodeByValue(_valueNode), _addValueNode);
                Console.WriteLine($"Текущий список после добавления узла со значением {_addValueNode} после узла со значением {_valueNode} : {list.GetStringValueNode()}  ");
                Console.WriteLine($"Количество узлов в списке после добавления узла = {list.GetCount()}");
            }

            void _CheckRemoveNodeByIndex(int _index)
            {
                Console.Write($"\nТекущий список : {list.GetStringValueNode()}  ");
                Console.WriteLine($"Количество узлов в списке = {list.GetCount()}");
                list.RemoveNodeByIndex(_index);
                Console.WriteLine($"Текущий список после удаления узла с индексом {_index} : {list.GetStringValueNode()}");
                Console.WriteLine($"Количество узлов в списке после удаления узла с индексом {_index} = {list.GetCount()}");
            }

            void _CheckRemoveNodeByNode(int _valueNode)
            {
                Console.Write($"\nТекущий список : {list.GetStringValueNode()}  ");
                Console.WriteLine($"Количество узлов в списке = {list.GetCount()}");
                list.RemoveNodeByNode(list.GetFindNodeByValue(_valueNode));
                Console.WriteLine($"Текущий список после удаления узла со значением {_valueNode} : {list.GetStringValueNode()}");
                Console.WriteLine($"Количество узлов в списке после удаления узла со значением {_valueNode} = {list.GetCount()}");
            }
        }

        //Урок № 2, дз № 2: Отдельный метод для проверки работы алгоритма бинарного поиска
        static void CheckBinarySearch()
        {
            //
            Console.WriteLine("Решение домашнего задания № 2 урока № 2");

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

        //Урок № 3, дз: Отдельный метод, для вывода времени выполнения кода для массивов точек значимого и ссылочного типов
        static void CheckTimePerformance()
        {
            //
            Console.WriteLine("Решение домашнего задания урока № 3");

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

        //Урок № 4, дз № 1: Отдельный метод для проверки работы класса двоичного дерева
        static void CheckBinaryTree()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 1 урока № 4\n");

            //создание дерева
            BinaryTree binaryTree = new BinaryTree();
            Console.WriteLine("Создание дерева. Дерево создано...\n");

            //создание сбалансированного дерева из nNodeBalanceTree узлов
            int nNodeBalanceTree = 5;
            Console.WriteLine($"Создание сбалансированного дерева из {nNodeBalanceTree} узлов.");
            Console.WriteLine("Проверка метода: 'TreeNode CreateBalanceTree(int nNode)'");
            binaryTree.RootTreeNode = binaryTree.CreateBalanceTree(nNodeBalanceTree);
            Console.WriteLine($"Сбалансированное дерево из {nNodeBalanceTree} узлов создано...");

            //печать дерева
            Console.WriteLine("\nПечать сбалансированного дерева. Проверка метода: 'void PrintTree(TreeNode rootTreeNode)'");
            Console.Write("Узлы дерева: "); binaryTree.PrintTree(binaryTree.GetRootNode());

            //вывод количества элементов
            Console.WriteLine("\n\nПроверка метода: 'int GetCountNode()'");
            Console.WriteLine($"Кол-во элементов = {binaryTree.GetCountNode()}");

            //добавить узлы
            List<int> listAddValueNode = new List<int>() { 64, 75, 82 };
            string sAddValueNode = string.Join(" ", listAddValueNode);
            Console.WriteLine($"\nДобавление узлов {sAddValueNode} в дерево. Проверка метода: 'void AddNode(int value)'");
            foreach (int valueNode in listAddValueNode) binaryTree.AddNode(valueNode);
            Console.Write($"Узлы дерева после добавления узлов {sAddValueNode}:  ");
            binaryTree.PrintTree(binaryTree.GetRootNode());
            Console.WriteLine($"\nКол-во элементов = {binaryTree.GetCountNode()}");

            //проверка метода получения корневого узла дерева и метода проверки на пустоту
            Console.WriteLine("\nПроверка методов: 'TreeNode GetRootNode()' и 'bool IsEmpty()'");
            Console.Write("Узлы дерева: "); binaryTree.PrintTree(binaryTree.GetRootNode());
            if (!binaryTree.IsEmpty())
                Console.WriteLine($"Значение корневого узла дерева (дерево не пустое) = {binaryTree.GetRootNode().Value}");
            else
                Console.WriteLine("Узлы дерева не существуют (дерево пустое). Значение корневого узла дерева = null");

            //проверка метода очистки дерева и метода проверки на пустоту
            Console.WriteLine("\nПроверка методов: 'void ClearTree()' и 'bool IsEmpty()'");
            binaryTree.ClearTree();
            Console.Write("Дерево очищено...");
            if (!binaryTree.IsEmpty())
                Console.WriteLine(" Дерево не пустое. ");
            else
                Console.WriteLine(" Дерево пустое.");

            //!!!формирование дерева
            Console.WriteLine($"\nДобавление узлов в дерево методом 'void AddNode(int value)'");
            listAddValueNode = new List<int>() { 104, 8, 12, 23, 1, 6, 3, 59 };
            foreach (int valueNode in listAddValueNode) binaryTree.AddNode(valueNode);
            Console.Write($"Узлы дерева : "); binaryTree.PrintTree(binaryTree.GetRootNode());
            Console.WriteLine($"Кол-во элементов = {binaryTree.GetCountNode()}");

            //проверка метода получения узла по значению
            Console.WriteLine("\nПроверка метода: 'TreeNode GetNodeByValue(int value)'");
            Console.Write($"Узлы дерева : "); binaryTree.PrintTree(binaryTree.GetRootNode());
            Console.WriteLine();
            foreach (int currentValueNode in listAddValueNode) _CheckGetNodeByValue(currentValueNode); //найдем все!!!
            _CheckGetNodeByValue(1000); //узел со значением 1000 в дереве отсутствует

            //проверка метода удаления узлов по значению
            Console.WriteLine("\nПроверка метода: 'void RemoveNodeByValue(int value)'");
            _CheckRemoveNodeByValue(12);
            _CheckRemoveNodeByValue(6);
            _CheckRemoveNodeByValue(104);
            _CheckRemoveNodeByValue(59);
            _CheckRemoveNodeByValue(1000); //узла со значением 1000 в дереве нет, ничего не меняется

            //проверка метода получения узла по значению
            void _CheckGetNodeByValue(int _valueNode)
            {
                TreeNode getNode = binaryTree.GetNodeByValue(_valueNode);
                Console.Write($"Узел со значением {_valueNode} в дереве ");
                //binaryTree.PrintTree(binaryTree.GetRootNode());
                if (getNode != null)
                    Console.WriteLine("найден");
                else
                    Console.WriteLine("не найден (узел в дереве отсутствует)");
            }

            //проверка метода удаления узлов по значению
            void _CheckRemoveNodeByValue(int _removeValueNode)
            {
                Console.Write($"\nУзлы дерева до удаления узла со значением {_removeValueNode}: "); binaryTree.PrintTree(binaryTree.GetRootNode());
                Console.Write($"Кол-во элементов = {binaryTree.GetCountNode()}");
                binaryTree.RemoveNodeByValue(_removeValueNode);
                Console.Write($"\nУзлы дерева после удаления узла со значением {_removeValueNode}: "); binaryTree.PrintTree(binaryTree.GetRootNode());
                Console.Write($"Кол-во элементов = {binaryTree.GetCountNode()}");
                Console.WriteLine();
            }
        }

        //Урок № 4, дз № 2: Отдельный метод для определения времени при проверке наличия строки в HashSet, массиве, списке (List)
        static void CheckTimePerformanceHashMassivList()
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

        static void Main(string[] args)
        {
            bool bExit = true;
            do
            {
                ClassBackgroundInformation.GetBackgroundInformation();
                ClassMenu oMenu = new ClassMenu(GetListHomeWorkForMenu());
                oMenu.GetMenu();
                int numPunktMenu = oMenu.GetPunktMenu();
                switch (numPunktMenu)
                {
                    case 1: CheckPrimeNumber(); break;
                    case 2:
                        Console.WriteLine("Решение домашнего задания № 2 урока № 1");
                        Console.WriteLine("Cложность функции StrangeSum(int[] inputArray) = O(3*N*N*N+2) = O(N*N*N)"); break;
                    case 3: CheckEstimateNumberFibonachi(); break;
                    case 4: CheckDoublyLinkedList(); break;
                    case 5: CheckBinarySearch(); break;
                    case 6: CheckTimePerformance(); break;
                    case 7: CheckBinaryTree(); break;
                    case 8: CheckTimePerformanceHashMassivList(); break;
                }
                Console.Write("\nДля продолжения работы нажмите любую клавишу, для окончания n : ");
                bExit = (Console.ReadLine() == "n") ? false : true;
                Console.Clear();
            }
            while (bExit);
        }
    }
}
