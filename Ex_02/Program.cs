namespace Ex_02
{
    public class Program
    {
        static void Main()
        {
            PlayGame();
            
        }

        //move this function to a new class
        public static void PlayGame()
        {
            MatchingGame matchingGame = new MatchingGame();

            matchingGame.Play();

            matchingGame.End();
        }
    }
}
