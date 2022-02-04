using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    public class NotText : SudokuException
    {
        public NotText() : 
            base("Not a text file")
        { 
        }
    }
}
