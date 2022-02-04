using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The class is a sudoku board that holds all the possible cells
    /// </summary>
    public class Board
    {
        public ISudokuInput Input { get; set; }
        public int? Size { get; set; } // teh size of the board (highet and width)

        private Cell[,] _board; // a natrix of all sudoku cells

        /// <summary>
        /// The function is a generic board constractor.
        /// The cojnstractor gets a sudoku and translates it to a board.
        /// The function uses ValidateSudoku static class to validate the sudoku.
        /// </summary>
        /// <param name="sudoku"> The input the user enterd </param>
        public Board(ISudokuInput sudoku)
        {
            ValidateSudoku.CheckBoard(sudoku);

            // stes the _board matrix size
            Size = (int)Math.Sqrt(sudoku.Text.Length);
            _board = new Cell[(int)Size, (int)Size];

            for (int i = 0; i < (int)Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _board[i, j] = new Cell((int)Size, i, j, sudoku.Text[i * (int)Size + j] - '0');
                }
            }
            Input = sudoku;

            ValidateSudoku.ValidateSudokuPositioning(this);

            // the first part of the sudoku solver, the operation deletes all impossible 
            // cell values for each cell of the board.
            // used as a board setter
            DeleteOperators();
        }

        /// <summary>
        /// the function returns the value of a cell in a given position
        /// </summary>
        /// <param name="x"> the row the cell is on </param>
        /// <param name="y"> the column the cell is on </param>
        public int Get(int x, int y)
        {
            return _board[x, y].Value;
        }

        /// <summary>
        /// the function returns a cell in a given position
        /// </summary>
        /// <param name="x"> the row the cell is on </param>
        /// <param name="y"> the column the cell is on </param>
        public Cell GetCell(int x, int y)
        {
            return _board[x, y];
        }

        /// <summary>
        /// The function sets the value of a cell in a given position
        /// </summary>
        /// <param name="value"> The cells new value </param>
        /// <param name="x"> the row the cell is on </param>
        /// <param name="y"> the column the cell is on </param>
        public void Set(int value, int x, int y)
        {
            _board[x, y].Value = value;
        }

        /// <summary>
        /// The function is used to set the board when its first constructed.
        /// </summary>
        /// <param name="board"> The board to initiate. </param>
        public void DeleteOperators()
        {
            Cell curr_cell;
            int i, j;

            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size; j++)
                {
                    curr_cell = GetCell(i, j);
                    curr_cell.DeleteOption(Tactics.InvalidOperators(this, i, j));
                }
            }
        }

        /// <summary>
        /// The dunction clones the _board cell matrix
        /// </summary>
        /// <returns> a cloned cell matrix </returns>
        public Cell[,] CloneBoard()
        {
            Cell[,] cells;

            // sets the new matrix size
            cells = new Cell[(int)Size, (int)Size];
            for (int i = 0; i < (int)Size; i++)
            {
                for (int j = 0; j < (int)Size; j++)
                {
                    // uses the Clone funtion in the cell class
                    // to clone the cell objects
                    cells[i, j] = (Cell)GetCell(i, j).Clone();
                }
            }

            return cells;
        }

        /// <summary>
        /// The function copies a cell matrix to the board
        /// </summary>
        /// <param name="cells"> the cell matrix to copy </param>
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

        /// <summary>
        /// The function deletes from every affected cell the value of a 
        /// cell the Solve funciton sloved.
        /// An affected cell is a cell that is ether in the same row, column or
        /// squere as the solved cell
        /// </summary>
        /// <param name="option"> the option to delete </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col"> the column the cell is on </param>
        public void DeleteOptionFromAll(int option, int row, int col)
        {
            int i;

            // deletes the option from the rows and columns
            for(i = 0; i < Size; i++)
            {
                // beacuse the DeleteOption function gets a list of options 
                // the function constructs a new list with only the cells value
                _board[i, col].DeleteOption(new List<int> { option });
                _board[row, i].DeleteOption(new List<int> { option });
            }

            // deletes the option from the squere
            List<Cell> squere = GetSquere(row, col);
            foreach (Cell c in squere)
            {
                c.DeleteOption(new List<int> { option });
            }
        }

        /// <summary>
        /// The funtion is a help function used in the FindSingles function to return a list 
        /// of cells that represents a column on the board.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> the list of cells </returns>
        public List<Cell> GetRow(int row, int col)
        {
            List<Cell> Row = new List<Cell>();

            for (int i = 0; i < Size; i++)
            {
                Row.Add(GetCell(row, i));
            }

            return Row;
        }

        /// <summary>
        /// The funtion is a help function used in the FindSingles function to return a list 
        /// of cells that represents a row on the board.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> the list of cells </returns>
        public List<Cell> GetCol(int row, int col)
        {
            List<Cell> Col = new List<Cell>();

            for (int i = 0; i < Size; i++)
            {
                Col.Add(GetCell(i, col));
            }

            return Col;
        }

        /// <summary>
        /// The funtion is a help function used in the FindSingles function to return a list 
        /// of cells that represents a squere on the board.
        /// </summary>
        /// <param name="board"> the sudoku board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col">  the col the cell is on </param>
        /// <returns> the list of cells </returns>
        public List<Cell> GetSquere(int row, int col)
        {
            List<Cell> squere = new List<Cell>();
            int sqrt = (int)Math.Sqrt((int)Size);
            int boxRowStart = row - row % sqrt;
            int boxColStart = col - col % sqrt;

            for (int r = boxRowStart; r < boxRowStart + sqrt; r++)
            {
                for (int d = boxColStart; d < boxColStart + sqrt; d++)
                {
                    if (row != r || col != d)
                        squere.Add(GetCell(r, d));
                }
            }

            return squere;
        }

        /// <summary>
        /// The function returns a string representation of the sudoku board.
        /// Overrides the Object funtion ToString().
        /// Is used in the Solve funtion to return a strign of the sudoku.
        /// </summary>
        /// <returns> The sudoku string representation </returns>
        public override string ToString()
        {
            StringBuilder board_str = new StringBuilder(); // The sudoku string representation
            int i, j;

            for (i = 0; i < Size; i++)
            {
                for (j = 0; j < Size; j++)
                {
                    board_str.Append((char)(_board[i,j].Value + '0'));
                }
            }

            return board_str.ToString();
        }
    }
}
