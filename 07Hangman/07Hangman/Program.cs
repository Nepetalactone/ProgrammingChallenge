using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07Hangman
{
    class Program
    {
        private static int MAX_TRIES = 10;

        static void Main(string[] args)
        {
            StringBuilder wordBuilder = new StringBuilder();
            do {
                Console.WriteLine("Enter a word to be guessed");
                ConsoleKeyInfo key;

                do
                {
                    //doesn't show entered letters in the console
                    key = Console.ReadKey(true);

                    if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                    {
                        wordBuilder.Append(key.KeyChar);
                        Console.Write("*");
                    }
                    else
                    {
                        if (key.Key == ConsoleKey.Backspace && wordBuilder.Length > 0)
                        {
                            wordBuilder.Remove(wordBuilder.Length - 1, 1);
                            //goes one key back, prints a space, goes another key back
                            Console.Write("\b \b");
                        }
                    }
                } while (key.Key != ConsoleKey.Enter);

                
            } while (!wordBuilder.ToString().All(Char.IsLetter));
            Console.WriteLine(Environment.NewLine);
            String word = wordBuilder.ToString();

            StringBuilder obscuredWord = new StringBuilder();
            foreach (char c in word)
            {
                obscuredWord.Append('_');
            }
            bool isWon = false;
            int i = 0;
            while ((isWon == false) && (i < MAX_TRIES))
            {
                Console.WriteLine("Current word is " + obscuredWord.ToString() + ". Guess a letter. Remaining tries: " + (MAX_TRIES - i));
                Char x = Console.ReadLine()[0];

                if (word.Contains(x))
                {
                    List<int> indexList = new List<int>();
                    for (int y = 0; y < word.Length; y++)
                    {
                        if (x.Equals(word[y]))
                        {
                            indexList.Add(y);
                        }
                    }

                    foreach (int z in indexList)
                    {
                        obscuredWord[z] = x;
                    }

                    if (!obscuredWord.ToString().Contains('_'))
                    {
                        isWon = true;
                    }
                }
                else
                {
                    i++;
                }
            }

            if (isWon)
            {
                Console.WriteLine("You win");
            }
            else
            {
                Console.WriteLine("You lose");
            }
            Console.ReadKey();
        }
    }
}
