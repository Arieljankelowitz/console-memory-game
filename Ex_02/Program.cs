using System.Linq.Expressions;

namespace Ex_02
{
    public class Program
    {
        static void Main()
        {
            playGame();

            System.Console.Read();
            //Board b = new Board(6, 6);
            //b.PrintBoard();
        }

        private static void playGame()
        {
            MatchingGame matchingGame = new MatchingGame();

            matchingGame.Play();

            matchingGame.End();
        }
    }
}
