using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10PasswordGenerator
{
    class Program
    {

        private static Random rng = new Random();

        private static readonly int PWD_LENGTH = 14;

        static void Main(string[] args)
        {
            Console.WriteLine(createRandomString());
            Console.ReadKey();
        }

        static private String createRandomString()
        {
            StringBuilder rndString = new StringBuilder();

            for (int i = 0; i < PWD_LENGTH; i++)
            {
                rndString.Append((char) rng.Next(33, 127));
            }

            return rndString.ToString();
        }
    }
}
