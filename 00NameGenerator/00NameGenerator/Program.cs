using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00NameGenerator
{
    class Program
    {
        private static char[] vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
        private static string[] diphtongs = new string[5] { "ai", "au", "eu", "ei", "ui" };
        private static char[] consonants = new char[21] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
        private static Random rng = new Random();

        static void Main(string[] args)
        {
            int numOfParts = rng.Next(3, 10);
            int poolChoice = rng.Next(0, 3);
            StringBuilder generatedName = new StringBuilder();

            //Appends an entry from the appropriate letter pool and afterwards changes the pool to choose from 
            for (int i = 0; i < numOfParts; i++)
            {
                int letterChoice;
                switch (poolChoice) 
                {
                    case 0:
                        letterChoice = rng.Next(0, 5);
                        generatedName.Append(vowels[letterChoice]);
                        poolChoice = 2;
                        break;

                    case 1:
                        letterChoice = rng.Next(0, 5);
                        generatedName.Append(diphtongs[letterChoice]);
                        poolChoice = 2;
                        break;

                    case 2:
                        letterChoice = rng.Next(0, 21);
                        generatedName.Append(consonants[letterChoice]);
                        poolChoice = rng.Next(0, 2);
                        break;
                }
            }

            Console.WriteLine(generatedName);
            Console.ReadKey();
        }
    }
}
