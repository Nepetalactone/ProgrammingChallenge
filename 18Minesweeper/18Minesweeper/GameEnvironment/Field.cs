using System;
using _18Minesweeper.Enums;

namespace _18Minesweeper.GameEnvironment
{
    class Field
    {
        public int surroundingMineCount { get; set; }
        public Boolean hasMine { get; set; }
        public Fieldstate state { get; set; }

        public Field()
        {
            hasMine = false;
            state = Fieldstate.COVERED;
        }
    }
}
