namespace Ex_02
{
    public class Program
    {
        static void Main()
        {
            int rows = 6;
            int columns = 6;

            Board board = new Board(rows, columns);
            board.PrintBoard();

        }
    }
}
