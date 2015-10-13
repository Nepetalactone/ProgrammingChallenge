using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22SudokuGeneratorSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            PlayingField field = new PlayingField();
            //scan starting field
            field.setNumberOfField(0, 1, 3);
            field.setNumberOfField(0, 2, 6);
            field.setNumberOfField(0, 0, 5);
            field.setNumberOfField(0, 6, 7);
            field.setNumberOfField(0, 7, 8);
            field.setNumberOfField(1, 0, 5);
            field.setNumberOfField(1, 1, 2);
            field.setNumberOfField(1, 7, 4);
            field.setNumberOfField(2, 0, 7);
            field.setNumberOfField(2, 2, 4);
            field.setNumberOfField(2, 6, 9);
            field.setNumberOfField(2, 8, 5);
            field.setNumberOfField(3, 0, 3);
            field.setNumberOfField(3, 3, 4);
            field.setNumberOfField(3, 5, 9);
            field.setNumberOfField(3, 8, 8);
            field.setNumberOfField(4, 4, 6);
            field.setNumberOfField(5, 0, 8);
            field.setNumberOfField(5, 3, 2);
            field.setNumberOfField(5, 5, 7);
            field.setNumberOfField(5, 8, 3);
            field.setNumberOfField(6, 0, 2);
            field.setNumberOfField(6, 2, 3);
            field.setNumberOfField(6, 6, 5);
            field.setNumberOfField(6, 8, 7);
            field.setNumberOfField(7, 0, 6);
            field.setNumberOfField(7, 1, 8);
            field.setNumberOfField(7, 7, 2);
            field.setNumberOfField(7, 8, 1);
            field.setNumberOfField(8, 1, 7);
            field.setNumberOfField(8, 2, 5);
            field.setNumberOfField(8, 6, 8);
            field.setNumberOfField(8, 7, 4);

            field.solve();
            //for each found number remove number from all vertical, horizontal and subfield fields
            //if a field only has one possible number, set that number and remove the number from all vertical, horizontal and subfield fields
        }
    }
}
