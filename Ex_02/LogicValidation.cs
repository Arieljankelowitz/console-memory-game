using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    internal class LogicValidation
    {
        internal static bool ValidSecondCard((int Row, int Col) firstGuess, (int Row, int Col) secondGuess)
        {
            bool validGuess = firstGuess != secondGuess;

            return validGuess;
        }

        internal static bool IsAlreadyMatched((int Row, int Col) firstGuess, Board i_board)
        {
            bool isAlreadyMatched = i_board.alreadyMatched(firstGuess.Row, firstGuess.Col);

            return isAlreadyMatched;
        }
    }
}
