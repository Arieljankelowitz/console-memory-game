
using System;


namespace Ex_02
{
    internal class Player
    {
        private readonly bool r_IsComputer;
        private static readonly Computer sr_Computer = new Computer();

        public string Name { get; }
        public int Score { get; set; }
        public bool IsPlaying { get; set; }
        public bool IsComputer {  get { return r_IsComputer; } }

        public Player(string i_Name)
        {
            Name = i_Name;
            if (Name == "Computer")
            {
                r_IsComputer = true;
            }
        }

        internal (int, int) Guess(Board i_board)
        {
            (int Row, int Col) cellCoord = sr_Computer.ComputerGuess(i_board);

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

        internal class Computer {

            internal (int, int) ComputerGuess(Board i_board)
            {
                Random random = new Random();
                (int, int) cellCoord;
                int rowGuess, coloumGuss;
                bool alreadyMatched;

                do
                {
                    rowGuess = random.Next(0, i_board.NumOfRows);
                    coloumGuss = random.Next(0, i_board.NumOfCols);
                    cellCoord = (rowGuess, coloumGuss);
                    alreadyMatched = i_board.AlreadyMatched(rowGuess, coloumGuss);
                }
                while (alreadyMatched);

                return cellCoord;
            }
        }
    }
}



    

