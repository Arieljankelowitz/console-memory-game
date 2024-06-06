using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    internal class SyntaxValidation
    {
        internal static bool ValidPlayerName(string i_PlayerName)
        {
            bool lessThan20Chars = i_PlayerName.Length <= 20;
            bool containSpace = i_PlayerName.Any(Char.IsWhiteSpace);
            bool isEmpty = string.IsNullOrEmpty(i_PlayerName);

            bool validName = !isEmpty && lessThan20Chars && !containSpace;

            return validName;
        }

        internal static bool ValidCard(string i_Card, Board i_Board)
        {
            bool validLetter = false;
            bool validNumber = false;
            bool isTwoChars = i_Card.Length == 2;
            bool isEmpty = string.IsNullOrEmpty(i_Card);

            if (!isEmpty && isTwoChars)
            {
                validLetter = i_Card[0] >= 'A' && i_Card[0] < 'A' + i_Board.NumOfCols;
                validNumber = char.IsDigit(i_Card[1]) && int.Parse(i_Card[1].ToString()) >= 1 && int.Parse(i_Card[1].ToString()) <= i_Board.NumOfRows;

            }

            bool validCard = !isEmpty && isTwoChars && validLetter && validNumber;

            return validCard;

        }
    }
}
