using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleGameOfLife
{
    class Board
    {
        bool [,]matrix;
        bool [,]next_matrix;
        char empty_symbol, nonempty_symbol;

        public Board(int rows, int colums, char empty_symbol, char nonempty_symbol){
            this.empty_symbol = empty_symbol;
            this.nonempty_symbol = nonempty_symbol;
            matrix = new bool[rows, colums];
            next_matrix = new bool[rows, colums];
        }

        public void SetEmptySymbol(char symbol){ empty_symbol = symbol; }

        public void SetNonEmptySymbol(char symbol){ nonempty_symbol = symbol; }

        public bool[,] GetMatrix() { return matrix; }

        public void SetMatrix(bool [,]matrix) { this.matrix = matrix; }

        public void SetNonEmptySymbolCoordinates(int row, int colum){
            try
            {
                if (row > matrix.GetLength(0) || colum > matrix.GetLength(1))
                    throw new Exception("Index is out of range.");
                else matrix[row, colum] = true;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public int NumberOfNeighbors(int row, int col)
        {
            int counter = 0, row_begin = 0, row_limit = 0, col_begin = 0, col_limit = 0;
            if (row == 0)
                row_begin = row;
            else if (row > 0)
                row_begin = row - 1;
            if (row == matrix.GetLength(0) - 1)
                row_limit = row;
            else if (row < matrix.GetLength(0) - 1)
                row_limit = row + 1;

            if (col == 0)
                col_begin = col;
            else if (col > 0)
                col_begin = col - 1;
            if (col == matrix.GetLength(1) - 1)
                col_limit = col;
            else if (col < matrix.GetLength(1) - 1)
                col_limit = col + 1;
                
            for (int row_index = row_begin; row_index <= row_limit; row_index++)
                for (int col_index = col_begin; col_index <= col_limit; col_index++)
                    if (row_index != row || col_index != col)
                        if (matrix[row_index, col_index] == true)
                            counter++;
            return counter;
        }

        public void Move()
        {
            int neighbors;
            for (int row_index = 0; row_index < matrix.GetLength(0); row_index++)
                for (int col_index = 0; col_index < matrix.GetLength(1); col_index++)
                {
                    neighbors = NumberOfNeighbors(row_index, col_index);
                    if ((neighbors == 2 || neighbors == 3) && matrix[row_index, col_index] == true)
                        next_matrix[row_index, col_index] = true;
                    else if ((neighbors < 2 || neighbors > 3) && matrix[row_index, col_index] == true)
                        next_matrix[row_index, col_index] = false;
                    if (neighbors == 3 && matrix[row_index, col_index] == false)
                        next_matrix[row_index, col_index] = true;
                }
        }

        public void Equal() {
            matrix = next_matrix;
            next_matrix = null;
            next_matrix = new bool[matrix.GetLength(0), matrix.GetLength(1)];
        }

        public bool Continue()
        {
            bool result = true;
            int counter = 0;
            for(int row_index = 0; row_index < matrix.GetLength(0); row_index++)
                for (int col_index = 0; col_index < matrix.GetLength(1); col_index++)
                    if (matrix[row_index, col_index].CompareTo(next_matrix[row_index, col_index]) == 0)
                        counter++;
            if (counter == matrix.GetLength(0) * matrix.GetLength(1))
                result = false;
            return result;
        }

        public void ShowBoard(){
            String separator = " ";
            for(int row_index = 0; row_index < matrix.GetLength(0); row_index++) {
                for (int col_index = 0; col_index < matrix.GetLength(1); col_index++) {
                    if(matrix[row_index, col_index] == true)
                        Console.Write(nonempty_symbol + separator);
                    else Console.Write(empty_symbol+ separator);
                }
                Console.WriteLine();
            }
        }

        public void GenerateRandom()
        {
            Random random = new Random();
            for(int row_index = 0; row_index < matrix.GetLength(0); row_index++) 
                for (int col_index = 0; col_index < matrix.GetLength(1); col_index++)
                {
                    if (random.Next(0, 5) == 1)
                        matrix[row_index, col_index] = true;
                    else matrix[row_index, col_index] = false;
                }
        }
    }
}
