using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// Main class. runs the sudoku solving 
    /// operation.
    /// </summary>
    public class Program
    {
        static void Main(string[] args)
        {
            int program_status = 1;

            Console.WriteLine("This is a sudoku solver!\n");
            Console.WriteLine("You enter a sudoku board and the program solves it.");
            while (program_status != 0)
            {
                program_status = Game();
            }
        }

        /// <summary>
        /// The function handles printing the sudoku result and getting the 
        /// initial sudoku input
        /// </summary>
        /// <returns> Returns 0 if the user wanted to stop the operation, 1 if the user whats to continue. </returns>
        static int Game()
        {
            int choice = HandleUserInput.GetInput();
            Console.Clear();
            string sudoku = HandleUserInput.getSudokuInput(choice);
            string result = Solve(sudoku, choice);

            if (result.Equals("exit"))
                return 0;

            return 1;
        }

        /// <summary>
        /// This function operates like a main function,
        /// it connects all the diffrent parts of the sudoku solver
        /// from the ui to the solving algorithm.
        /// </summary>
        /// <param name="sudoku"> The sudoku input </param>
        /// <param name="choice"> 0 - exit, 
        ///                       1 - string, 
        ///                       2 - text file </param>
        /// <returns> The sudoku solution or error massage. </returns>
        public static string Solve(string sudoku, int choice)
        {
            Board? board = null;

            if (choice != 0 && sudoku.Equals(""))
                return "Invalid Board: empty board";

            // Handle possible board exceptions
            try
            {
                board = HandleUserInput.TranslateToBoard(sudoku, choice);
            }
            catch (SudokuException invalid_sudoku)
            {
                Console.WriteLine(invalid_sudoku.Message);
                return invalid_sudoku.Message;
            }
            catch (System.IO.FileNotFoundException)
            {
                Console.WriteLine("The file does not exist");
                return "The file does not exist";
            }

            // the board will be null if the user enterd 0 - exit
            if (board == null)
                return "exit";

            // if the Solve function in the SudokuSolver returns false
            // the board is unsolvable
            if (!SudokuSolver.Solve(board))
                return "Unsolvable board";
            Print.PrintBoard(board);

            if(choice == 2)
                HandleDataFile(board);

            return board.ToString(); // return a string representation of the board
        }

        /// <summary>
        /// The funtion writes to a file the sudoku solution
        /// </summary>
        /// <param name="board"> The board to print </param>
        public static void HandleDataFile(Board board)
        {
            TextFile file = (TextFile)(board.Input);
            file.WriteToFile(board.ToString());
        }
    }
}