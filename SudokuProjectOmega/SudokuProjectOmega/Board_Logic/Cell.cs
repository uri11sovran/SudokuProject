using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class Cell : ICloneable
    {
        public int Value { get; set; }
        public int Row { get; set; }
        public int Col { get; set; }
        public int[] options { get; set; }

        public Cell(int board_len, int row, int col, int value)
        {
            options = new int[board_len];
            Row = row;
            Col = col;
            Value = value;

            for (int i = 0; i < board_len; i++)
                options[i] = i + 1;
        }

        public int NumOfOptions()
        {
            return options.Length;
        }

        public bool DeleteOption(List<int> invalidOptions)
        {
            //for (int i = 0; i < options.Length; i++)
            //    Console.Write("{0}", options[i]);
            //Console.WriteLine("");

            foreach (int invalidOption in invalidOptions)
            {
                //Console.WriteLine("{0}", invalidOption);
                options = options.Where(val => val != invalidOption).ToArray();
            }

            //for (int i = 0; i < options.Length; i++)
            //    Console.Write("{0}", options[i]);
            if (options.Length == 0)
                return false;

            return true;
        }

        public bool IsInOptions(int option)
        {
            foreach (int Option in options)
            {
                if (Option == option)
                    return true;
            }
            return false;
        }

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
