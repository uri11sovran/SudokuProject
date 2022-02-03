using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The interface represents every sudoku 
    /// input
    /// </summary>
    public interface ISudokuInput
    {
        string Text { get; } // The sudoku baord as a string.
    }
}
