using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeWorks
{
    internal class ClassQueen
    {
        private int _sizeChessBoard;  //размер доски
        private int[,] _chessBoard;   //доска
        private int _numberSolve;     //количество решений

        public ClassQueen(int sizeChessBoard)
        {
            _sizeChessBoard = sizeChessBoard;
            _chessBoard = new int[_sizeChessBoard, _sizeChessBoard];
            _numberSolve = 0;
        }


        //вывод доски с установленными ферзями
        private void ShowChessBoard()
        {
            for (int i = 0; i < _sizeChessBoard; i++)
            {
                for (int j = 0; j < _sizeChessBoard; j++)
                {
                    string s = (_chessBoard[i, j] == 1) ? " Q " : " . ";
                    Console.Write(s);
                }
                Console.WriteLine();
            }
        }

        //проверка установленных ферзей по вертикали и диагоналям
        private bool CheckQueen(int row, int col)
        {
            //по вертикали
            for (int i = 0; i < row; i++)
            {
                if (_chessBoard[i, col] == 1) return false;
            }

            //по диагонали
            for (int i = 1; i <= row && col - i >= 0; i++)
            {
                if (_chessBoard[row - i, col - i] == 1) return false;
            }

            //по диагонали
            for (int i = 1; i <= row && col + i < _sizeChessBoard; i++)
            {
                if (_chessBoard[row - i, col + i] == 1) return false;
            }

            //
            return true;
        }

        //рекурсивный поиск решения
        //row - номер строки в которую нужно поставить следующего ферзя
        private void SearchSolution(int row)
        {
            //вывод решения
            if (row == _sizeChessBoard)
            {
                _numberSolve++;
                Console.WriteLine($"Решение № {_numberSolve}");
                ShowChessBoard();
            }

            //установка ферзей
            for (int i = 0; i < _sizeChessBoard; i++)
            {
                if (CheckQueen(row, i))       //проверка единственности ферзя в строке, вертикали и диагоналях
                {
                    _chessBoard[row, i] = 1;  //установка ферзя
                    SearchSolution(row + 1);  //проверяем (рекурсивно), что установка ферзя на следующую строку приведет к решению 
                    _chessBoard[row, i] = 0;  //снимаем ферзя
                }
            }
        }

        //вывод решений
        public void PrintResult()
        {
            SearchSolution(0);
        }
    }

    internal class Lesson7Task : ILessons
    {
        public string Number => "11";

        public string Description => "Урок № 7, дз : решение задачи о 8-ми ферзях";

        public void Run()
        {
            //
            Console.WriteLine("\nРешение домашнего задания урока № 7");

            //
            Console.WriteLine("Всего решений : 92");
            ClassQueen cw = new ClassQueen(8);
            cw.PrintResult();
        }
    }

}
