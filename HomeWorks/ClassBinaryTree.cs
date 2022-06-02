using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 4, дз № 1 : реализация двоичного дерева
    //Урок № 5, дз № 1 и 2 : алгоритмы BFS и DFS

    //класс: узел дерева
    public class TreeNode
    {
        public int Value;
        public TreeNode LeftNode, RightNode;

        public TreeNode(int value)
        {
            Value = value;
            LeftNode = RightNode = null;
        }

        public TreeNode(int value, TreeNode leftNode, TreeNode rightNode)
        {
            Value = value;
            LeftNode = leftNode;
            RightNode = rightNode;
        }
    }

    //интерфейс: функционал класса, описывающего двоичное дерево
    public interface IBinaryTree
    {
        int GetCountNode();                      //получить количество узлов дерева                             
        TreeNode GetRootNode();                  //получить корневой узел дерева
        void AddNode(int value);                 //добавить узел
        void RemoveNodeByValue(int value);       //удалить узел по значению узла         
        TreeNode GetNodeByValue(int value);      //получить узел по значению
        TreeNode CreateBalanceTree(int nNode);   //построить сбалансированное дерево (заполнение случайными числами)
        void PrintTree(TreeNode rootTreeNode);   //печать дерева (в виде строки)
        void ClearTree();                        //очистить дерево
        bool IsEmpty();                          //проверка пустоты дерева

        //Урок № 5, дз № 1 : поиск в ширину BFS
        (string, string) SearchBFS(int searchValue);

        //Урок № 5, дз № 2 : поиск в глубину DFS
        (string, string) SearchDFS(int searchValue);
    }


    //класс реализующий двоичное дерево
    public class BinaryTree : IBinaryTree
    {
        //поля
        TreeNode _rootTreeNode;   //корневой узел дерева
        int _countNode;           //количество узлов дерева

        //конструктор
        public BinaryTree()
        {
            _rootTreeNode = null;
            _countNode = 0;
        }

        //свойство (необходимо для работы метода 'public TreeNode CreateBalanceTree(int nNode)')
        public TreeNode RootTreeNode { get => _rootTreeNode; set => _rootTreeNode = value; }

        //получить количество узлов дерева  
        public int GetCountNode() { return _countNode; }

        //получить корневой узел дерева
        public TreeNode GetRootNode() { return _rootTreeNode; }

        //добавить узел
        public void AddNode(int value)
        {
            _AddRecursive(new TreeNode(value), ref _rootTreeNode);
        }
        private void _AddRecursive(TreeNode addNode, ref TreeNode currentRootNode) //рекурсивный метод добавления
        {
            if (currentRootNode == null)      //корневой узел  отсутсвует (дерево пустое)
            {
                currentRootNode = addNode;
                _countNode++;
            }
            else                              //корневой узел есть (дерево не пустое)
            {
                if (addNode.Value < currentRootNode.Value) //значение добавляемого узла < родительского
                {
                    _AddRecursive(addNode, ref currentRootNode.LeftNode);   //добавление в левый узел
                }
                else                                      //значение добавляемого узла > родительского
                {
                    _AddRecursive(addNode, ref currentRootNode.RightNode);  //добавление в ghfdsq узел
                }
            }
        }

        //получить узел по значению
        public TreeNode GetNodeByValue(int value)
        {
            TreeNode currentNode = _rootTreeNode;
            while (currentNode != null)
            {
                if (currentNode.Value == value)
                {
                    return currentNode;
                }
                else
                {
                    currentNode = (value < currentNode.Value) ? currentNode.LeftNode : currentNode.RightNode;
                }
            }
            return null;
        }

        //удалить узел по значению узла 
        public void RemoveNodeByValue(int value)
        {
            TreeNode removeNode = GetNodeByValue(value);
            if (removeNode != null) //удаляемый узел в наличии
            {
                bool bRemoveItem = _RemoveRecursive(value, ref _rootTreeNode) != null;
                if (bRemoveItem) _countNode--;
            }
        }
        private TreeNode _RemoveRecursive(int value, ref TreeNode currentRootNode)
        {
            if (currentRootNode != null)
            {
                if (value < currentRootNode.Value)
                {
                    currentRootNode.LeftNode = _RemoveRecursive(value, ref currentRootNode.LeftNode);
                }
                else
                {
                    if (value > currentRootNode.Value)
                    {
                        currentRootNode.RightNode = _RemoveRecursive(value, ref currentRootNode.RightNode);
                    }
                    else //value == currentRootNode.Value
                    {
                        if (currentRootNode.LeftNode == null)
                        {
                            currentRootNode = currentRootNode.RightNode;
                        }
                        else //currentRootNode.LeftNode != null
                        {
                            if (currentRootNode.RightNode == null)
                            {
                                currentRootNode = currentRootNode.LeftNode;
                            }
                            else //currentRootNode.RightNode != null
                            {
                                //найти самый левый узел на правой ветке
                                TreeNode leftNodeInRightBranch = currentRootNode.RightNode;
                                while (leftNodeInRightBranch.LeftNode != null) leftNodeInRightBranch = leftNodeInRightBranch.LeftNode;

                                //
                                currentRootNode.Value = leftNodeInRightBranch.Value;
                                currentRootNode.RightNode = _RemoveRecursive(value, ref currentRootNode.RightNode);
                            }
                        }
                    }
                }
                return currentRootNode;
            }
            else
            {
                return null;
            }
        }

        //построить сбалансированное дерево (заполнение случайными числами)
        public TreeNode CreateBalanceTree(int nNode)  //обертка для _CreateBalanceTree(Random rand, int nNode)
        {
            //генератор, чтоб в методе CreateBalanceTree(int nNode) генерировались случайные числа
            //если определить генератор непосредственно в методе _CreateBalanceTree, то случайных чисел не будет!
            Random rand = new Random();
            return _CreateBalanceTree(rand, nNode);
        }
        private TreeNode _CreateBalanceTree(Random rand, int nNode)
        {
            TreeNode newNode = null;
            if (nNode == 0)
            {
                return null;
            }
            else
            {
                newNode = new TreeNode(rand.Next(1, 50));
                newNode.LeftNode = _CreateBalanceTree(rand, nNode / 2);
                newNode.RightNode = _CreateBalanceTree(rand, nNode - nNode / 2 - 1);
                _countNode++;
            }
            return newNode;
        }

        //печать дерева
        public void PrintTree(TreeNode root)
        {
            if (root != null)
            {
                Console.Write(root.Value.ToString() + " ");
                PrintTree(root.LeftNode);
                PrintTree(root.RightNode);
            }
        }

        //очистить дерево
        public void ClearTree()
        {
            _rootTreeNode = null;
            _countNode = 0;
        }

        //проверка пустоты дерева
        public bool IsEmpty()
        {
            return _countNode == 0;
        }

        //Урок № 5, дз № 1 : реализация алгоритма поиска в ширину (BFS)
        //поиск в ширину (метод BFS) 
        public (string, string) SearchBFS(int searchValue)
        {
            //
            var tupleResult = (sResultStep: "", sResultSearchValue: "");
            tupleResult.sResultStep = $"Поиск узла дерева со значением {searchValue} в ширину (метод BFS)...\n";
            tupleResult.sResultSearchValue = "";

            //
            bool bEmptyQueue = true;
            bool bSearchResult = false;

            //
            TreeNode currentNode = _rootTreeNode;
            if (currentNode != null)
            {
                Queue<TreeNode> queue = new Queue<TreeNode>();
                int currentNodeValue;

                bEmptyQueue = false;

                tupleResult.sResultStep += "Корневой элемент существует...\n";
                queue.Enqueue(currentNode);
                tupleResult.sResultStep += $"-> Положить в очередь значение {queue.Peek().Value} корневого узла\n";

                while (queue.Count != 0)
                {
                    tupleResult.sResultStep += "Очередь не пустая. Продолжаем работу алгоритма...\n";

                    currentNode = queue.Dequeue();
                    currentNodeValue = currentNode.Value;
                    tupleResult.sResultStep += $"<- Извлекаем из очереди элемент {currentNodeValue} узла\n";

                    if (currentNodeValue == searchValue)
                    {
                        tupleResult.sResultSearchValue = $"---- Поиск завершен. Узел со значением {currentNodeValue} найден ----";
                        tupleResult.sResultStep += $"---- Узел со значением {currentNodeValue} найден. Возвращаем результат. Завершаем работу алгоритма ----";
                        bSearchResult = true;
                        if (queue.Count != 0) queue.Clear(); //очистка очереди
                        break;
                    }

                    if (currentNode.LeftNode != null)
                    {
                        queue.Enqueue(currentNode.LeftNode);
                        tupleResult.sResultStep += $"-> Положить в очередь значение {currentNode.LeftNode.Value} дочернего узла из левого поддерева\n";
                    }

                    if (currentNode.RightNode != null)
                    {
                        queue.Enqueue(currentNode.RightNode);
                        tupleResult.sResultStep += $"-> Положить в очередь значение {currentNode.RightNode.Value} дочернего узла из правого поддерева\n";
                    }
                }
            }

            //
            if (!bSearchResult)   //результат не найден
            {
                tupleResult.sResultStep += $"---- Поиск завершен. Очередь пустая. Узел со значением {searchValue} не найден ----";
                if (bEmptyQueue)  //дерева не существует
                {
                    tupleResult.sResultSearchValue = "---- Дерево не существует ----";
                }
                else              //дерево существует
                {
                    tupleResult.sResultSearchValue = $"---- Узел со значением {searchValue} в дереве отсутствует ----";
                }
            }

            //
            return tupleResult;
        }

        //Урок № 5, дз № 2 : реализация алгоритма поиска в глубину (DFS)
        //поиск в глубину (метод DFS) 
        public (string, string) SearchDFS(int searchValue)
        {
            //
            var tupleResult = (sResultStep: "", sResultSearchValue: "");
            tupleResult.sResultStep = $"Поиск узла дерева со значением {searchValue} в глубину (метод DFS)...\n";
            tupleResult.sResultSearchValue = "";

            //
            bool bEmptyQueue = true;
            bool bSearchResult = false;

            //
            TreeNode currentNode = _rootTreeNode;
            if (currentNode != null)
            {
                Stack<TreeNode> stack = new Stack<TreeNode>();
                int currentNodeValue;

                bEmptyQueue = false;

                tupleResult.sResultStep += "Корневой элемент существует...\n";
                stack.Push(currentNode);
                tupleResult.sResultStep += $"-> Положить в стек значение {stack.Peek().Value} корневого узла\n";

                while (stack.Count != 0)
                {
                    tupleResult.sResultStep += "Стек не пустой. Продолжаем работу алгоритма...\n";

                    currentNode = stack.Pop();
                    currentNodeValue = currentNode.Value;
                    tupleResult.sResultStep += $"<- Извлекаем из стека элемент {currentNodeValue} узла\n";

                    if (currentNodeValue == searchValue)
                    {
                        tupleResult.sResultSearchValue = $"---- Поиск завершен. Узел со значением {currentNodeValue} найден ----";
                        tupleResult.sResultStep += $"---- Узел со значением {currentNodeValue} найден. Возвращаем результат. Завершаем работу алгоритма ----";
                        bSearchResult = true;
                        if (stack.Count != 0) stack.Clear(); //очистка стека
                        break;
                    }

                    if (currentNode.LeftNode != null)
                    {
                        stack.Push(currentNode.LeftNode);
                        tupleResult.sResultStep += $"-> Положить в стек значение {currentNode.LeftNode.Value} дочернего узла из левого поддерева\n";
                    }

                    if (currentNode.RightNode != null)
                    {
                        stack.Push(currentNode.RightNode);
                        tupleResult.sResultStep += $"-> Положить в стек значение {currentNode.RightNode.Value} дочернего узла из правого поддерева\n";
                    }
                }
            }

            //
            if (!bSearchResult)   //результат не найден
            {
                tupleResult.sResultStep += $"---- Поиск завершен. Стек пуст. Узел со значением {searchValue} не найден ----";
                if (bEmptyQueue)  //дерева не существует
                {
                    tupleResult.sResultSearchValue = "---- Дерево не существует ----";
                }
                else              //дерево существует
                {
                    tupleResult.sResultSearchValue = $"---- Узел со значением {searchValue} в дереве отсутствует ----";
                }
            }

            //
            return tupleResult;
        }
    }

    internal class Lesson4Task1 : ILessons
    {
        public string Number => "7";

        public string Description => "Урок № 4, дз № 1 : проверка методов работы класса двоичного дерева";

        public void Run()
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
    }

    internal class Lesson5Task1 : ILessons
    {
        public string Number => "9";

        public string Description => "Урок № 5, дз № 1 : проверка алгоритма поиска в ширину (BFS) в двоичном дереве";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 1 урока № 5\n");

            //создание дерева
            BinaryTree binaryTree = new BinaryTree();
            Console.WriteLine("Создание дерева. Дерево создано...\n");
            List<int> listAddValueNode = new List<int>() { 104, 8, 12, 23, 1, 6, 3, 59, 13, 45, 78, 93 };
            foreach (int valueNode in listAddValueNode) binaryTree.AddNode(valueNode);
            Console.Write($"Узлы дерева : "); binaryTree.PrintTree(binaryTree.GetRootNode());
            Console.WriteLine(); Console.WriteLine();

            //проверка алгоритма public (string, string) SearchBFS(int searchValue)
            Console.WriteLine("\nПроверка метода: '(string, string) SearchBFS(int searchValue)'");
            _CheckSearchBFS(104);   //головной
            _CheckSearchBFS(45);    //левое поддерево
            _CheckSearchBFS(93);    //правое поддерево
            _CheckSearchBFS(1000);  //нет узла со значением 1000
            Console.WriteLine("Очищаем дерево...");
            binaryTree.ClearTree();
            _CheckSearchBFS(45);

            void _CheckSearchBFS(int _searchValue)
            {
                var tupleResult = binaryTree.SearchBFS(_searchValue);
                Console.WriteLine(tupleResult.Item1);
                Console.WriteLine(tupleResult.Item2);
                Console.WriteLine();
            }
        }
    }

    internal class Lesson5Task2 : ILessons
    {
        public string Number => "10";

        public string Description => "Урок № 5, дз № 2 : проверка алгоритма поиска в глубину (DFS) в двоичном дереве";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания № 2 урока № 5\n");

            //создание дерева
            BinaryTree binaryTree = new BinaryTree();
            Console.WriteLine("Создание дерева. Дерево создано...\n");
            List<int> listAddValueNode = new List<int>() { 104, 8, 12, 23, 1, 6, 3, 59, 13, 45, 78, 93 };
            foreach (int valueNode in listAddValueNode) binaryTree.AddNode(valueNode);
            Console.Write($"Узлы дерева : "); binaryTree.PrintTree(binaryTree.GetRootNode());
            Console.WriteLine(); Console.WriteLine();

            //проверка алгоритма public (string, string) SearchDFS(int searchValue)
            Console.WriteLine("\nПроверка метода: '(string, string) SearchDFS(int searchValue)'");
            _CheckSearchDFS(104);   //головной
            _CheckSearchDFS(45);    //левое поддерево
            _CheckSearchDFS(93);    //правое поддерево
            _CheckSearchDFS(1000);  //нет узла со значением 1000
            Console.WriteLine("Очищаем дерево...");
            binaryTree.ClearTree();
            _CheckSearchDFS(45);

            void _CheckSearchDFS(int _searchValue)
            {
                var tupleResult = binaryTree.SearchDFS(_searchValue);
                Console.WriteLine(tupleResult.Item1);
                Console.WriteLine(tupleResult.Item2);
                Console.WriteLine();
            }
        }
    }
}
