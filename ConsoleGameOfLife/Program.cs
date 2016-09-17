using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleGameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board(24, 39, ' ', '#');
            board.SetMatrix(Generate.Random(board.GetMatrix()));
            board.ShowBoard();
            while (true)
            {
                board.Move();
                Thread.Sleep(500);
                Console.Clear();
                board.Equal();
                board.ShowBoard();                           
            }
        }
    }
}
