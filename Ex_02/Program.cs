using System.Linq.Expressions;

namespace Ex_02
{
    public class Program
    {
        static void Main()
        {
            playGame();
            
        }

        internal static void playGame()
        {
            MatchingGame matchingGame = new MatchingGame();

            matchingGame.Play();

            matchingGame.End();
        }
    }
}
