namespace _18MinesweeperConsole.Gamelogic
{
    abstract class Difficulty
    {
        public readonly int Width;
        public readonly int Height;
        public readonly int Mines;

        protected Difficulty(int width, int height, int mines)
        {
            Width = width;
            Height = height;
            Mines = mines;
        }
    }
}
