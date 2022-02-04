using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SudokuProjectOmega
{
    /// <summary>
    /// The class is used to get a sudoku string from a text file
    /// </summary>
    public class TextFile : ISudokuInput
    {
        public string Text { get; }
        private string _new_file;

        public TextFile(string path)
        {
            if (!path.Contains("txt"))
                throw new NotText();
            Text = System.IO.File.ReadAllText(path);
            _new_file = path.Replace(".txt", "_solved.txt");
        }

        public void WriteToFile(string sudoku)
        {
            File.WriteAllText(_new_file, sudoku);
        }
    }
}
