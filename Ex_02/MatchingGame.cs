using System;
using System.Linq;

namespace Ex_02
{
    internal class MatchingGame
    {
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board;
        private bool m_GameOver;
      public MatchingGame()
        {
            
            string player1Name = ConsoleInterface.GetPlayerName();
            string player2Name = ConsoleInterface.BinarySelection("Computer", "PlayerTwo") ? ConsoleInterface.GetPlayerName() : "Computer";
            (int Rows, int Cols) board = ConsoleInterface.ChooseBoard();

            m_Player1 = new Player(player1Name);
            m_Player2 = new Player(player2Name);
            m_Board = new Board(board.Rows, board.Cols);

            Ex02.ConsoleUtils.Screen.Clear();

            ConsoleInterface.PrintBoard(m_Board);
        }

        public void Play()
        {
            while (true)
            {
                do
                {
                    playerTurn(m_Player1);
                    isGameOver();

                    if (m_GameOver)
                    {
                        break;
                    }
                }
                while (m_Player1.IsPlaying);

                if (m_GameOver)
                {
                    break;
                }

                do
                {
                    playerTurn(m_Player2);
                    isGameOver();

                    if (m_GameOver)
                    {
                        break;
                    }
                }
                while (m_Player2.IsPlaying);

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
            

            (int Row, int Col) firstGuessCoord = i_Player.Guess(m_Board);

            while(LogicValidation.IsAlreadyMatched(firstGuessCoord, m_Board))
            {
                firstGuessCoord = i_Player.Guess(m_Board);
            }

            char firstGuess = m_Board.FlipCell(firstGuessCoord.Row, firstGuessCoord.Col);

            (int Row, int Col) secondGuessCoord = i_Player.Guess(m_Board);

            while (!LogicValidation.ValidSecondCard(firstGuessCoord, secondGuessCoord) || LogicValidation.IsAlreadyMatched(secondGuessCoord, m_Board))
            {
                secondGuessCoord = i_Player.Guess(m_Board);
            }

            char secondGuess = m_Board.FlipCell(secondGuessCoord.Row, secondGuessCoord.Col);

            ConsoleInterface.ShowBoard(m_Board);

            bool matched = i_Player.IsMatch(firstGuess, secondGuess);
            if (matched)
            {
                m_Board.GotAMatch(firstGuessCoord, secondGuessCoord);

            }
            else
            {
                m_Board.FlipCell(firstGuessCoord.Row, firstGuessCoord.Col);
                m_Board.FlipCell(secondGuessCoord.Row, secondGuessCoord.Col);
                System.Threading.Thread.Sleep(2000);
                i_Player.IsPlaying = false;
            }

        }

        private Player getGameWinner()
        {
            Player gameWinnner = null;

            if (m_Player1.Score > m_Player2.Score)
            {
                gameWinnner = m_Player1;

            } else if (m_Player1.Score < m_Player2.Score)
            {

                gameWinnner= m_Player2;

            }

            return gameWinnner;
        }

        private void isGameOver()
        {
            m_GameOver = m_Board.IsBoardMatched();
        }
    }


}
