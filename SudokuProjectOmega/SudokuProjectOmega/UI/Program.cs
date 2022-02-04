﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    public class Program
    {
        /// <summary>
        /// This function operates like a main function,
        /// it connects all the diffrent parts of the sudoku solver
        /// from the ui to the solving algorithm.
        /// </summary>
        /// <param name="sudoku"> The sudoku input </param>
        /// <param name="choice"> 0 - exit, 1 - string, 2 - text file </param>
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
                return invalid_sudoku.Message;
            }
            catch (System.IO.FileNotFoundException)
            {
                return "The file does not exist";
            }

            // the board will be null if the user enterd 0 - exit
            if (board == null)
                return "exit";

            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            if (!SudokuSolver.Solve(board))
                return "Unsolvable board";

            ValidateSudoku.ValidateSudokuPositioning(board);
            Print.PrintBoard(board);

            stopwatch.Stop();
            Console.WriteLine("Elapsed Time is {0} ms", stopwatch.ElapsedMilliseconds);

            return board.ToString(); // return a ToString of the board
        }

        /// <summary>
        /// The function handles printing the sudoku result and getting the 
        /// initial sudoku input
        /// </summary>
        /// <returns> Returns 0 if the user wanted to stop the operation, 1 if the user whats to continue. </returns>
        static int Game()
        {
            int choice = HandleUserInput.GetInput();
            string sudoku = HandleUserInput.getSudokuInput(choice);

            string result = Solve(sudoku, choice);

            if (result.Equals("exit"))
                return 0;
            Console.WriteLine(result);

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