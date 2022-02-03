using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    public class SudokuException : Exception
    {
        public SudokuException(string msg) :
            base(msg)
        {
        }
    }
}
