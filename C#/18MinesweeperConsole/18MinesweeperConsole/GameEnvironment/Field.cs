using System;
using _18MinesweeperConsole.Enums;

namespace _18MinesweeperConsole.GameEnvironment
{
    class Field
    {
        public int SurroundingMineCount { get; set; }
        public Boolean HasMine { get; set; }
        public Fieldstate State { get; set; }

        public Field()
        {
            HasMine = false;
            State = Fieldstate.Covered;
        }
    }
}
