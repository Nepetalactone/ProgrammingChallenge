using System;
using _19ConnectFour.Enums;


namespace _19ConnectFour.UserInterface
{
    class ConsoleInterface : IUserInterface
    {
        private const int MaxGridRows = 6;
        private const int MaxGridColumns = 7;

        public void Draw(SpaceState[,] state)
        {
            int i = 0;
            int j = MaxGridRows - 1;

            Console.Clear();
            while (j >= 0)
            {
                if (state[i, j] == SpaceState.Red)
                {
                    Console.Write("O|");
                }
                else if (state[i, j] == SpaceState.Yellow)
                {
                    Console.Write("X|");
                }
                else
                {
                    Console.Write(" |");
                }

                if (i == MaxGridColumns - 1)
                {
                    j--;
                    i = 0;
                    Console.Write(Environment.NewLine);
                }
                else
                {
                    i++;
                }
            }
        }

        public int GetUserInput()
        {
            Console.WriteLine("Enter a column number to add a disc");

            int x;
            String input = Console.ReadLine();

            while (!Int32.TryParse(input, out x) || (x < 0) || (x > MaxGridColumns - 1))
            {
                Console.WriteLine("Enter a VALID column number to add a disc");
                input = Console.ReadLine();
            }

            return x;
        }

        public void Tie()
        {
            Console.WriteLine("Tie");
        }

        public void Win(String player)
        {
            Console.WriteLine(player + " won");
        }
    }
}
