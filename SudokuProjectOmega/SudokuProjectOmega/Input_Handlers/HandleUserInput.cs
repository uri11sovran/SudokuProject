using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{

    /// <summary>
    /// The class is a static user input hendler that gets the user input,
    /// validets it and returns a board representation of the input
    /// </summary>
    static class HandleUserInput
    {
        /// <summary>
        /// The function gets a user string representaion of a sudoku and returns a 
        /// board representation of the same sudoku
        /// </summary>
        /// <returns> The board sudoku board.
        /// null if the user entered 0 </returns>
        public static Board? TranslateToBoard(string sudoku, int choice)
        {
            Board? board = null; // the board holding the sudoku
            ISudokuInput input; // the sudoku itself

            switch (choice)
            {
                case 1:
                    // if the user enterd a string
                    input = new SudokuString(sudoku);
                    board = new Board(input);
                    break;

                case 2:
                    // if the user enterd a file path
                    input = new TextFile(sudoku);
                    board = new Board(input);
                    break;
            }

            return board;
        }

        /// <summary>
        /// This is a help function that serves as a user choice getter.
        /// Is used to get the users choice in the Menu function.
        /// </summary>
        /// <returns> The users choice. </returns>
        public static int GetInput()
        {
            int input = -1;

            Console.WriteLine("1. Enter a string representation of the sudoku board");
            Console.WriteLine("2. Enter a name of a text file");
            Console.WriteLine("0: EXIT");

            while (input == -1)
            {
                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch (System.FormatException)
                {
                    Console.WriteLine("You must enter a number!");
                    input = -1;
                }
                catch (System.OverflowException)
                {
                    Console.WriteLine("You must enter a number!");
                    input = -1;
                }
                if(input < 0 || input > 2)
                {
                    Console.WriteLine("The number you entened must be between 0 - 2!");
                    input = -1;
                }
            }

            return input;
        }

        /// <summary>
        /// The funtion gets and returns the user input
        /// </summary>
        /// <param name="choice"> The type of input the user whats to enter </param>
        /// <returns> the user input </returns>
        public static string getSudokuInput(int choice)
        {
            string sudoku = null;

            switch (choice)
            {
                // exit
                case 0:
                    Console.WriteLine("Good Bye!");
                    break;

                // is the user enterd a string
                case 1:
                    Console.WriteLine("Enter the sudoku string representation");
                    sudoku = Console.ReadLine();
                    break;

                // is the user enterd a file path
                case 2:
                    Console.WriteLine("Enter the file path that holds the sudoku string representation");
                    sudoku = Console.ReadLine();
                    break;
            }

            return sudoku;
        }
    }
}
