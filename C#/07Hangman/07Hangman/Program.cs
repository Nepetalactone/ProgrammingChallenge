using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _07Hangman
{
    class Program
    {
        private static int MAX_TRIES = 10;

        static void Main(string[] args)
        {
            StringBuilder wordBuilder = new StringBuilder();
            do 
            {
                Console.WriteLine("Enter a word to be guessed");
                ConsoleKeyInfo enteredKey;

                do
                {
                    //doesn't show entered letters in the console
                    enteredKey = Console.ReadKey(true);

                    if (enteredKey.Key != ConsoleKey.Backspace && enteredKey.Key != ConsoleKey.Enter)
                    {
                        wordBuilder.Append(enteredKey.KeyChar);
                        Console.Write("*");
                    }
                    else
                    {
                        if (enteredKey.Key == ConsoleKey.Backspace && wordBuilder.Length > 0)
                        {
                            wordBuilder.Remove(wordBuilder.Length - 1, 1);
                            //goes one key back, prints a space, goes another key back
                            Console.Write("\b \b");
                        }
                    }
                } 
                while (enteredKey.Key != ConsoleKey.Enter);
            } 
            while (!wordBuilder.ToString().All(Char.IsLetter));

            Console.WriteLine(Environment.NewLine);
            String word = wordBuilder.ToString();

            StringBuilder obscuredWord = new StringBuilder();

            for (int i = 0; i < word.Length; i++)
            {
                obscuredWord.Append('_');
            }

            bool isWon = false;

            while ((isWon == false) && (MAX_TRIES > 0))
            {
                Console.WriteLine("Current word is {0}. Guess a letter. Remaining tries: {1}", obscuredWord, MAX_TRIES--);
                Char guessedChar = Console.ReadLine()[0];

                if (word.Contains(guessedChar))
                {
                    List<int> indexList = new List<int>();
                    for (int y = 0; y < word.Length; y++)
                    {
                        if (guessedChar.Equals(word[y]))
                        {
                            indexList.Add(y);
                        }
                    }

                    foreach (int z in indexList)
                    {
                        obscuredWord[z] = guessedChar;
                    }

                    if (!obscuredWord.ToString().Contains('_'))
                    {
                        isWon = true;
                    }
                }
            }
            Console.WriteLine(isWon ? "You win" : "You lose");
            Console.ReadKey();
        }
    }
}
