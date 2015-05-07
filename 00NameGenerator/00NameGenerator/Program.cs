using System;
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
                        generatedName.Append(_vowels.GetRandomItem());
                        poolChoice = 2;
                        break;

                    case 1:
                        generatedName.Append(_diphthongs.GetRandomItem());
                        poolChoice = 2;
                        break;
                    //Give consonants a higher chance to appear
                    case 2:
                    case 3:
                    case 4:
                    case 5:
                        generatedName.Append(_consonants.GetRandomItem());
                        poolChoice = _rng.Next(0, 2);
                        break;
                }
            }

            generatedName[0] = Char.ToUpper(generatedName[0]);

            return generatedName.ToString();
        }

        private static void InitCharLists()
        {
            _vowels = new ProbabilityList<char>();
            _vowels.Add('a', 8.1);
            _vowels.Add('e', 12.7);
            _vowels.Add('i', 6.9);
            _vowels.Add('o', 7.5);
            _vowels.Add('u', 2.7);

            _diphthongs = new ProbabilityList<string>();
            _diphthongs.Add("ai", 20);
            _diphthongs.Add("au", 20);
            _diphthongs.Add("eu", 20);
            _diphthongs.Add("ei", 20);
            _diphthongs.Add("ui", 20);

            _consonants = new ProbabilityList<char>();
            _consonants.Add('b', 1.4);
            _consonants.Add('c', 2.7);
            _consonants.Add('d', 4.2);
            _consonants.Add('f', 2.2);
            _consonants.Add('g', 2.0);
            _consonants.Add('h', 6.0);
            _consonants.Add('j', 0.1);
            _consonants.Add('k', 0.7);
            _consonants.Add('l', 4.0);
            _consonants.Add('m', 2.4);
            _consonants.Add('n', 6.7);
            _consonants.Add('p', 1.9);
            _consonants.Add('q', 0.1);
            _consonants.Add('r', 5.9);
            _consonants.Add('s', 6.3);
            _consonants.Add('t', 9.0);
            _consonants.Add('v', 0.9);
            _consonants.Add('w', 2.3);
            _consonants.Add('x', 0.1);
            _consonants.Add('y', 1.9);
            _consonants.Add('z', 0.1);
        }
    }
}
