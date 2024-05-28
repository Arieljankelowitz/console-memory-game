using System.Linq.Expressions;

namespace Ex_02
{
    public class Program
    {
        static void Main()
        {
            //PlayGame game = new PlayGame();
            //game.Start();
            
            //System.Console.Read();
            Board b = new Board(6, 6);
            b.PrintBoard();
        }
    }
}
