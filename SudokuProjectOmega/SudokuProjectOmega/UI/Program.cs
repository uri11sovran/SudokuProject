using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class Program
    {
        /*static void PrintBoardSimlpe(Board board)
        {
            int i, j;

            for (i = 0; i < board.Size; i++)
            {
                for (j = 0; j < board.Size; j++)
                {
                    Console.Write("{0} ", (char)(board.Get(i, j) + '0'));
                }
                Console.WriteLine();
            }
        }*/

        /// <summary>
        /// The Function is a help function used to print "___" abouve each number.
        /// The function is used in the PrintBoard function
        /// </summary>
        /// <param name="len"> the lenght of the line. Related to the size of the sudoku </param>
        static void PrintLine(int len)
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
        static void PrintBoard(Board board)
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

        /// <summary>
        /// This function operates like a main function,
        /// it connects all the diffrent parts of the sudoku solver
        /// from the ui to the solving algorithm.
        /// </summary>
        /// <returns> Returns 0 if the user wanted to stop the operation, 1 if the user whats to continue. </returns>
        static int Game()
        {
            Board? board = null;

            // Handle possible board exceptions
            try
            {
                board = HandleUserInput.Menu();
            } catch (SudokuException invalid_sudoku) {
                Console.WriteLine(invalid_sudoku.Message);
                return 1;
            } catch (System.IO.FileNotFoundException) {
                Console.WriteLine("The file does not exist");
                return 1;
            }

            // the board will be null if the user enterd 0 - exit
            if (board == null)
                return 0;

            // the first part of the sudoku solver, the operation deletes all impossible 
            // cell values for each cell of the board.
            // used as a board setter
            Tactics.DeleteOperators(board);

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!SudokuSolver.Solve(board))
            {
                Console.WriteLine("invalid board");
                PrintBoard(board);
            }
            else
            {
                ValidateSudoku.ValidateSudokuPositioning(board);
                PrintBoard(board);
            }
            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds); 

            return 1;
        }

        static void Main(string[] args)
        {
            int program_status = 1;

            Console.WriteLine("This is a sudoku solver!\n");
            Console.WriteLine("You enter a sudoku board and the program solves it.");
            while(program_status != 0)
            {
                program_status = Game();
            }
        }
    }
}