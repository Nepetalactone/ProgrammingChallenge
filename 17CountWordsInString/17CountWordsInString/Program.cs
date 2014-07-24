using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _17CountWordsInString
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter a string");
            String wordsToCount = Console.ReadLine();
            Console.WriteLine(countWords(wordsToCount));
            Console.ReadKey();
        }

        private static int countWords(String wordsToCount)
        {
            return wordsToCount.Split(' ').Length;
        }
    }
}
