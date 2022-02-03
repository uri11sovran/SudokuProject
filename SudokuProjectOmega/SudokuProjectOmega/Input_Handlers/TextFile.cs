using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProject
{
    public class TextFile : ISudokuInput
    {
        public string Text { get; }

        public TextFile(string path)
        {
            Text = System.IO.File.ReadAllText(path);
        }
    }
}
