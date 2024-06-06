
using System;
using System.Linq;

namespace Ex_02
{
    internal class Player
    {
        private bool m_IsComputer;
        public string Name { get; }
        public int Score { get; set; }

        public bool IsPlaying { get; set; }

        public Player(string i_Name)
        {
            Name = i_Name;

            m_IsComputer = i_Name == "Computer";
        }


        internal (int, int) Guess(Board i_board)
        {
            (int Row, int Col) cellCoord;
            if (m_IsComputer)
            {
                Computer computerPlayer = new Computer();
                cellCoord = computerPlayer.computerGuess(i_board);
            }
            else
            {
                cellCoord = humanGuess(i_board);
            }


            return cellCoord;
        }

        internal bool IsMatch(char i_FirstGuess, char i_SecondGuess)
        {
            bool isMatch = false;

            if (i_FirstGuess == i_SecondGuess)
            {
                Score++;
                isMatch = true;
            }

            return isMatch;
        }


        private (int, int) humanGuess(Board i_board)
        {
            string guess = ConsoleInterface.NewGuess(this, i_board);
            (int Row, int Col) cellCoord = Utils.getGuessCoord(guess);

            return cellCoord;
        }
        internal class Computer {
            internal (int, int) computerGuess(Board i_board)
            {
                Random random = new Random();
                int rowGuess = random.Next(0, i_board.NumOfRows);
                int coloumGuss = random.Next(0, i_board.NumOfCols);
                (int, int) cellCoord = (rowGuess, coloumGuss);

                System.Console.WriteLine("comuter gessing" + cellCoord);
                System.Threading.Thread.Sleep(3000);

                bool alreadyMatched = i_board.alreadyMatched(rowGuess, coloumGuss);

                if (alreadyMatched)
                {
                    cellCoord = computerGuess(i_board);
                }

                return cellCoord;
            }
        }



    }
}
