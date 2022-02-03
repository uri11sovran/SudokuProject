using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class SudokuString : ISudokuInput
    {
        public string Text { get; }

        public SudokuString(string sudoku_string)
        {
            Text = sudoku_string;
        }
    }
}
