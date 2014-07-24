using System;
using _18Minesweeper.Enums;

namespace _18Minesweeper.Userinterface
{
    class ConsoleInterface : Userinterface
    {
        public Command getUserInput(ref int x, ref int y)
        {
            Console.WriteLine("Enter a command and two numbers for a coordinate");
            String[] input = Console.ReadLine().Split(' ');
            while ((!isCommandRecognized(input[0])) && (!Int32.TryParse(input[1], out x)) && (!Int32.TryParse(input[2], out y)))
            {
                Console.WriteLine("Enter a command and two numbers for a coordinate");
                input = Console.ReadLine().Split(' ');
            }

            if (input[0] == "mark")
            {
                return Command.MARK;
            }

            return Command.UNCOVER;
        }

        private Boolean isCommandRecognized(String command)
        {
            if ((command == "mark") || (command == "uncover"))
            {
                return true;
            }
            return false;
        }

        public void draw(GameEnvironment.Field[,] matrix)
        {
            int i = 0;
            int j = 0;

            while (j < 10)
            {
                if (matrix[j, i].state == Fieldstate.COVERED)
                {
                    Console.Write(" |");
                }
                else if (matrix[j, i].state == Fieldstate.MARKED)
                {
                    Console.Write("X|");
                }
                else
                {
                    Console.Write(matrix[j, i].surroundingMineCount + "|");
                }

                if (i == 9)
                {
                    Console.WriteLine("------------------");
                    Console.WriteLine(Environment.NewLine);

                    j++;
                    i = 0;
                }
            }
        }


        public void showResult(GameState state)
        {
            if (state == GameState.LOSS)
            {
                Console.WriteLine("You lost");
            }
            else if (state == GameState.WIN)
            {
                Console.WriteLine("You won");
            }
        }
    }
}
