﻿using System;
using System.Text;

namespace _00NameGenerator
{
    class Program
    {

        private static ProbabilityList<char> _vowels;
        private static ProbabilityList<string> _diphthongs;
        private static ProbabilityList<char> _consonants;
        private static Random _rng;

        private static void Main(string[] args)
        {
            InitCharLists();
            _rng = new Random();
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(GenerateName() + Environment.NewLine);
            }

            Console.ReadKey();
        }

        private static String GenerateName()
        {
            int numOfParts = _rng.Next(3, 6);
            int poolChoice = _rng.Next(0, 6);
            StringBuilder generatedName = new StringBuilder();

            //Appends an entry from the appropriate letter pool and afterwards changes the pool to choose from 
            for (int i = 0; i < numOfParts; i++)
            {
                switch (poolChoice)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 3:
                        generatedName.Append(_vowels.GetRandomItem());
                        poolChoice = 5;
                        break;

                    case 4:
                        generatedName.Append(_diphthongs.GetRandomItem());
                        poolChoice = 5;
                        break;
                    //Give consonants a higher chance to appear
                    case 5:
                    case 6:
                    case 7:
                    case 8:
                        generatedName.Append(_consonants.GetRandomItem());
                        poolChoice = _rng.Next(0, 5);
                        break;
                }
            }

            generatedName[0] = Char.ToUpper(generatedName[0]);

            return generatedName.ToString();
        }

        private static void InitCharLists()
        {
            _vowels = new ProbabilityList<char>();
            _vowels.Add('a', 81);
            _vowels.Add('e', 127);
            _vowels.Add('i', 69);
            _vowels.Add('o', 75);
            _vowels.Add('u', 27);

            _diphthongs = new ProbabilityList<string>();
            _diphthongs.Add("ai", 20);
            _diphthongs.Add("au", 20);
            _diphthongs.Add("eu", 20);
            _diphthongs.Add("ei", 20);
            _diphthongs.Add("ui", 20);

            _consonants = new ProbabilityList<char>();
            _consonants.Add('b', 14);
            _consonants.Add('c', 27);
            _consonants.Add('d', 42);
            _consonants.Add('f', 22);
            _consonants.Add('g', 20);
            _consonants.Add('h', 60);
            _consonants.Add('j', 1);
            _consonants.Add('k', 07);
            _consonants.Add('l', 40);
            _consonants.Add('m', 24);
            _consonants.Add('n', 67);
            _consonants.Add('p', 19);
            _consonants.Add('q', 1);
            _consonants.Add('r', 59);
            _consonants.Add('s', 63);
            _consonants.Add('t', 90);
            _consonants.Add('v', 9);
            _consonants.Add('w', 23);
            _consonants.Add('x', 1);
            _consonants.Add('y', 19);
            _consonants.Add('z', 1);
        }
    }
}
