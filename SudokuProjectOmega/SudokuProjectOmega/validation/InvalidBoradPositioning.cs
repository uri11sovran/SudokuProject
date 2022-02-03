using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    /// <summary>
    /// The class is an exception that is thrown when the user enterd an impossible
    /// cell value.
    /// Meaning the cell holds an invalid value for its position.
    /// </summary>
    public class InvalidBoradPositioning : SudokuException
    {
        public InvalidBoradPositioning() : 
            base("Cannot solve this board due to invalid cell positioning...")
        {
        }
    }
}
