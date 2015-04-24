using System;
using _18MinesweeperConsole.Enums;
using _18MinesweeperConsole.GameEnvironment;
using _18MinesweeperConsole.Gamelogic;

namespace _18MinesweeperConsole.Userinterface
{
    internal abstract class Userinterface
    {
        public abstract Command GetUserInput(ref int x, ref int y);
        public abstract void Draw(Field[,] matrix);
        public abstract void ShowResult(GameState state);
        public abstract String GetDifficulty();
        public Difficulty GameDifficulty { get; set; }
    }
}
