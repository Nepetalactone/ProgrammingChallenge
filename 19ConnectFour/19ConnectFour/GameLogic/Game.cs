using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19ConnectFour.GameEnvironment;
using _19ConnectFour.UserInterface;
using _19ConnectFour.Enums;

namespace _19ConnectFour.GameLogic
{
    class Game
    {
        private static readonly SpaceState PLAYER_1 = SpaceState.RED;
        private static readonly SpaceState PLAYER_2 = SpaceState.YELLOW;

        private GameGrid gameGrid;
        private UserInterface.UserInterface gui;
        private SpaceState currentPlayer;

        public Game()
        {
            this.gameGrid = new GameGrid();
            this.gui = new ConsoleInterface();
            currentPlayer = PLAYER_1;
        }

        public void gameLoop()
        {
            int input = gui.getUserInput();

            while ((!gameGrid.isFull()) && (gameGrid.addDiscToGridAndCheckForWin(input, currentPlayer) == false))
            {
                gui.draw(gameGrid.Grid);
                if (currentPlayer == PLAYER_1)
                {
                    currentPlayer = PLAYER_2;
                }
                else
                {
                    currentPlayer = PLAYER_1;
                }
                input = gui.getUserInput();
            }

            if (gameGrid.isFull())
            {
                Console.WriteLine("Tie");
            }
            else
            {
                if (currentPlayer == PLAYER_1)
                {
                    Console.WriteLine("Player 1 won");
                }
                else
                {
                    Console.WriteLine("Player 2 won");
                }
            }
            Console.ReadKey();
        }
    }
}
