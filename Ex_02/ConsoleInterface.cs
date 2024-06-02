using System;
using System.Globalization;
using System.IO;

namespace Ex_02
{
    internal class ConsoleInterface
    {
        internal static string GetPlayerName()
        {
            Console.WriteLine("Please enter your name: ");
            string playerName = Console.ReadLine();

            if (!InputValidation.ValidPlayerName(playerName))
            {
                Console.WriteLine("Invalid name please try again.");
                playerName = GetPlayerName();
            }

            return playerName;
        }

        internal static bool ChoosePlayer2() 
        {
            
            int startX = 15;
            int startY = Console.CursorTop + 2;
            int optionsPerLine = 2;
            int spacingPerLine = 14;

            string[] player2Options = new string[2] { "computer", "player 2" };

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            Console.WriteLine("Choose your opponent: (Use arrow keys to move, press 'Enter' to select)");

            do
            {
                for (int i = 0; i < player2Options.Length; i++)
                {
                    Console.SetCursorPosition(startX + (i % optionsPerLine) * spacingPerLine, startY + i / optionsPerLine);

                    if (i == currentSelection)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                    }
                        

                    Console.WriteLine(player2Options[i]);
                    Console.WriteLine();

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % optionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % optionsPerLine < optionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            Console.CursorVisible = true;

            bool choosePlayerTwo = currentSelection == 0 ? false : true;

            return choosePlayerTwo;

        }

        public static (int, int) ChooseBoard()
        {
            const int k_StartX = 15;
            int startY = Console.CursorTop + 2;
            const int k_OptionsPerLine = 4;
            const int k_SpacingPerLine = 8;

            string[] boardOptions = new string[9] { "4x4", "4x5", "4x6", "5x4", "5x6", "6x4", "6x5", "6x6", "2x2" };

            int currentSelection = 0;

            ConsoleKey key;

            Console.CursorVisible = false;

            Console.WriteLine("Choose your board size: (Use arrow keys to move, press 'Enter' to select)");

            do
            { 
                for (int i = 0; i < boardOptions.Length; i++)
                {
                    Console.SetCursorPosition(k_StartX + (i % k_OptionsPerLine) * k_SpacingPerLine, startY + i / k_OptionsPerLine);

                    if (i == currentSelection)
                        Console.ForegroundColor = ConsoleColor.Blue;

                    Console.WriteLine(boardOptions[i]);

                    Console.ResetColor();
                }

                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.LeftArrow:
                        {
                            if (currentSelection % k_OptionsPerLine > 0)
                                currentSelection--;
                            break;
                        }
                    case ConsoleKey.RightArrow:
                        {
                            if (currentSelection % k_OptionsPerLine < k_OptionsPerLine - 1)
                                currentSelection++;
                            break;
                        }
                    case ConsoleKey.UpArrow:
                        {
                            if (currentSelection >= k_OptionsPerLine)
                                currentSelection -= k_OptionsPerLine;
                            break;
                        }
                    case ConsoleKey.DownArrow:
                        {
                            if (currentSelection + k_OptionsPerLine < boardOptions.Length)
                                currentSelection += k_OptionsPerLine;
                            break;
                        }
                }
            } while (key != ConsoleKey.Enter);

            (int, int) board;

            switch (currentSelection)
            {
                case 0:
                    {
                        board = (4, 4); 
                        break;
                    }
                case 1:
                    {
                        board = (4, 5);
                        break;
                    }
                case 2:
                    {
                        board = (4, 6);
                        break;
                    }
                case 3:
                    {
                        board = (5, 4);
                        break;
                    }
                case 4:
                    {
                        board = (5, 6);
                        break;
                    }
                case 5:
                    {
                        board = (6, 4);
                        break;
                    }
                case 6:
                    {
                        board = (6, 5);
                        break;
                    }
                case 7:
                    {
                        board = (6, 6);
                        break;
                    }
                default:
                    {
                        board = (2, 2);
                        break;
                    }
            }

            Console.CursorVisible = true;

            return board;
        }

        internal static void GameOver(Player i_GameWinner)
        {
            Ex02.ConsoleUtils.Screen.Clear();

            if (i_GameWinner != null)
            {
                Console.WriteLine("{0} Won with {1} matches", i_GameWinner.Name, i_GameWinner.Score);
                
            } else
            {
                Console.WriteLine("TIE GAME!");
            }
        }

        internal static string NewGuess(Player i_Player, Board i_Board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            i_Board.PrintBoard();
            Console.WriteLine("{0}'s turn: Score {1}", i_Player.Name, i_Player.Score);
            Console.WriteLine("Choose a card: (ex: 'A2')");
            string chosenCard = Console.ReadLine();

            if (!InputValidation.ValidCard(chosenCard, i_Board))
            {
                chosenCard = GuessAgain(i_Player, i_Board);
            }

            return chosenCard;
        }

        internal static string GuessAgain(Player i_Player, Board i_Board)
        {
            Console.WriteLine("Invalid input. Please try again");
            Console.WriteLine("Choose a card: (ex: 'A2')");
            string chosenCard = Console.ReadLine();

            if (!InputValidation.ValidCard(chosenCard, i_Board))
            {

                chosenCard = GuessAgain(i_Player, i_Board);
            }

            return chosenCard;

        }

        internal static void ShowBoard(Board i_board)
        {
            Ex02.ConsoleUtils.Screen.Clear();
            i_board.PrintBoard();
        }
    }

}
