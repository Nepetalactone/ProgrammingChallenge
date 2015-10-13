using System;

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
                if (IsEven(startingNumber))
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

        private static bool IsEven(int numberToCheck)
        {
            return numberToCheck % 2 == 0;
        }
    }
}
