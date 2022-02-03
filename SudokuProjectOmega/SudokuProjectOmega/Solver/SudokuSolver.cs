using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
#pragma warning disable CS8629 // Nullable value type may be null.
    public class SudokuSolver
    {
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

        public static bool BackTracking(Board board, Cell curr_cell)
        {
            Cell[,] cells = board.CloneBoard();
            curr_cell.DeleteOption(Tactics.InvalidOperators(board, curr_cell.Row, curr_cell.Col));
            foreach (int option in curr_cell.options)
            {
                board.Set(option, curr_cell.Row, curr_cell.Col);
                if (Solve(board))
                    return true;
                board.copyToBoard(cells);
            }

            return false;
        }

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
