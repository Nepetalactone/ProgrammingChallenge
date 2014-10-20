using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22SudokuGeneratorSolver
{
    class PlayingField
    {
        public SudokuField[,] playingField { get; set; }
        private Stack<Tuple<int, int>> FieldsWithOnlyOnePossibleNumber; 

        public PlayingField()
        {
            playingField = new SudokuField[9, 9];
            FieldsWithOnlyOnePossibleNumber = new Stack<Tuple<int, int>>();
            initialize();
        }

        public void solve()
        {
            while (FieldsWithOnlyOnePossibleNumber.Count != 0)
            {
                print();
                Tuple<int, int> temp = FieldsWithOnlyOnePossibleNumber.Pop();
                setNumberOfField(temp.Item1, temp.Item2, playingField[temp.Item1, temp.Item2].number);
            }
        }

        public void setNumberOfField(int xCoord, int yCoord, short num)
        {
            playingField[xCoord, yCoord].number = num;
            removeNumFromSubfield(xCoord, yCoord, num);
            removeNumFromHorizontalLine(xCoord, yCoord, num);
            removeNumFromVerticalLine(xCoord, yCoord, num);
            foreach (SudokuField f in playingField)
            {
                if (f.isOnlyOneNumberPossible() == true)
                {
                    if (!FieldsWithOnlyOnePossibleNumber.Contains(new Tuple<int, int>(xCoord, yCoord)))
                    {
                        FieldsWithOnlyOnePossibleNumber.Push(new Tuple<int, int>(xCoord, yCoord));
                    }
                }
            }
            Console.WriteLine("setNumber");
        }

        private void removeNumFromSubfield(int xCoord, int yCoord, short num)
        {
            int i = 0;
            int j = 0;
            switch (determineSubfield(xCoord, yCoord))
            {
                case Subfield.LOWER_LEFT:
                    i = 0;
                    j = 0;
                    break;
                case Subfield.LOWER_MIDDLE:
                    i = 3;
                    j = 0;
                    break;
                case Subfield.LOWER_RIGHT:
                    i = 6;
                    j = 0;
                    break;
                case Subfield.MIDDLE_LEFT:
                    i = 0;
                    j = 3;
                    break;
                case Subfield.MIDDLE_MIDDLE:
                    i = 3;
                    j = 3;
                    break;
                case Subfield.MIDDLE_RIGHT:
                    i = 6;
                    j = 3;
                    break;
                case Subfield.UPPER_LEFT:
                    i = 0;
                    j = 6;
                    break;
                case Subfield.UPPER_MIDDLE:
                    i = 3;
                    j = 6;
                    break;
                case Subfield.UPPER_RIGHT:
                    i = 6;
                    j = 6;
                    break;
            }

            for (int x = i; x < i + 3; x++)
            {
                for (int y = j; y < j + 3; y++)
                {
                    playingField[i, j].removeNotPossibleNumber(num);
                    checkAndAddFieldsWithOnlyOneNumber(i, j);
                }
            }
        }

        private void removeNumFromHorizontalLine(int xCoord, int yCoord, short num)
        {
            int j = yCoord;
            switch (determineSubfield(xCoord, yCoord))
            {
                case Subfield.LOWER_LEFT:
                case Subfield.MIDDLE_LEFT:
                case Subfield.UPPER_LEFT:
                    for (int i = 3; i < 9; i++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
                case Subfield.LOWER_MIDDLE:
                case Subfield.MIDDLE_MIDDLE:
                case Subfield.UPPER_MIDDLE:
                    for (int i = 0; i < 3; i++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    for (int i = 6; i < 9; i++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
                case Subfield.LOWER_RIGHT:
                case Subfield.MIDDLE_RIGHT:
                case Subfield.UPPER_RIGHT:
                    for (int i = 0; i < 6; i++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
            }
        }

        private void removeNumFromVerticalLine(int xCoord, int yCoord, short num)
        {
            int i = xCoord;
            switch (determineSubfield(xCoord, yCoord))
            {
                case Subfield.LOWER_LEFT:
                case Subfield.LOWER_MIDDLE:
                case Subfield.LOWER_RIGHT:
                    for (int j = 3; j < 9; j++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
                case Subfield.MIDDLE_LEFT:
                case Subfield.MIDDLE_MIDDLE:
                case Subfield.MIDDLE_RIGHT:
                    for (int j = 0; j < 3; j++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    for (int j = 6; j < 9; j++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
                case Subfield.UPPER_LEFT:
                case Subfield.UPPER_MIDDLE:
                case Subfield.UPPER_RIGHT:
                    for (int j = 0; j < 6; j++)
                    {
                        playingField[i, j].removeNotPossibleNumber(num);
                        checkAndAddFieldsWithOnlyOneNumber(i, j);
                    }
                    break;
            }
        }

        private Subfield determineSubfield(int xCoord, int yCoord)
        {
            switch (yCoord)
            {
                case 0:
                case 1:
                case 2:
                    switch (xCoord)
                    {
                        case 0:
                        case 1:
                        case 2:
                            return Subfield.LOWER_LEFT;
                        case 3:
                        case 4:
                        case 5:
                            return Subfield.LOWER_MIDDLE;
                        case 6:
                        case 7:
                        case 8:
                            return Subfield.LOWER_RIGHT;
                        default:
                            return Subfield.ERROR;
                    }
                case 3:
                case 4:
                case 5:
                    switch (xCoord)
                    {
                        case 0:
                        case 1:
                        case 2:
                            return Subfield.MIDDLE_LEFT;
                        case 3:
                        case 4:
                        case 5:
                            return Subfield.MIDDLE_MIDDLE;
                        case 6:
                        case 7:
                        case 8:
                            return Subfield.MIDDLE_RIGHT;
                        default:
                            return Subfield.ERROR;
                    }
                case 6:
                case 7:
                case 8:
                    switch (xCoord)
                    {
                        case 0:
                        case 1:
                        case 2:
                            return Subfield.UPPER_LEFT;
                        case 3:
                        case 4:
                        case 5:
                            return Subfield.UPPER_MIDDLE;
                        case 6:
                        case 7:
                        case 8:
                            return Subfield.UPPER_RIGHT;
                        default:
                            return Subfield.ERROR;
                    }

                default:
                    return Subfield.ERROR;
            }
        }

        private void checkAndAddFieldsWithOnlyOneNumber(int xCoord, int yCoord)
        {
            if (playingField[xCoord, yCoord].isOnlyOneNumberPossible() == true)
            {
                FieldsWithOnlyOnePossibleNumber.Push(new Tuple<int, int>(xCoord, yCoord));
            }
        }

        private bool isNumberOnlyPossibilityVertically(int xCoord, int yCoord, int number)
        {
            //vertically traverse through the playing field
            //if the current field owns the number or has the number as a possibility abort
            for (int i = 0; i < 9; i++)
            {
                if (i != yCoord)
                {
                    if ((playingField[xCoord, i].number == number) || (playingField[xCoord, i].isNumberPossible(number)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private bool isNumberOnlyPossibilityHorizontally(int xCoord, int yCoord, int number)
        {
            for (int i = 0; i < 9; i++)
            {
                if (i != xCoord)
                {
                    if ((playingField[i, yCoord].number == number) || (playingField[i, yCoord].isNumberPossible(number)))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void print()
        {
            for (int i = 8; i >= 0; i--)
            {
                for (int j = 0; j < 9; j++)
                {
                    if (playingField[j, i].number == 0)
                    {
                        Console.Write("x");
                    }
                    else
                    {
                        Console.Write(playingField[j, i].number);
                    }
                }
                Console.WriteLine(Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
        }

        private void initialize()
        {
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < 9; j++)
                {
                    playingField[i, j] = new SudokuField();
                }
            }
        }
    }
}
