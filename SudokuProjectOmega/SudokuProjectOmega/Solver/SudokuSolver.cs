using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
#pragma warning disable CS8629 // Nullable value type may be null.
    /// <summary>
    /// The class is a sudoku solving algorithem that uses the 
    /// principle of backtracking and combines it with sudoku solving tactics, hidden single
    /// and naked single
    /// </summary>
    public class SudokuSolver
    {
        /// <summary>
        /// The function combindes the all the solving functions.
        /// 
        ///  - First the function uses the tactics function to solve solvable cells with the hidden/naked single methods
        ///  
        ///  - Second the function checks if the board is solved, if true, the function exits the recursion and returns true.
        ///  
        ///  - The funtion uses the count variable as a counter of the number of numbers the tactics was able to solve
        ///    after proforming its operation. is the count is more then zero, continue solving using the tactics.
        ///    if the count is zero, guess an option from the cell with the least amount of options.
        ///    If the count is -1, the function returns false representing that one of the former guesses was wrong.
        ///    
        /// </summary>
        /// <param name="board"> The sudoku board to solve. </param>
        /// <returns> true if the board was solved, false if not. </returns>
        public static bool Solve(Board board)
        {
            int count = 0;

            count = Tactics.tactics(board);

            if (CheckIfBoardFull(board))
               return true;

            if (count == -1)
                return false;

            if(count == 0)
                return BackTracking(board, guessSmallestCell(board));

            return Solve(board);
        }

        /// <summary>
        /// The function checks if the board was solved
        /// </summary>
        /// <param name="board"></param>
        /// <returns></returns>
        public static bool CheckIfBoardFull(Board board)
        {
            for (int  i = 0; i < board.Size; i++)
            {
                for (int j = 0; j < board.Size; j++)
                {
                    if(board.GetCell(i,j).Value == 0)
                        return false;
                }
            }
            return true;
        }

        /// <summary>
        /// The function is a backtrincking dunction that guesses one of the options in the smallest cell in the board.
        /// </summary>
        /// <param name="board"></param>
        /// <param name="curr_cell"></param>
        /// <returns></returns>
        public static bool BackTracking(Board board, Cell curr_cell)
        {
            // colnes the current state of the board
            // is used to reload the state old state of the board if the guess was incorrect
            Cell[,] cells = board.CloneBoard();
            // delets the options around the cell to guess
            curr_cell.DeleteOption(Tactics.InvalidOperators(board, curr_cell.Row, curr_cell.Col));

            // the loop goes over every possible value of the cell
            foreach (int option in curr_cell.options)
            {
                board.Set(option, curr_cell.Row, curr_cell.Col); // sets a guess (one of the possible cell values)
                // sends to the solve board to comtinue solving the board
                if (Solve(board))
                    return true;
                // If the Solve function retuns false, the guess the function gusset was wrong.
                // In that case the function reloads the former state of the board and guesses a diffrent option
                board.copyToBoard(cells);
            }

            return false;
        }

        /// <summary>
        /// The funtion finds the cell with the least amount of options
        /// </summary>
        /// <param name="board"></param>
        /// <returns> the smallest cell </returns>
        public static Cell guessSmallestCell(Board board)
        {
            Cell smallest_cell = null;
            int min = -1, i, j;

            for (i = 0; i < board.Size; i++)
            {
                for (j = 0; j < board.Size; j++)
                {
                    if (board.GetCell(i, j).Value == 0 && (smallest_cell == null || board.GetCell(i, j).NumOfOptions() < min))
                    {
                        smallest_cell = board.GetCell(i, j);
                        min = smallest_cell.NumOfOptions();
                    }
                }
            }

            return smallest_cell;
        }
    }
#pragma warning restore CS8629 // Nullable value type may be null.
}
