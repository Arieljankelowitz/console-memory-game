using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex_02
{
    internal class InputValidation
    {
        internal static bool ValidPlayerName(string i_PlayerName)
        {
            bool lessThan20Chars = i_PlayerName.Length <= 20;
            bool containSpace = i_PlayerName.Contains(" ");
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
            bool alreadyMatched = true;
            
            if (!isEmpty && isTwoChars) 
            {
                validLetter = i_Card[0] >= 'A' && i_Card[0] < 'A' + i_Board.NumOfCols;
                validNumber = char.IsDigit(i_Card[1]) && int.Parse(i_Card[1].ToString()) >= 1 && int.Parse(i_Card[1].ToString()) <= i_Board.NumOfRows;
                
                
            } if (validLetter && validNumber)
            {
                (int Row, int Col) guessCoord = Utils.getGuessCoord(i_Card);
                alreadyMatched = i_Board.alreadyMatched(guessCoord.Row, guessCoord.Col);
            }
            

            bool validCard = !isEmpty && isTwoChars && validLetter && validNumber && !alreadyMatched;

            return validCard;

        }
    }
}
