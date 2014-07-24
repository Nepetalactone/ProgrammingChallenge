using System;
using System.Collections.Generic;
using System.Threading;
using _18Minesweeper.Enums;

namespace _18Minesweeper.GameEnvironment
{
    class Map
    {

        private static readonly int MARK_LIMIT = 10;

        public Field[,] Gamemap
        {
            get { return Gamemap; }
        }
        private Field[,] gamemap;
        private Boolean isInitialized;
        private int markCounter;

        public Map()
        {
            gamemap = new Field[9, 9];
            markCounter = MARK_LIMIT;
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
                gamemap[coordinate.Item1, coordinate.Item2].state = Fieldstate.UNCOVERED;
                uncoverEmptyNeighbours(coordinate);
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
            } else if (gamemap[coordinate.Item1, coordinate.Item2].state == Fieldstate.COVERED)
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

            while (i < 10)
            {
                int x = rng.Next(10);
                Thread.Sleep(1);
                int y = rng.Next(10);
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
            if ((isInNeighbourRange(first.Item1, second.Item1) && (isInNeighbourRange(first.Item2, second.Item2))))
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

            while (j < 10)
            {
                Tuple<int, int> potentialNeighbour = new Tuple<int, int>(i, j);
                if (areNeighbours(coordinate, potentialNeighbour))
                {
                    neighbours.Add(potentialNeighbour);
                }

                if (i == 9)
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

        private void win()
        {
        }

        private void loss()
        {
        }

        private void uncoverEmptyNeighbours(Tuple<int, int> coordinate)
        {
            foreach (Tuple<int, int> potentialEmptyNeighbour in getNeighbours(coordinate))
            {
                if ((gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].surroundingMineCount == 0) && (gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].hasMine == false))
                {
                    gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].state = Fieldstate.UNCOVERED;
                    uncoverEmptyNeighbours(potentialEmptyNeighbour);
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

            if (i == 10)
            {
                return true;
            }
            return false;
        }
    }
}
