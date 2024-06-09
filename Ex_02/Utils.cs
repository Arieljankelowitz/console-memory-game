using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    internal class Utils
    {
        public static (int, int) GetGuessCoord(string i_guess)
        {
            char[] guessArray = i_guess.ToArray();

            int row = int.Parse(guessArray[1].ToString()) - 1;
            int col = guessArray[0] - 'A';

            return (row, col);
        }
    }
}
