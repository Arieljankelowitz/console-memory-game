
using System.Linq;

namespace Ex_02
{
    internal class Player
    {
        public string Name { get; }
        public int Score { get; set; }

        public bool IsPlaying { get; set; }

        public Player(string i_Name)
        {
            Name = i_Name;
        }

        
        internal (int, int) Guess(Board i_board)
        {
            string guess = ConsoleInterface.NewGuess(this, i_board);
            (int Row, int Col) cellCoord = Utils.getGuessCoord(guess);
            
            return cellCoord;
        }

        internal bool IsMatch(char i_FirstGuess, char i_SecondGuess)
        {
            bool isMatch = false;

            if(i_FirstGuess == i_SecondGuess)
            {
                Score++;
                isMatch = true;
            }

            return isMatch;
        }

       

    }
}
