using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22SudokuGeneratorSolver
{
    class SudokuField
    {
        public short number { get; set; }
        private bool[] possibleNumbers;
        private bool set;

        public SudokuField()
        {
            number = 0;
            possibleNumbers = new bool[9] { false, false, false, false, false, false, false, false, false };
            set = false;
        }

        public void removeNotPossibleNumber(int notPossibleNumber)
        {
            possibleNumbers[notPossibleNumber - 1] = true;
            var asdf = (from x in possibleNumbers
                        where x = false
                        select x).ToArray();

            if (asdf.Length == 1)
            {
                number = (short)Array.FindIndex(possibleNumbers, x => x == true);
            }
        }

        public void addPossibleNumber(int possibleNumber)
        {
            possibleNumbers[possibleNumber - 1] = false;
            if (set == true)
            {
                set = false;
            }
        }

        public bool isOnlyOneNumberPossible()
        {
            var asdf = (from x in possibleNumbers
                        where x = false
                        select x).ToArray();

            if (asdf.Length == 1)
            {
                return true;
            }
            return false;
        }

        public bool isNumberPossible(int number)
        {
            if (possibleNumbers[number - 1] == true)
            {
                return true;
            }

            return false;
        }
    }
}
