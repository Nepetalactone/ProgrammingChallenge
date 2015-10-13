using System;
using _18MinesweeperConsole.Enums;
using _18MinesweeperConsole.GameEnvironment;
using _18MinesweeperConsole.Userinterface;

namespace _18MinesweeperConsole.Gamelogic
{
    class Game
    {
        private Map _map;
        private readonly Userinterface.Userinterface _userinterface;
        private GameState _state;

        public Game()
        {
            _userinterface = new ConsoleInterface();
            _state = GameState.Undecided;
        }

        public void GameLoop()
        {
            switch (_userinterface.GetDifficulty())
            {
                case "hard":
                    _map = new Map(new DifficultyHard());
                    _userinterface.GameDifficulty = new DifficultyHard();
                    break;
                case "normal":
                    _map = new Map(new DifficultyNormal());
                    _userinterface.GameDifficulty = new DifficultyNormal();
                    break;
                case "easy":
                    _map = new Map(new DifficultyEasy());
                    _userinterface.GameDifficulty = new DifficultyEasy();
                    break;
            }
            while (_state == GameState.Undecided)
            {
                int x = 0;
                int y = 0;

                switch (_userinterface.GetUserInput(ref x, ref y))
                {
                    case Command.Mark:
                        _state = _map.ToggleMark(new Tuple<int, int>(x, y));
                        break;

                    case Command.Uncover:
                        _state = _map.UncoverField(new Tuple<int, int>(x, y));
                        break;
                }
                _userinterface.Draw(_map.Gamemap);
            }

            _userinterface.ShowResult(_state);
            Console.ReadLine();
        }
    }
}
