using _18MinesweeperConsole.Enums;
using _18MinesweeperConsole.GameEnvironment;

namespace _18MinesweeperConsole.Userinterface
{
    interface Userinterface
    {
        Command getUserInput(ref int x, ref int y);
        void draw(Field[,] matrix);
        void showResult(GameState state);
    }
}
