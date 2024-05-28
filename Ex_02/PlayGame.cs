using System;

namespace Ex_02
{
    internal class PlayGame
    {
        private Player m_Player1;
        private Player m_Player2;
        private Board m_Board;
      public PlayGame()
        {
            
        }

        public void Start () 
        {
            string player1Name = ConsoleUtils.GetPlayerName();

            string player2Name = ConsoleUtils.ChoosePlayer2() ? ConsoleUtils.GetPlayerName() : "Computer";

            (int Rows, int Cols) board = ConsoleUtils.ChooseBoard();

            m_Player1 = new Player(player1Name);
            m_Player2 = new Player(player2Name);

            m_Board = new Board(board.Rows, board.Cols);

        }
    }


}
