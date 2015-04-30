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
            _gui.Draw(_gameGrid.Grid);
            int input = _gui.GetUserInput();

            while ((!_gameGrid.IsFull()) && (_gameGrid.AddDiscToGridAndCheckForWin(input, _currentPlayer) == false))
            {
                _gui.Draw(_gameGrid.Grid);
                _currentPlayer = (_currentPlayer == PlayerOne) ? PlayerTwo : PlayerOne;
                input = _gui.GetUserInput();
            }

            if (_gameGrid.IsFull())
            {
                _gui.Draw(_gameGrid.Grid);
                _gui.Tie();
            }
            else
            {
                if (_currentPlayer == PlayerOne)
                {
                    _gui.Draw(_gameGrid.Grid);
                    _gui.Win("Player 1");
                }
                else
                {
                    _gui.Draw(_gameGrid.Grid);
                    _gui.Win("Player 2);");
                }
            }
            Console.ReadKey();
        }
    }
}
