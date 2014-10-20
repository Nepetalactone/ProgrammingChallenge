using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _00NameGenerator
{
    class Program
    {
        private static readonly char[] Vowels = new char[5] { 'a', 'e', 'i', 'o', 'u' };
        private static readonly string[] Diphtongs = new string[5] { "ai", "au", "eu", "ei", "ui" };
        private static readonly char[] Consonants = new char[21] { 'b', 'c', 'd', 'f', 'g', 'h', 'j', 'k', 'l', 'm', 'n', 'p', 'q', 'r', 's', 't', 'v', 'w', 'x', 'y', 'z' };
        private static readonly Random Rng = new Random();

        private static void Main(string[] args)
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GenerateName() + Environment.NewLine);
            }

            Console.ReadKey();
        }

        private static String GenerateName()
        {
            int numOfParts = Rng.Next(3, 10);
            int poolChoice = Rng.Next(0, 6);
            StringBuilder generatedName = new StringBuilder();

            //Appends an entry from the appropriate letter pool and afterwards changes the pool to choose from 
            for (int i = 0; i < numOfParts; i++)
            {
                int letterChoice;
                switch (poolChoice)
                {
                    case 0:
                        letterChoice = Rng.Next(0, 5);
                        generatedName.Append(Vowels[letterChoice]);
                        poolChoice = 2;
                        break;

                    case 1:
                        letterChoice = Rng.Next(0, 5);
                        generatedName.Append(Diphtongs[letterChoice]);
                        poolChoice = 2;
                        break;
                    //Give consonants a higher chance to appear
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        letterChoice = Rng.Next(0, 21);
                        generatedName.Append(Consonants[letterChoice]);
                        poolChoice = Rng.Next(0, 2);
                        break;
                }
            }

            generatedName[0] = Char.ToUpper(generatedName[0]);

            return generatedName.ToString();
        }
    }
}
