using System;
using _18MinesweeperConsole.Enums;

namespace _18MinesweeperConsole.Userinterface
{
    class ConsoleInterface : Userinterface
    {
        public override Command GetUserInput(ref int x, ref int y)
        {
            Console.WriteLine("Enter a command and two numbers for a coordinate");
            String[] input = RemoveExtraSpaces(Console.ReadLine()).Split(' ');
            while ((input.Length != 3) || (!IsCommandRecognized(input[0])) || (!Int32.TryParse(input[1], out x)) || (!Int32.TryParse(input[2], out y)))
            {
                Console.WriteLine("Enter a command and two numbers for a coordinate");
                input = RemoveExtraSpaces(Console.ReadLine()).Split(' ');
            }

            if (input[0] == "mark")
            {
                return Command.Mark;
            }

            return Command.Uncover;
        }

        private Boolean IsCommandRecognized(String command)
        {
            if ((command.ToLower() == "mark") || (command.ToLower() == "uncover"))
            {
                return true;
            }
            return false;
        }

        public override void Draw(GameEnvironment.Field[,] matrix)
        {
            Console.Clear();
            if (GameDifficulty.Width < 10)
            {
                Console.Write("   ");
            }
            else
            {
                Console.Write("    ");
            }
            for (int i = 0; i < GameDifficulty.Height; i++)
            {
                Console.Write(i + " ");
            }
            Console.Write(Environment.NewLine);
            for (int x = 0; x < GameDifficulty.Width; x++)
            {
                for (int y = 0; y < GameDifficulty.Height; y++)
                {
                    if (y == 0)
                    {
                        if (x < 10)
                        {
                            Console.Write("0" + x + "  ");
                        }
                        else
                        {
                            Console.Write(x + "  ");
                        }
                    }
                    if (matrix[x, y].State == Fieldstate.Covered)
                    {
                        Console.Write(" |");
                    }
                    else if (matrix[x, y].State == Fieldstate.Marked)
                    {
                        Console.Write("X|");
                    }
                    else
                    {
                        Console.Write(matrix[x, y].SurroundingMineCount + "|");
                    }
                }
                Console.Write(Environment.NewLine);
            }
        }


        public override void ShowResult(GameState state)
        {
            if (state == GameState.Loss)
            {
                Console.WriteLine("You lost");
            }
            else if (state == GameState.Win)
            {
                Console.WriteLine("You won");
            }
        }

        private String RemoveExtraSpaces(String input)
        {
            while (input.Contains("  "))
            {
                input = input.Replace("  ", " ");
            }
            return input;
        }

        public override string GetDifficulty()
        {
            String difficulty = "undefined";

            while (!difficulty.Equals("easy") && !difficulty.Equals("normal") && !difficulty.Equals("hard"))
            {
                Console.WriteLine("Choose a difficulty: easy, normal or hard");
                difficulty = Console.ReadLine();
                Console.Clear();
            }
            return difficulty;
        }
    }
}
