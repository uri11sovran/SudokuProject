using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    static class HandleUserInput
    {
        public static Board? Menu()
        {
            Board? board = null;
            ISudokuInput input;
            int user_input = 1;

            Console.WriteLine("1. Enter a string representation of the sudoku board");
            Console.WriteLine("2. Enter a name of a text file");
            Console.WriteLine("0: EXIT");

            user_input = GetInput();
            switch (user_input)
            {
                case 0:
                    Console.WriteLine("Good Bye!");
                    break;

                case 1:
                    Console.WriteLine("Enter the sudoku string representation");
                    input = new SudokuString(Console.ReadLine());
                    board = new Board(input);
                    break;

                case 2:
                    Console.WriteLine("Enter the file path that holds the sudoku string representation");
                    input = new TextFile(Console.ReadLine());
                    board = new Board(input);
                    break;
            }

            return board;
        }

        private static int GetInput()
        {
            int input = -1;

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
    }
}
