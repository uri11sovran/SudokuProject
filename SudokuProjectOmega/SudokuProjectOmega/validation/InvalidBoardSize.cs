﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    public class InvalidBoardSize : SudokuException
    {
        public InvalidBoardSize() :
            base("Impossible board size...")
        {
        }
    }
}
