using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameOfLife
{
    static class Generate
    {
        public static bool[,] Random(bool[,] matrix)
        {
            Random random = new Random();
            for (int row_index = 0; row_index < matrix.GetLength(0); row_index++)
                for (int col_index = 0; col_index < matrix.GetLength(1); col_index++)
                {
                    if (random.Next(0, 5) == 1)
                        matrix[row_index, col_index] = true;
                    else matrix[row_index, col_index] = false;
                }
            return matrix;
        }

        public static bool[,] Glider(Board board)
        {
            board.SetNonEmptySymbolCoordinates(0, 1);
            board.SetNonEmptySymbolCoordinates(1, 2);
            board.SetNonEmptySymbolCoordinates(2, 2);
            board.SetNonEmptySymbolCoordinates(2, 1);
            board.SetNonEmptySymbolCoordinates(2, 0);
            return board.GetMatrix();
        }

        public static bool[,] GunGliders(Board board)
        {
            board.SetNonEmptySymbolCoordinates(4, 1);
            board.SetNonEmptySymbolCoordinates(4, 2);
            board.SetNonEmptySymbolCoordinates(5, 1);
            board.SetNonEmptySymbolCoordinates(5, 2);
            board.SetNonEmptySymbolCoordinates(2, 35);
            board.SetNonEmptySymbolCoordinates(2, 36);
            board.SetNonEmptySymbolCoordinates(3, 35);
            board.SetNonEmptySymbolCoordinates(3, 36);
            board.SetNonEmptySymbolCoordinates(0, 25);
            board.SetNonEmptySymbolCoordinates(1, 25);
            board.SetNonEmptySymbolCoordinates(1, 23);
            board.SetNonEmptySymbolCoordinates(2, 22);
            board.SetNonEmptySymbolCoordinates(2, 21);
            board.SetNonEmptySymbolCoordinates(3, 22);
            board.SetNonEmptySymbolCoordinates(3, 21);
            board.SetNonEmptySymbolCoordinates(4, 21);
            board.SetNonEmptySymbolCoordinates(4, 22);
            board.SetNonEmptySymbolCoordinates(5, 25);
            board.SetNonEmptySymbolCoordinates(5, 23);
            board.SetNonEmptySymbolCoordinates(6, 25);
            board.SetNonEmptySymbolCoordinates(2, 14);
            board.SetNonEmptySymbolCoordinates(2, 13);
            board.SetNonEmptySymbolCoordinates(3, 12);
            board.SetNonEmptySymbolCoordinates(4, 11);
            board.SetNonEmptySymbolCoordinates(5, 11);
            board.SetNonEmptySymbolCoordinates(6, 11);
            board.SetNonEmptySymbolCoordinates(7, 12);
            board.SetNonEmptySymbolCoordinates(8, 13);
            board.SetNonEmptySymbolCoordinates(8, 14);
            board.SetNonEmptySymbolCoordinates(7, 16);
            board.SetNonEmptySymbolCoordinates(6, 17);
            board.SetNonEmptySymbolCoordinates(5, 15);
            board.SetNonEmptySymbolCoordinates(5, 17);
            board.SetNonEmptySymbolCoordinates(5, 18);
            board.SetNonEmptySymbolCoordinates(4, 17);
            board.SetNonEmptySymbolCoordinates(3, 16);
            return board.GetMatrix();
        }
    }
}
