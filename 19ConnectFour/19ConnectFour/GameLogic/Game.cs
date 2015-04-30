using System;
using _19ConnectFour.GameEnvironment;
using _19ConnectFour.UserInterface;
using _19ConnectFour.Enums;

namespace _19ConnectFour.GameLogic
{
    class Game
    {
        private const SpaceState PlayerOne = SpaceState.Red;
        private const SpaceState PlayerTwo = SpaceState.Yellow;

        private readonly GameGrid _gameGrid;
        private readonly UserInterface.IUserInterface _gui;
        private SpaceState _currentPlayer;

        public Game()
        {
            _gameGrid = new GameGrid();
            _gui = new ConsoleInterface();
            _currentPlayer = PlayerOne;
        }

        public void GameLoop()
        {
            int input = _gui.GetUserInput();

            while ((!_gameGrid.IsFull()) && (_gameGrid.AddDiscToGridAndCheckForWin(input, _currentPlayer) == false))
            {
                _gui.Draw(_gameGrid.Grid);
                _currentPlayer = (_currentPlayer == PlayerOne) ? PlayerTwo : PlayerOne;
                input = _gui.GetUserInput();
            }

            if (_gameGrid.IsFull())
            {
                Console.WriteLine("Tie");
            }
            else
            {
                if (_currentPlayer == PlayerOne)
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
