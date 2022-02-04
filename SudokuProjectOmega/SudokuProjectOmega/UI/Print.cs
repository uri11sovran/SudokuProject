using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{ 
    /// <summary>
    /// The class prints the board in a natrix format
    /// </summary>
    public static class Print
    {
        /// <summary>
        /// The Function is a help function used to print "___" abouve each number.
        /// The function is used in the PrintBoard function
        /// </summary>
        /// <param name="len"> the lenght of the line. Related to the size of the sudoku </param>
        public static void PrintLine(int len)
        {
            int i, counter = 0;
            for (i = 0; i < len * 5; i++)
            {
                if (counter == 0 || counter == 5)
                {
                    if (counter == 5)
                        counter = 0;
                    Console.Write(" ");
                }
                Console.Write("-");
                counter++;
            }
            Console.WriteLine();
        }

        /// <summary>
        /// The function prints a sudoku board
        /// </summary>
        /// <param name="board"> The board to print </param>
        public static void PrintBoard(Board board)
        {
            int i, j;

            for (i = 0; i < board.Size; i++)
            {
                PrintLine((int)board.Size);
                for (j = 0; j < board.Size; j++)
                    Console.Write("|     ");
                Console.WriteLine("|");

                for (j = 0; j < board.Size; j++)
                {
                    Console.Write("|  {0}  ", (char)(board.Get(i, j) + '0'));
                }
                Console.WriteLine("|");

                for (j = 0; j < board.Size; j++)
                    Console.Write("|     ");
                Console.WriteLine("|");
            }
            PrintLine((int)(board.Size));
        }
    }
}
