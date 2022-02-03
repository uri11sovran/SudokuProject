using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The class represents a cell in the sudoku board.
    /// The class holds the cells veriables and usful functions.
    /// </summary>
    public class Cell : ICloneable
    {
        public int Value { get; set; } // The number the cell holdes
        public int Row { get; set; } // the row the cell is on
        public int Col { get; set; } // the column the cell is on
        public int[] options { get; set; } // all the possible cell values

        /// <summary>
        /// The function is a cell constractor sets the cell
        /// </summary>
        /// <param name="board_len"> the length of the board </param>
        /// <param name="row"> the row the cell is on </param>
        /// <param name="col"> the column the cellis on </param>
        /// <param name="value"> the value the cell holds </param>
        public Cell(int board_len, int row, int col, int value)
        {
            // sets the number of options the cell can hold
            options = new int[board_len];
            Row = row;
            Col = col;
            Value = value;

            // sets every cell option
            for (int i = 0; i < board_len; i++)
                options[i] = i + 1;
        }

        /// <summary>
        /// The funtion returns the number of options the cell has
        /// </summary>
        /// <returns></returns>
        public int NumOfOptions()
        {
            return options.Length;
        }

        /// <summary>
        /// The funtion delets every value in the invalidOptions list from the 
        /// options array.
        /// The function is mostly used in the Tactics file.
        /// </summary>
        /// <param name="invalidOptions"> a list holding the invalid values of the position </param>
        /// <returns> flase if the cell alredy has zero oprions, true if secsefuly deleted an option </returns>
        public bool DeleteOption(List<int> invalidOptions)
        {
            foreach (int invalidOption in invalidOptions)
            {
                options = options.Where(val => val != invalidOption).ToArray();
            }

            if (options.Length == 0)
                return false;

            return true;
        }

        /// <summary>
        /// The function checks if a given value is a possible cell value
        /// </summary>
        /// <param name="option"></param>
        /// <returns> true if is a possible cell value otherwise false. </returns>
        public bool IsInOptions(int option)
        {
            foreach (int Option in options)
            {
                if (Option == option)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// The function returns a clone of the cell.
        /// The function implements the ICloneable interface.
        /// </summary>
        /// <returns></returns>
        public object Clone()
        {
            Cell new_cell = new Cell(NumOfOptions(), Row, Col, Value);
            int i;
            
            for(i = 0; i < NumOfOptions(); i++)
                new_cell.options[i] = options[i];

            return new_cell;
        }
    }
}
