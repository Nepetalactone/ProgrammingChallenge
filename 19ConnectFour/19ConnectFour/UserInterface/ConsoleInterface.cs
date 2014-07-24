using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19ConnectFour.Enums;


namespace _19ConnectFour.UserInterface
{
    class ConsoleInterface : UserInterface
    {
        private static readonly int MAX_GRID_ROWS = 6;
        private static readonly int MAX_GRID_COLUMNS = 7;

        public void draw(SpaceState[,] state)
        {
            int i = 0;
            int j = MAX_GRID_ROWS - 1;

            while (j >= 0)
            {
                if (state[i, j] == SpaceState.RED)
                {
                    Console.Write("O|");
                }
                else if (state[i, j] == SpaceState.YELLOW)
                {
                    Console.Write("X|");
                }
                else
                {
                    Console.Write(" |");
                }

                if (i == MAX_GRID_COLUMNS - 1)
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

        public int getUserInput()
        {
            Console.WriteLine("Enter a column number to add a disc");

            int x = 0;
            String input = Console.ReadLine();

            while (!Int32.TryParse(input, out x) || (x < 0) || (x > MAX_GRID_COLUMNS - 1))
            {
                Console.WriteLine("Enter a VALID column number to add a disc");
                input = Console.ReadLine();
            }

            return x;
        }
    }
}
