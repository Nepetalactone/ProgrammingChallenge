using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18Minesweeper
{
    class Init
    {
        public static void main(String[] args)
        {
            Gamelogic.Game game = new Gamelogic.Game();
            game.gameLoop();
        }
    }
}
