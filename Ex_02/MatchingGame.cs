namespace Ex_02
{
    internal class MatchingGame
    {

        private readonly Player r_Player1;
        private readonly Player r_Player2;
        private readonly Board r_Board;
        private bool m_GameOver;

      public MatchingGame()
        {
            string player1Name = ConsoleInterface.GetPlayerName();
            string player2Name = ConsoleInterface.BinarySelection("Computer", "Player 2", "Choose your opponent:") ? ConsoleInterface.GetPlayerName() : "Computer";
            (int rows, int cols) = ConsoleInterface.ChooseBoard();

            r_Player1 = new Player(player1Name);
            r_Player2 = new Player(player2Name);
            r_Board = new Board(rows, cols);

            Ex02.ConsoleUtils.Screen.Clear();

            ConsoleInterface.PrintBoard(r_Board);
        }

        public void Play()
        {
            while (true)
            {
                do
                {
                    playerTurn(r_Player1);
                    isGameOver();

                    if (m_GameOver)
                    {
                        break;
                    }
                }
                while (r_Player1.IsPlaying);

                if (m_GameOver)
                {
                    break;
                }

                do
                {
                    playerTurn(r_Player2);
                    isGameOver();

                    if (m_GameOver)
                    {
                        break;
                    }
                }
                while (r_Player2.IsPlaying);

                if (m_GameOver)
                {
                    break;
                }
            }
        }

        public void End()
        {
            Player gameWinner = getGameWinner();
            ConsoleInterface.GameOver(gameWinner);
        }

        private void playerTurn(Player i_Player)
        {
            string playerSecondGuess;

            (int Row, int Col) firstGuessCoord = getPlayerGuess(i_Player);
            char firstGuess = r_Board.FlipCell(firstGuessCoord.Row, firstGuessCoord.Col);

            (int Row, int Col) secondGuessCoord = getPlayerGuess(i_Player);

            while (!LogicValidation.ValidSecondCard(firstGuessCoord, secondGuessCoord))
            {
                if (i_Player.IsComputer)
                {
                    secondGuessCoord = i_Player.Guess(r_Board);
                }
                else
                {
                    string errMsg = "Card already chosen";
                    playerSecondGuess = ConsoleInterface.GuessAgain(i_Player, r_Board, errMsg);
                    secondGuessCoord = Utils.GetGuessCoord(playerSecondGuess);

                    while (!LogicValidation.IsValidCard(secondGuessCoord, r_Board))
                    {
                        string matcherrMsg = "Invlaid card (Logical error)";
                        playerSecondGuess = ConsoleInterface.GuessAgain(i_Player, r_Board, matcherrMsg);
                        secondGuessCoord = Utils.GetGuessCoord(playerSecondGuess);
                    }
                }

                
            }

            char secondGuess = r_Board.FlipCell(secondGuessCoord.Row, secondGuessCoord.Col);

            ConsoleInterface.ShowBoard(r_Board);

            bool matched = i_Player.IsMatch(firstGuess, secondGuess);

            if (matched)
            {
                r_Board.GotAMatch(firstGuessCoord, secondGuessCoord);
                i_Player.IsPlaying = true;

            }
            else
            {
                r_Board.FlipCell(firstGuessCoord.Row, firstGuessCoord.Col);
                r_Board.FlipCell(secondGuessCoord.Row, secondGuessCoord.Col);
           
                i_Player.IsPlaying = false;
            }

            System.Threading.Thread.Sleep(2000);
        }

        private Player getGameWinner()
        {
            Player gameWinnner = null;

            if (r_Player1.Score > r_Player2.Score)
            {
                gameWinnner = r_Player1;

            } else if (r_Player1.Score < r_Player2.Score)
            {

                gameWinnner= r_Player2;

            }

            return gameWinnner;
        }

        private void isGameOver()
        {
            m_GameOver = r_Board.IsBoardMatched();
        }

        private (int Row, int Col) getPlayerGuess(Player i_Player)
        {
            string playerGuess;
            (int Row, int Col) guessCoord;
            if (i_Player.IsComputer)
            {
                guessCoord = i_Player.Guess(r_Board);
            }
            else
            {
                playerGuess = ConsoleInterface.NewGuess(i_Player, r_Board);
                guessCoord = Utils.GetGuessCoord(playerGuess);

                while (!LogicValidation.IsValidCard(guessCoord, r_Board))
                {
                    string errMsg = "Invlaid card (Logical error)";
                    playerGuess = ConsoleInterface.GuessAgain(i_Player, r_Board, errMsg);
                    guessCoord = Utils.GetGuessCoord(playerGuess);
                }
            }

            return guessCoord;
        }
    }


}
