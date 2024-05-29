using System;

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

            string player2Name = ConsoleInterface.ChoosePlayer2() ? ConsoleInterface.GetPlayerName() : "Computer";

            (int Cols, int Rows) board = ConsoleInterface.ChooseBoard();

            m_Player1 = new Player(player1Name);
            m_Player2 = new Player(player2Name);

            Ex02.ConsoleUtils.Screen.Clear();

            m_Board = new Board(board.Rows, board.Cols);

            m_Board.PrintBoard();
        }

 

        public void Start () 
        {
            Ex02.ConsoleUtils.Screen.Clear();
            // maybe move the logic from the constructor here
        }

        public void Play()
        {
            while (!m_GameOver)
            {
                playerTurn(m_Player1, m_Board);
                playerTurn(m_Player2, m_Board);
            }

        }
        public void End()
        {
            string gameWinner = getGameWinner();
            ConsoleInterface.GameOver(gameWinner);
        }
        private void playerTurn(Player i_Player, Board i_board)
        {
            ConsoleInterface.NewTurn(i_Player, i_board);

            string firstChoice = ConsoleInterface.GetChoice();

            //logic to convert choice to cell
            char FirstChar = i_board.FlipCell(1, 1);

            string SecondChoice = ConsoleInterface.GetChoice();

            // some logic to check if the cards are equal
           char SecondChar =  i_board.FlipCell(0, 0);

            //if (cardsMatch)
            //{
            // logic to leave them flipped
            i_Player.Score++;
            //}


            //(int Row, int Col) firstChoice = GetUserSelection();

            

        }

        private string getGameWinner()
        {
            string gameWinnner;

            if (m_Player1.Score > m_Player2.Score)
            {
                gameWinnner = m_Player1.Name;

            } else if (m_Player1.Score < m_Player2.Score)
            {

                gameWinnner= m_Player2.Name;

            } else
            {
                gameWinnner = "Tie";
            }

            return gameWinnner;

        }
    }


}
