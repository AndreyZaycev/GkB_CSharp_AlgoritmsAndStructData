using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    //Урок № 4, дз № 1 : реализация двоичного дерева

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
    }
}
