using System;
using _19ConnectFour.Enums;

namespace _19ConnectFour.UserInterface
{
    interface IUserInterface
    {
        int GetUserInput();
        void Draw(SpaceState[,] state);
        void Tie();
        void Win(String winner);
    }
}
