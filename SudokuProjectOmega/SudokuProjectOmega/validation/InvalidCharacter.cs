using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// The class is an exception thrown when the user enters an invlid charcter
    /// </summary>
    public class InvalidCharacter : SudokuException
    {
        public InvalidCharacter() :
            base("Invalid input: all characters must be a valid in range sudoku characters...")
        {
        }
    }
}
