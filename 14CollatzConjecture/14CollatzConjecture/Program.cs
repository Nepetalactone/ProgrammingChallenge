using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _14CollatzConjecture
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            int startingNumber = rng.Next();

            while (startingNumber != 1)
            {
                if (isEven(startingNumber))
                {
                    startingNumber /= 2;
                }
                else
                {
                    startingNumber *= 3;
                    startingNumber++;
                }
                Console.WriteLine(startingNumber);
            }
            Console.ReadKey();
        }

        private static bool isEven(int numberToCheck)
        {
            if ((numberToCheck % 2) == 0)
            {
                return true;
            }
            return false;
        }
    }
}
