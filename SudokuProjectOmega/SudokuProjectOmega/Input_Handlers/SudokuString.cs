using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// The class parses and holds a sudoku string input
    /// </summary>
    public class SudokuString : ISudokuInput
    {
        public string Text { get; }

        public SudokuString(string sudoku_string)
        {
            Text = sudoku_string;
        }
    }
}
