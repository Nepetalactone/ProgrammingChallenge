using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22MazeGenerator
{
    class Cell
    {

        public int XCoord { get; set; }
        public int YCoord { get; set; }

        public bool hasLeftWall { get; set; }
        public bool hasRightWall { get; set; }
        public bool hasTopWall { get; set; }
        public bool hasBottomWall { get; set; }

        public bool hasBeenVisited { get; set; }

        public Cell(int xCoord, int yCoord)
        {
            XCoord = xCoord;
            YCoord = yCoord;
            hasLeftWall = true;
            hasRightWall = true;
            hasTopWall = true;
            hasBottomWall = true;
            hasBeenVisited = false;
        }
    }
}
