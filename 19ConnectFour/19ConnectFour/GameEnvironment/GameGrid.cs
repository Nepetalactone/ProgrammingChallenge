using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19ConnectFour.Enums;

namespace _19ConnectFour.GameEnvironment
{
    class GameGrid
    {
        private static readonly int MAX_GRID_ROWS = 6;
        private static readonly int MAX_GRID_COLUMNS = 7;

        private SpaceState[,] grid;

        internal SpaceState[,] Grid
        {
            get { return grid; }
        }

        public GameGrid()
        {
            this.grid = new SpaceState[MAX_GRID_COLUMNS, MAX_GRID_ROWS];
            initializeGrid();
        }

        private void initializeGrid()
        {
            int i = 0;
            int j = 0;

            while (j < MAX_GRID_COLUMNS)
            {
                grid[j, i] = SpaceState.UNOCCUPIED;

                if (i == MAX_GRID_ROWS - 1)
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

        public Boolean addDiscToGridAndCheckForWin(int columnNumber, SpaceState color)
        {
            int topDisc = findTopDiscOfColumn(columnNumber);
            grid[columnNumber, topDisc] = color;
            return hasCurrentMoveWon(columnNumber, topDisc);
        }

        private int findTopDiscOfColumn(int columnNumber)
        {
            int i = 0;

            while ((i < MAX_GRID_ROWS) && (grid[columnNumber, i] != SpaceState.UNOCCUPIED))
            {
                i++;
            }

            return i;
        }

        private Boolean hasCurrentMoveWon(int columnNumber, int rowNumber)
        {
            Tuple<int, int> asdf = new Tuple<int, int>(columnNumber, rowNumber);

            if ((amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.UP) + (amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.DOWN)) >= 3))
            {
                return true;
            }
            else if ((amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.LEFT) + (amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.RIGHT)) >= 3))
            {
                return true;
            }
            else if ((amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.LEFT_UP) + (amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.RIGHT_DOWN)) >= 3))
            {
                return true;
            }
            else if ((amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.LEFT_DOWN) + (amountOfDiscsInDirection(new Tuple<int, int>(columnNumber, rowNumber), Direction.RIGHT_UP)) >= 3))
            {
                return true;
            }

            return false;
        }

        private int amountOfDiscsInDirection(Tuple<int, int> startingPoint, Direction dir)
        {

            SpaceState startingState = grid[startingPoint.Item1, startingPoint.Item2];
            int i = 0;

            switch (dir)
            {
                case Direction.UP:
                    while ((startingPoint.Item2 + i < MAX_GRID_ROWS ) && (grid[startingPoint.Item1, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.DOWN:
                    while ((startingPoint.Item2 - i >= 0) && (grid[startingPoint.Item1, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.LEFT:
                    while ((startingPoint.Item1 - i >= 0) && (grid[startingPoint.Item1 - i, startingPoint.Item2] == startingState))
                    {
                        i++;
                    }
                    break;
                    
                case Direction.RIGHT:
                    while ((startingPoint.Item1 + i < MAX_GRID_COLUMNS ) && (grid[startingPoint.Item1 + i, startingPoint.Item2] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.LEFT_DOWN:
                    while ((startingPoint.Item1 - i >= 0) && (startingPoint.Item2 - i >= 0) && (grid[startingPoint.Item1 - i, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.LEFT_UP:
                    while ((startingPoint.Item1 - i >= 0) && (startingPoint.Item2 + i >= MAX_GRID_ROWS) && (grid[startingPoint.Item1 - i, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.RIGHT_DOWN:
                    while ((startingPoint.Item1 + i < MAX_GRID_COLUMNS) && (startingPoint.Item2 - i >= 0) && (grid[startingPoint.Item1 + i, startingPoint.Item2 - i] == startingState))
                    {
                        i++;
                    }
                    break;

                case Direction.RIGHT_UP:
                    while ((startingPoint.Item1 + i < MAX_GRID_COLUMNS) && (startingPoint.Item2 + i < MAX_GRID_ROWS) && (grid[startingPoint.Item1 + i, startingPoint.Item2 + i] == startingState))
                    {
                        i++;
                    }
                    break;
            }

            return i - 1;
        }

        public Boolean isFull()
        {
            foreach (SpaceState s in grid)
            {
                if (s == SpaceState.UNOCCUPIED)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
