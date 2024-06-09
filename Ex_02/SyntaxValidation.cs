using System;
using System.Linq;

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

        internal static bool ValidCard(string i_Card)
        {
            bool validLetter = false;
            bool validNumber = false;
            bool isTwoChars = i_Card.Length == 2;
            bool isEmpty = string.IsNullOrEmpty(i_Card);

            if (!isEmpty && isTwoChars)
            {
                validLetter = char.IsUpper(i_Card[0]);
                validNumber = char.IsDigit(i_Card[1]);
            }

            bool validCard = !isEmpty && isTwoChars && validLetter && validNumber;

            return validCard;

        }
    }
}
