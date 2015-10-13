using System;
using System.Text;

namespace _10PasswordGenerator
{
    class Program
    {

        private static readonly Random Rng = new Random();

        private const int PWD_LENGTH = 14;

        static void Main(string[] args)
        {
            Console.WriteLine(CreateRandomString());
            Console.ReadKey();
        }

        static private String CreateRandomString()
        {
            StringBuilder rndString = new StringBuilder();

            for (int i = 0; i < PWD_LENGTH; i++)
            {
                rndString.Append((char) Rng.Next(33, 127));
            }

            return rndString.ToString();
        }
    }
}
