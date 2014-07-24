using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _19ConnectFour.Enums;

namespace _19ConnectFour.UserInterface
{
    interface UserInterface
    {
        int getUserInput();
        void draw(SpaceState[,] state);
    }
}
