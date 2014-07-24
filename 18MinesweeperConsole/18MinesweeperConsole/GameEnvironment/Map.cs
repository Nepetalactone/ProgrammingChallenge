using System;
using System.Collections.Generic;
using System.Threading;
using _18MinesweeperConsole.Enums;

namespace _18MinesweeperConsole.GameEnvironment
{
    class Map
    {

        private static readonly int AMOUNT_MINES = 8;

        public Field[,] Gamemap
        {
            get { return gamemap; }
        }
        private Field[,] gamemap;
        private Boolean isInitialized;
        private int markCounter;

        public Map()
        {
            gamemap = new Field[9, 9];
            markCounter = AMOUNT_MINES;
            isInitialized = false;
        }

        public GameState uncoverField(Tuple<int, int> coordinate)
        {
            if (!isInitialized)
            {
                initializeMap(coordinate);
                isInitialized = true;
            }

            if (gamemap[coordinate.Item1, coordinate.Item2].hasMine)
            {
                return GameState.LOSS;
            }
            else
            {
                if (gamemap[coordinate.Item1, coordinate.Item2].state == Fieldstate.MARKED)
                {
                    toggleMark(new Tuple<int, int>(coordinate.Item1, coordinate.Item2));
                }
                gamemap[coordinate.Item1, coordinate.Item2].state = Fieldstate.UNCOVERED;
                if (gamemap[coordinate.Item1, coordinate.Item2].surroundingMineCount == 0)
                {
                    uncoverEmptyNeighbours(coordinate);
                }
                return GameState.UNDECIDED;
            }
        }

        public GameState toggleMark(Tuple<int, int> coordinate)
        {
            if (gamemap[coordinate.Item1, coordinate.Item2].state == Fieldstate.MARKED)
            {
                gamemap[coordinate.Item1, coordinate.Item2].state = Fieldstate.COVERED;
                markCounter++;
                return GameState.UNDECIDED;
            }
            else if (gamemap[coordinate.Item1, coordinate.Item2].state == Fieldstate.COVERED)
            {
                if (markCounter > 0)
                {
                    gamemap[coordinate.Item1, coordinate.Item2].state = Fieldstate.MARKED;
                    if (areAllMinesMarked())
                    {
                        return GameState.WIN;
                    }
                }
            }
            return GameState.UNDECIDED;
        }

        private void initializeMap(Tuple<int, int> coordinate)
        {
            int i = 0;
            int j = 0;

            while (j < 9)
            {
                gamemap[j, i] = new Field();

                if (i == 8)
                {
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            foreach (Tuple<int, int> mineField in generateMines(coordinate))
            {
                gamemap[mineField.Item1, mineField.Item2].hasMine = true;
                foreach (Tuple<int, int> mineNeighbour in getNeighbours(mineField))
                {
                    gamemap[mineNeighbour.Item1, mineNeighbour.Item2].surroundingMineCount++;
                }
            }
        }

        private List<Tuple<int, int>> generateMines(Tuple<int, int> coordinate)
        {
            Random rng = new Random();
            List<Tuple<int, int>> mines = new List<Tuple<int, int>>();
            int i = 0;

            while (i <= AMOUNT_MINES)
            {
                int x = rng.Next(9);
                Thread.Sleep(10);
                int y = rng.Next(9);
                Tuple<int, int> potentialMine = new Tuple<int, int>(x, y);

                if (!areNeighbours(coordinate, potentialMine) && (!coordinate.Equals(potentialMine)))
                {
                    mines.Add(potentialMine);
                    i++;
                }
            }
            return mines;
        }

        private Boolean areNeighbours(Tuple<int, int> first, Tuple<int, int> second)
        {
            if ((isInNeighbourRange(first.Item1, second.Item1) && (isInNeighbourRange(first.Item2, second.Item2)) && (!first.Equals(second))))
            {
                return true;
            }
            return false;
        }

        private Boolean isInNeighbourRange(int first, int second)
        {
            return (((first - second) <= 1) && ((first - second) >= -1));
        }

        private List<Tuple<int, int>> getNeighbours(Tuple<int, int> coordinate) //Lazy
        {
            List<Tuple<int, int>> neighbours = new List<Tuple<int, int>>();

            int i = 0;
            int j = 0;

            while (j < 9)
            {
                Tuple<int, int> potentialNeighbour = new Tuple<int, int>(i, j);
                if (areNeighbours(coordinate, potentialNeighbour))
                {
                    neighbours.Add(potentialNeighbour);
                }

                if (i == 8)
                {
                    j++;
                    i = 0;
                }
                else
                {
                    i++;
                }
            }

            return neighbours;
        }

        private void uncoverEmptyNeighbours(Tuple<int, int> coordinate)
        {
            foreach (Tuple<int, int> potentialEmptyNeighbour in getNeighbours(coordinate))
            {
                if ((gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].surroundingMineCount == 0) && (gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].hasMine == false) && (gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].state == Fieldstate.COVERED))
                {
                    gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].state = Fieldstate.UNCOVERED;
                    uncoverEmptyNeighbours(potentialEmptyNeighbour);
                }
                else if ((gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].hasMine == false) && (gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].state == Fieldstate.COVERED))
                {
                    gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].state = Fieldstate.UNCOVERED;
                }
            }
        }

        private Boolean areAllMinesMarked()
        {
            int i = 0;
            foreach (Field f in gamemap)
            {
                if ((f.hasMine == true) && (f.state == Fieldstate.MARKED))
                {
                    i++;
                }
            }

            if (i == 8)
            {
                return true;
            }
            return false;
        }
    }
}
