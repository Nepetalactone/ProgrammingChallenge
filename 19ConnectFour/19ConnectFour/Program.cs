﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19ConnectFour.GameLogic;

namespace _19ConnectFour
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            game.gameLoop();
        }
    }
}
