using System;

namespace _17CountWordsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            String wordsToCount = Console.ReadLine();
            Console.WriteLine(wordsToCount.Split(' ').Length);
            Console.ReadKey();
        }
    }
}
