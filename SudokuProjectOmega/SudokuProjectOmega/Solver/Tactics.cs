using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The class predormes the hidden/naked single tactics of the sudoku board
    /// </summary>
    public static class Tactics
    {
        /// <summary>
        /// The function calls all the sudoku solving tactics and returns the number of cells reveled
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <returns> the number of cells reveled. </returns>
        public static int tactics(Board board)
        {
            int count;
            count = Singles(board);
            // open space for furture tactics
            return count;
        }

        /// <summary>
        /// The function preformes the tacatis hidden/naked single and returns the number
        /// of cells reveled.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <returns> the number of cells reveled. </returns>
        public static int Singles(Board board)
        {
            Cell curr_cell;
            int i, j, count = 0;

            for (i = 0; i < board.Size; i++)
            {
                for (j = 0; j < board.Size; j++)
                {
                    curr_cell = board.GetCell(i, j);
                    if (curr_cell.Value == 0)
                    {
                        count += HiddenSingles(board, i, j);
                        if (curr_cell.Value == 0)
                        {
                            curr_cell.DeleteOption(InvalidOperators(board, i, j));
                            if (curr_cell.NumOfOptions() == 1)
                            {
                                curr_cell.Value = curr_cell.options[0];
                                count++;
                                board.DeleteOptionFromAll(curr_cell.Value, i, j);
                            }
                            else if (curr_cell.NumOfOptions() == 0)
                                return -1;
                        }
                    }
                }
            }

            return count;
        }

        /// <summary>
        /// The function findes if the given cell position if a hidden sinlge.
        /// A hidden single is a cell that holds a possible value that the row, column or squere
        /// his on dont.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> 1 if the cell is a hidden single 0 if not </returns>
        public static int HiddenSingles(Board board, int row, int col)
        {
            int count = 0;

            count += FindSingles(board, board.GetRow(row, col), row, col);
            if(count == 0)
                count += FindSingles(board, board.GetCol(row, col), row, col);
            if(count == 0)
                count += FindSingles(board, board.GetSquere(row, col), row, col);

            return count;
        }

        /// <summary>
        /// The funtion finds if a cell is the only one holding a possible value in a sequence of cells.
        /// The funtion is used in the HiddenSingles funciton to check the row col and squere.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="sequence"> a list of cells that represents a row, col or squere of cells in the board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> 1 if the cell is a hidden single 0 if not </returns>
        public static int FindSingles(Board board, List<Cell> sequence, int row, int col)
        {
            int i, count = 0;
            bool does_exist = false;
            int[] options = board.GetCell(row, col).options;

            foreach (int option in options)
            {
                for (i = 0; i < sequence.Count && !does_exist; i++)
                {
                    if (sequence[i].Row != row || sequence[i].Col != col)
                    {
                        if ((sequence[i].Value == option ||
                            (sequence[i].Value == 0 && sequence[i].IsInOptions(option))))
                            does_exist = true;
                    }
                }
                if (!does_exist)
                {
                    board.GetCell(row, col).Value = option;
                    board.DeleteOptionFromAll(option, row, col);
                    count = 1;
                    break;
                }
                does_exist = false;
            }

            return count;
        }

        // Helper
        

        /// <summary>
        /// the funtion returns every invalid value the cell has.
        /// an invalid value is a value that has an instance on the row col or squere of the given cell.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> A list contaning all the invalid values.. </returns>
        public static List<int> InvalidOperators(Board board, int row, int col)
        {
            List<int> invalid_numbers = new List<int>();
            List<Cell> squere;
            int i;

            for (i = 0; i < board.Size; i++)
            {
                if (board.Get(row, i) != 0 && i != col)
                    invalid_numbers.Add(board.Get(row, i));
                if (board.Get(i, col) != 0 && i != row)
                    invalid_numbers.Add(board.Get(i, col));
            }

            squere = board.GetSquere(row, col);
            foreach (Cell c in squere)
            {
                if (c.Value != 0)
                    invalid_numbers.Add(c.Value);
            }

            return invalid_numbers;
        }
    }
}