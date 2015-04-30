using System;
using _19ConnectFour.Enums;

namespace _19ConnectFour.GameEnvironment
{
    class GameGrid
    {
        private const int MaxGridRows = 6;
        private const int MaxGridColumns = 7;

        private readonly SpaceState[,] _grid;

        internal SpaceState[,] Grid
        {
            get { return _grid; }
        }

        public GameGrid()
        {
            _grid = new SpaceState[MaxGridColumns, MaxGridRows];
            InitializeGrid();
        }

        private void InitializeGrid()
        {
            int i = 0;
            int j = 0;

            while (j < MaxGridColumns)
            {
                _grid[j, i] = SpaceState.Unoccupied;

                if (i == MaxGridRows - 1)
                {
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }
        }

        public Boolean AddDiscToGridAndCheckForWin(int columnNumber, SpaceState color)
        {
            int topDisc = FindTopDiscOfColumn(columnNumber);
            _grid[columnNumber, topDisc] = color;
            return HasCurrentMoveWon(columnNumber, topDisc);
        }

        private int FindTopDiscOfColumn(int columnNumber)
        {
            int i = 0;

            while ((i < MaxGridRows) && (_grid[columnNumber, i] != SpaceState.Unoccupied))
            {
                i++;
            }

            return i;
        }

        private Boolean HasCurrentMoveWon(int columnNumber, int rowNumber)
        {
            var position = new Tuple<int, int>(columnNumber, rowNumber);

            return ((AmountOfDiscsInDirection(position, Direction.Up) + (AmountOfDiscsInDirection(position, Direction.Down)) >= 3)) ||
                   ((AmountOfDiscsInDirection(position, Direction.Left) + (AmountOfDiscsInDirection(position, Direction.Right)) >= 3)) ||
                   ((AmountOfDiscsInDirection(position, Direction.LeftUp) + (AmountOfDiscsInDirection(position, Direction.RightDown)) >= 3)) ||
                   ((AmountOfDiscsInDirection(position, Direction.LeftDown) + (AmountOfDiscsInDirection(position, Direction.RightUp)) >= 3));
        }

        private int AmountOfDiscsInDirection(Tuple<int, int> startingPoint, Direction dir)
        {

            SpaceState startingState = _grid[startingPoint.Item1, startingPoint.Item2];
            int i = 0;

            switch (dir)
            {
                case Direction.Up:
                    while ((startingPoint.Item2 + i < MaxGridRows ) && (_grid[startingPoint.Item1, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.Down:
                    while ((startingPoint.Item2 - i >= 0) && (_grid[startingPoint.Item1, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.Left:
                    while ((startingPoint.Item1 - i >= 0) && (_grid[startingPoint.Item1 - i, startingPoint.Item2] == startingState))
                    {
                        i++;
                    }
                    break;
                    
                case Direction.Right:
                    while ((startingPoint.Item1 + i < MaxGridColumns ) && (_grid[startingPoint.Item1 + i, startingPoint.Item2] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.LeftDown:
                    while ((startingPoint.Item1 - i >= 0) && (startingPoint.Item2 - i >= 0) && (_grid[startingPoint.Item1 - i, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.LeftUp:
                    while ((startingPoint.Item1 - i >= 0) && (startingPoint.Item2 + i >= MaxGridRows) && (_grid[startingPoint.Item1 - i, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.RightDown:
                    while ((startingPoint.Item1 + i < MaxGridColumns) && (startingPoint.Item2 - i >= 0) && (_grid[startingPoint.Item1 + i, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.RightUp:
                    while ((startingPoint.Item1 + i < MaxGridColumns) && (startingPoint.Item2 + i < MaxGridRows) && (_grid[startingPoint.Item1 + i, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;
            }

            return i - 1;
        }

        public Boolean IsFull()
        {
            foreach (SpaceState s in _grid)
            {
                if (s == SpaceState.Unoccupied)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
