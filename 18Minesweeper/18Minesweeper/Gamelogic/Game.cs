﻿using System;
using _18Minesweeper.Enums;
using _18Minesweeper.GameEnvironment;
using _18Minesweeper.Userinterface;

namespace _18Minesweeper.Gamelogic
{
    class Game
    {
        private Map map;
        private Userinterface.Userinterface userinterface;
        private GameState state;

        public Game()
        {
            map = new Map();
            userinterface = new ConsoleInterface();
            state = GameState.UNDECIDED;
        }

        public void gameLoop()
        {
            while (state == GameState.UNDECIDED)
            {
                int x = 0;
                int y = 0;

                switch (userinterface.getUserInput(ref x, ref y))
                {
                    case Command.MARK:
                        state = map.toggleMark(new Tuple<int, int>(x, y));
                        break;

                    case Command.UNCOVER:
                        state = map.uncoverField(new Tuple<int, int>(x, y));
                        break;

                    default:
                        break;
                }
                userinterface.draw(map.Gamemap);
            }

            userinterface.showResult(state);
        }
    }
}
