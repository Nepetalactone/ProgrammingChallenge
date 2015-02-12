using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22MazeGenerator
{
    class MazeGenerator
    {
        private Cell[,] _playingField;
        private Random rand;

        public MazeGenerator(int dimension)
        {
            rand = new Random();
            _playingField = new Cell[dimension, dimension];

            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    _playingField[i, j] = new Cell(i, j);
                }
            }
        }

        public void GenerateMaze()
        {
            Cell currentCell = _playingField[0, 0];
            currentCell.hasBeenVisited = true;

            bool nonVisitedFields = (from Cell field in _playingField
                                     where field.hasBeenVisited == false
                                     select field).Any();

            while(nonVisitedFields == true)
            {

                Cell[] neighbours = GetNeighbours(currentCell);

                var unvisitedNeighbours = (from neighbour in neighbours
                                          where neighbour.hasBeenVisited == false
                                          select neighbour).ToArray();

                if (unvisitedNeighbours.Length != 0)
                {
                    Cell chosenNeighbour = unvisitedNeighbours[rand.Next(unvisitedNeighbours.Length)];

                }
            }
        }

        private Cell[] GetNeighbours(Cell currentCell)
        {   
            List<Cell> neighbours = new List<Cell>();

            if (currentCell.XCoord - 1 >= 0)
            {
                neighbours.Add(_playingField[currentCell.XCoord-1, currentCell.YCoord]);
            }

            if (currentCell.XCoord + 1 < _playingField.GetLength(0))
            {
                neighbours.Add(_playingField[currentCell.XCoord+1, currentCell.YCoord]);
            }

            if (currentCell.YCoord - 1 >= 0)
            {
                neighbours.Add(_playingField[currentCell.XCoord, currentCell.YCoord-1]);
            }

            if (currentCell.YCoord + 1 < _playingField.GetLength(1))
            {
                neighbours.Add(_playingField[currentCell.XCoord, currentCell.YCoord + 1]);
            }

            return neighbours.ToArray();
        }
    }
}
