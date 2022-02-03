using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class Board
    {
        private Cell[,] _board;
        public int? Size { get; set; }

        public Board(ISudokuInput sudoku)
        {
            ValidateSudoku.CheckBoard(sudoku);

            Size = (int)Math.Sqrt(sudoku.Text.Length);
            _board = new Cell[(int)Size, (int)Size];

            for (int i = 0; i < (int)Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _board[i, j] = new Cell((int)Size, i, j, sudoku.Text[i * (int)Size + j] - '0');
                }
            }

            ValidateSudoku.ValidateSudokuPositioning(this);
        }

        public int Get(int x, int y)
        {
            return _board[x, y].Value;
        }

        public Cell GetCell(int x, int y)
        {
            return _board[x, y];
        }

        public void Set(int value, int x, int y)
        {
            _board[x, y].Value = value;
        }

        public Cell[,] CloneBoard()
        {
            Cell[,] cells;

            cells = new Cell[(int)Size, (int)Size];
            for (int i = 0; i < (int)Size; i++)
            {
                for (int j = 0; j < (int)Size; j++)
                {
                    cells[i, j] = (Cell)GetCell(i, j).Clone();
                }
            }

            return cells;
        }

        public void copyToBoard(Cell[,] cells)
        {
            for(int i = 0; i < (int)Size; i++)
            {
                for (int j = 0; j < (int)Size; j++)
                {
                    _board[i,j] = (Cell)cells[i, j].Clone();
                }
            }
        }

        public void DeleteOptionFromAll(int option, int row, int col)
        {
            int i, j;
            for(i = 0; i < Size; i++)
            {
                _board[i, col].DeleteOption(new List<int> { option });
                _board[row, i].DeleteOption(new List<int> { option });
            }

            List<Cell> squere = Tactics.GetSquere(this, row, col);
            foreach (Cell c in squere)
            {
                c.DeleteOption(new List<int> { option });
            }
        }
    }
}
