using System;
using System.Collections.Generic;
using System.Threading;
using _18MinesweeperConsole.Enums;
using _18MinesweeperConsole.Gamelogic;

namespace _18MinesweeperConsole.GameEnvironment
{
    class Map
    {
        private readonly int _amountMines = 8;
        private int _markedMines = 0;

        public Field[,] Gamemap
        {
            get { return _gamemap; }
        }
        private readonly Field[,] _gamemap;
        private Boolean _isInitialized;
        private int _markCounter;
        private readonly Difficulty _difficulty;

        public Map(Difficulty difficulty)
        {
            _difficulty = difficulty;
            _gamemap = new Field[_difficulty.Width, _difficulty.Height];
            _amountMines = _difficulty.Mines;
            _markCounter = _amountMines;
            _isInitialized = false;
        }

        public GameState UncoverField(Tuple<int, int> coordinate)
        {
            if (!_isInitialized)
            {
                InitializeMap(coordinate);
                _isInitialized = true;
            }

            if (_gamemap[coordinate.Item1, coordinate.Item2].HasMine)
            {
                return GameState.Loss;
            }
            else
            {
                if (_gamemap[coordinate.Item1, coordinate.Item2].State == Fieldstate.Marked)
                {
                    ToggleMark(new Tuple<int, int>(coordinate.Item1, coordinate.Item2));
                }
                _gamemap[coordinate.Item1, coordinate.Item2].State = Fieldstate.Uncovered;
                if (_gamemap[coordinate.Item1, coordinate.Item2].SurroundingMineCount == 0)
                {
                    UncoverEmptyNeighbours(coordinate);
                }
                return GameState.Undecided;
            }
        }

        public GameState ToggleMark(Tuple<int, int> coordinate)
        {
            if (_gamemap[coordinate.Item1, coordinate.Item2].State == Fieldstate.Marked)
            {
                _gamemap[coordinate.Item1, coordinate.Item2].State = Fieldstate.Covered;
                _markCounter++;
                if (_gamemap[coordinate.Item1, coordinate.Item2].HasMine)
                {
                    _markedMines--;
                }
                return GameState.Undecided;
            }
            else if (_gamemap[coordinate.Item1, coordinate.Item2].State == Fieldstate.Covered)
            {
                if (_markCounter > 0)
                {
                    _gamemap[coordinate.Item1, coordinate.Item2].State = Fieldstate.Marked;
                    if (_gamemap[coordinate.Item1, coordinate.Item2].HasMine)
                    {
                        _markedMines++;
                    }
                    if (AllMinesMarked())
                    {
                        return GameState.Win;
                    }
                }
            }
            return GameState.Undecided;
        }

        private void InitializeMap(Tuple<int, int> coordinate)
        {
            for (int x = 0; x < _difficulty.Width; x++)
            {
                for (int y = 0; y < _difficulty.Height; y++)
                {
                    _gamemap[x, y] = new Field();
                }
            }

            foreach (var mineField in GenerateMines(coordinate))
            {
                _gamemap[mineField.Item1, mineField.Item2].HasMine = true;
                foreach (var mineNeighbour in GetNeighbours(mineField))
                {
                    _gamemap[mineNeighbour.Item1, mineNeighbour.Item2].SurroundingMineCount++;
                }
            }
        }

        private IEnumerable<Tuple<int, int>> GenerateMines(Tuple<int, int> coordinate)
        {
            Random rng = new Random();
            var mines = new List<Tuple<int, int>>();
            int i = 0;

            while (i <= _amountMines)
            {
                int x = rng.Next(_difficulty.Width);
                Thread.Sleep(10);
                int y = rng.Next(_difficulty.Height);
                var potentialMine = new Tuple<int, int>(x, y);

                if (!AreNeighbours(coordinate, potentialMine) && (!coordinate.Equals(potentialMine)))
                {
                    mines.Add(potentialMine);
                    i++;
                }
            }
            return mines;
        }

        private Boolean AreNeighbours(Tuple<int, int> first, Tuple<int, int> second)
        {
            return IsInNeighbourRange(first.Item1, second.Item1) && (IsInNeighbourRange(first.Item2, second.Item2)) &&
                   (!first.Equals(second));
        }

        private static Boolean IsInNeighbourRange(int first, int second)
        {
            return (((first - second) <= 1) && ((first - second) >= -1));
        }

        private IEnumerable<Tuple<int, int>> GetNeighbours(Tuple<int, int> coordinate) //Lazy
        {
            var neighbours = new List<Tuple<int, int>>();

            for (int x = 0; x < _difficulty.Width; x++)
            {
                for (int y = 0; y < _difficulty.Height; y++)
                {
                    var potentialNeighbour = new Tuple<int, int>(x, y);
                    if (AreNeighbours(coordinate, potentialNeighbour))
                    {
                        neighbours.Add(potentialNeighbour);
                    }
                }
            }
            return neighbours;
        }

        private void UncoverEmptyNeighbours(Tuple<int, int> coordinate)
        {
            foreach (Tuple<int, int> potentialEmptyNeighbour in GetNeighbours(coordinate))
            {
                if ((_gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].SurroundingMineCount == 0) && 
                    (_gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].HasMine == false) && 
                    (_gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].State == Fieldstate.Covered))
                {
                    _gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].State = Fieldstate.Uncovered;
                    UncoverEmptyNeighbours(potentialEmptyNeighbour);
                }
                else if ((_gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].HasMine == false) && (_gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].State == Fieldstate.Covered))
                {
                    _gamemap[potentialEmptyNeighbour.Item1, potentialEmptyNeighbour.Item2].State = Fieldstate.Uncovered;
                }
            }
        }

        private Boolean AllMinesMarked()
        {
            return _amountMines == _markedMines;
        }
    }
}
