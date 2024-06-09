namespace Ex_02
{
    internal class LogicValidation
    {
        internal static bool ValidSecondCard((int Row, int Col) firstGuess, (int Row, int Col) secondGuess)
        {
            bool validGuess = firstGuess != secondGuess;

            return validGuess;
        }

        internal static bool IsValidCard((int Row, int Col) firstGuess, Board i_board)
        {
            bool isAlreadyMatched = true;
            bool validRow = 0 <= firstGuess.Row  && firstGuess.Row < i_board.NumOfRows;
            bool validCol = firstGuess.Col < i_board.NumOfCols;
            bool validCoords = validRow && validCol;

            if (validCoords)
            {
                isAlreadyMatched = i_board.AlreadyMatched(firstGuess.Row, firstGuess.Col);
            }

            bool validCard = validCoords && !isAlreadyMatched;

            return validCard;
        }
    }
}
