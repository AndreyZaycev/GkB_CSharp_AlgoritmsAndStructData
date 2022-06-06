using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 2, дз № 1 : реализация двусвязного списка

    //класс: узел
    public class Node
    {
        public Node(int value) { Value = value; }   //конструктор
        public int Value { get; set; }              //значение узла
        public Node NextNode { get; set; }          //ссылка на следующий узел
        public Node PrevNode { get; set; }          //ссылка на предыдущий узел
    }

    //интерфейс: функционал класса, описывающего двухсвязный список 
    public interface ILinkedList
    {
        int GetCount();                                 //возвращает количество узлов в списке
        void AddNode(int value);                        //добавляет в список новый узел
        void AddNodeAfter(Node node, int value);        //добавляет новый узел в список после определённого элемента
        void RemoveNodeByIndex(int index);              //удаляет узел по порядковому номеру
        void RemoveNodeByNode(Node node);               //удаляет указанный узел
        Node GetFindNodeByValue(int searchValue);       //получает узел по его значению
    }

    //класс, реализующий двусвязный список
    public class DoublyLinkedList : ILinkedList
    {
        //поля
        Node _headNode;        //головной/первый узел
        Node _tailNode;        //хвостовой/последний узел
        int _countNode;        //количество узлов в списке

        public int GetCount()
        {
            return _countNode;
        }

        public void AddNode(int value)
        {
            Node addNode = new Node(value);
            if (_headNode == null)               //список пуст
            {
                _headNode = addNode;
            }
            else                                 //список не пуст
            {
                _tailNode.NextNode = addNode;
                addNode.PrevNode = _tailNode;
            }
            _tailNode = addNode;
            _countNode++;
        }

        public void AddNodeAfter(Node node, int value)
        {
            int indexNode = GetIndexNode(node);   //индекс узла node
            if (indexNode > -1)                   //узел node в списке существует
            {
                if (indexNode == _countNode)       //узел node последний
                {
                    AddNode(value);
                }
                else                              //узел node не последний 
                {
                    Node addNode = new Node(value);
                    addNode.NextNode = node.NextNode;
                    addNode.PrevNode = node;
                    node.NextNode = addNode;
                    _countNode++;
                }
            }
        }

        public void RemoveNodeByIndex(int index)
        {
            if (index <= _countNode)
            {
                int currentIndex = 0;
                Node currentNode = _headNode;
                while (currentNode != null)
                {
                    if (currentIndex == index)
                    {
                        if (currentNode.NextNode != null) //узел не последний
                        {
                            currentNode.NextNode.PrevNode = currentNode.PrevNode;
                        }
                        else                              //узел последний
                        {
                            _tailNode = currentNode.PrevNode;
                        }

                        if (currentNode.PrevNode != null) //узел не первый
                        {
                            currentNode.PrevNode.NextNode = currentNode.NextNode;
                        }
                        else                              //узел первый
                        {
                            _headNode = currentNode.NextNode;
                        }
                        _countNode--;
                        break;
                    }
                    currentIndex++;
                    currentNode = currentNode.NextNode;
                }
            }
        }

        public void RemoveNodeByNode(Node node)
        {
            int removeIndex = GetIndexNode(node); //индекс удаляемого узла
            if (removeIndex > -1)                 //элемент существует
            {
                RemoveNodeByIndex(removeIndex);   //удаление элемента по индексу
            }
        }

        public Node GetFindNodeByValue(int searchValue)
        {
            Node currentNode = _headNode;
            while (currentNode != null)
            {
                if (currentNode.Value == searchValue) return currentNode;
                currentNode = currentNode.NextNode;
            }
            return null; //элемент отсутствует
        }

        ////////////////////////////////////////////////////////////

        //получить все значения узлов списка в виде строки
        public string GetStringValueNode()
        {
            return (_countNode > 0) ? string.Join(" ", GetListValueNode())
                                    : "Список пуст";
        }

        ////////////////////////////////////////////////////////////

        //получить индекс узла в списке
        private int GetIndexNode(Node node)
        {
            if (node == null)
            {
                return -1;
            }
            else
            {
                int currentIndex = 0;
                Node currentNode = _headNode;
                while (currentNode != null)
                {
                    if (currentNode.Value == node.Value)
                    {
                        return currentIndex;
                    }
                    currentNode = currentNode.NextNode;
                    currentIndex++;
                }
                return -1;
            }
        }

        //получить значения всех узлов в списке
        private List<int> GetListValueNode()
        {
            List<int> outListValueNode = new List<int>();
            Node currentNode = _headNode;
            while (currentNode != null)
            {
                outListValueNode.Add(currentNode.Value);
                currentNode = currentNode.NextNode;
            }
            return outListValueNode;
        }
    }

    internal class Lesson2Task1 : ILessons
    {
        public string Number => "4";

        public string Description => "Урок № 2, дз № 1 : проверка работы методов класса двусвязного списка";

        public void Run()
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
    }

}
