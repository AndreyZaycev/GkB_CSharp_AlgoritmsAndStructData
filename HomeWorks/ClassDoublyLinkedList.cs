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

}
