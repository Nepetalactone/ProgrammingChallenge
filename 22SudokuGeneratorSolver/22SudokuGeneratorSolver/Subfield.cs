using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22SudokuGeneratorSolver
{
    enum Subfield
    {
        UPPER_RIGHT,
        UPPER_MIDDLE,
        UPPER_LEFT,
        MIDDLE_RIGHT,
        MIDDLE_MIDDLE,
        MIDDLE_LEFT,
        LOWER_RIGHT,
        LOWER_MIDDLE,
        LOWER_LEFT,
        ERROR   //Not nice, remove
    }
}
