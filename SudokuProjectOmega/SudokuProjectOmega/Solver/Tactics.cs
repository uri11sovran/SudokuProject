using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace SudokuProject
{
    public static class Tactics
    {
        public static int tactics(Board board)
        {
            int count;

            count = nakedSingle(board);
            if(count == -1)
                return -1;

            return count;
        }

        public static int nakedSingle(Board board)
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

        public static int HiddenSingles(Board board, int row, int col)
        {
            int count = 0;

            count += FindSingles(board, GetRow(board, row, col), row, col);
            if(count == 0)
                count += FindSingles(board, GetCol(board, row, col), row, col);
            if(count == 0)
                count += FindSingles(board, GetSquere(board, row, col), row, col);

            return count;
        }

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
        public static List<Cell> GetRow(Board board, int row, int col)
        {
            List<Cell> Row = new List<Cell>();

            for (int i = 0; i < board.Size; i++)
            {
                Row.Add(board.GetCell(row, i));
            }

            return Row;
        }

        public static List<Cell> GetCol(Board board, int row, int col)
        {
            List<Cell> Col = new List<Cell>();

            for (int i = 0; i < board.Size; i++)
            {
                Col.Add(board.GetCell(i, col));
            }

            return Col;
        }

        public static List<Cell> GetSquere(Board board, int row, int col)
        {
            List<Cell> squere = new List<Cell>();
            int sqrt = (int)Math.Sqrt((int)board.Size);
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for (int d = boxColStart; d < boxColStart + sqrt; d++)
                {
                    if(row != r || col != d)
                        squere.Add(board.GetCell(r, d));
                }
            }

            return squere;
        }

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

            squere = GetSquere(board, row, col);
            foreach (Cell c in squere)
            {
                if (c.Value != 0)
                    invalid_numbers.Add(c.Value);
            }

            return invalid_numbers;
        }

        public static void DeleteOperators(Board board)
        {
            Cell curr_cell;
            int i, j;

            for (i = 0; i < board.Size; i++)
            {
                for (j = 0; j < board.Size; j++)
                {
                    curr_cell = board.GetCell(i, j);
                    curr_cell.DeleteOption(InvalidOperators(board, i, j));
                }
            }
        }
    }
}