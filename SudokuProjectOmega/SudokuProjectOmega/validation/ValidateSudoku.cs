using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The is a statics call with the role of validating the sudoku input.
    /// The class is an inportant piece in solving the sudoku
    /// </summary>
    public static class ValidateSudoku
    {
        /// <summary>
        /// The function is used to validate the users input.
        /// It is not used to check the sudoku logic.
        /// </summary>
        /// <param name="sudoku"> The user input in the form of a class </param>
        /// <exception cref="InvalidBoardSize"> Thrown is the user enterd an invalid board size
        /// or in other words a board size that has no full sqrt </exception>
        public static void CheckBoard(ISudokuInput sudoku)
        {
            double sqrt = Math.Sqrt(sudoku.Text.Length);

            // checks if the board has a valid size
            if(sqrt - (int)sqrt > 0)
            {
                throw new InvalidBoardSize();
            }
            ValidatePiece(sudoku.Text, (int)sqrt);
        }

        /// <summary>
        /// The function checks that in every cell, there is a valid value.
        /// The function is used in the CheckBoard function above.
        /// </summary>
        /// <param name="sudoku_string"> a string representing the sudoku </param>
        /// <param name="size"> the max potential value of the sudoku cell. </param>
        /// <exception cref="InvalidCharacter"> is thrown if the function finds an invalid cell value </exception>
        private static void ValidatePiece(String sudoku_string, int size)
        {
            int value;
            foreach (char tav in sudoku_string)
            {
                value = Convert.ToInt32(tav) - '0';
                if (value < 0 || value > size)
                    throw new InvalidCharacter();
            }
        }

        /// <summary>
        /// The function goes over every cell and checks if it holds a logical value.
        /// A logical value of a cell if a value that doesn't appere in the row, column and
        /// squere of the spesific cell
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <exception cref="InvalidBoradPositioning"> Is thrown if the function finds an elogical value
        /// to a cell</exception>
        public static void ValidateSudokuPositioning(Board board)
        {
            int i, j;
            for(i = 0; i < board.Size; i++)
            {
                for (j = 0; j < board.Size; j++)
                {
                    if(board.Get(i, j) != 0 && 
                        !ValidatePosition(Tactics.InvalidOptions(board, i, j), board.Get(i, j)))
                    {
                        throw new InvalidBoradPositioning();
                    }
                }
            }
        }

        /// <summary>
        /// The function gets a list of the serounding cells values around a given cell 
        /// and checks if the cell equal to one of them.
        /// Is used in the ValidateSudokuPositioning function to check each cell.
        /// </summary>
        /// <param name="serounding_cells"> a list containing the values of the surrounding cells </param>
        /// <param name="cell_value"> the value of the checked cell </param>
        /// <returns></returns>
        private static bool ValidatePosition(List<int> serounding_cells, int cell_value)
        {
            foreach(int serounding_cell in serounding_cells)
            {
                if(cell_value == serounding_cell)
                    return false; // found a match. meaning elogical value
            }
            return true; // dident find a match, meaning logical value
        }
    }
}
