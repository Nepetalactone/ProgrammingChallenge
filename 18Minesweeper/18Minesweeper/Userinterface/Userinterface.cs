using _18Minesweeper.Enums;
using _18Minesweeper.GameEnvironment;

namespace _18Minesweeper.Userinterface
{
    interface Userinterface
    {
        Command getUserInput(ref int x, ref int y);
        void draw(Field[,] matrix);
        void showResult(GameState state);
    }
}
