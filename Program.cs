using System;

namespace TicTacToe
{
    internal class Program
    {

        private static char[] cells = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        private static int turns = 0;

        public static void Main(string[] args)
        {

            bool isQuit = false;
            while (!isQuit)
            {
                Console.Clear();
                DrawBoard();
                bool isInputValid = false;
                string input = null;
                int result = CheckResult();
                if (result != -1)
                {
                    if (result == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Game draw !");
                        Console.ResetColor();
                    }
                    else if (result == 1)
                    {
                        string winner = turns % 2 == 0 ? "B" : "A";
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine($"Player {winner} won the game !");
                        Console.ResetColor();
                                             
                    }
                    isInputValid = false;
                    while (!isInputValid)
                    {
                        Console.Write("Do you want to continue a new game? (Y/n): ");
                        input = Console.ReadLine();
                        switch (input.ToUpper())
                        {
                            case "Y":
                                isInputValid = true;
                                restartGame();
                                break;
                            case "N":
                                isInputValid = true;
                                isQuit = true;
                                break;
                            default:
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("Invalid choice");
                                Console.ResetColor();
                                break;
                        }
                    }
                    continue;
                }
                
                Console.WriteLine(@"Player A uses ""x"", player B uses ""o""");
                isInputValid = false;
                turns++;
                while (!isInputValid)
                {
                    if (turns % 2 == 0)
                    {
                        Console.Write("Player B's turn: ");
                    }
                    else
                    {
                        Console.Write("Player A's turn: ");
                    }
                    input = Console.ReadLine();
                    if (int.TryParse(input, out int cell) && cell <= 9)
                    {
                        cells[cell - 1] = turns % 2 == 0 ? 'o' : 'x';
                        isInputValid = true;
                        

                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid cell");
                        Console.ResetColor();
                    }
                }
            }


        }

        private static void DrawBoard()
        {
            Console.WriteLine();
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", cells[0], cells[1], cells[2]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", cells[3], cells[4], cells[5]);
            Console.WriteLine("_____|_____|_____");
            Console.WriteLine("     |     |     ");
            Console.WriteLine("  {0}  |  {1}  |  {2}   ", cells[6], cells[7], cells[8]);
            Console.WriteLine("     |     |     ");
            Console.WriteLine();
        }

        private static int CheckResult()
        {
            if ((cells[0] == cells[1] && cells[1] == cells[2]) ||
                (cells[3] == cells[4] && cells[4] == cells[5]) ||
                (cells[6] == cells[7] && cells[7] == cells[8]) ||
                (cells[0] == cells[3] && cells[3] == cells[6]) ||
                (cells[1] == cells[4] && cells[4] == cells[7]) ||
                (cells[2] == cells[5] && cells[5] == cells[8]) ||
                (cells[0] == cells[4] && cells[4] == cells[8]) ||
                (cells[2] == cells[4] && cells[4] == cells[6]))
            {
                return 1;
            }
            if (turns >= 9)
            {
                return 0;
            }
            return -1;
        }

        private static void restartGame()
        {
            turns = 0;
            cells = new char[] { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        }
    }
}