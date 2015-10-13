using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01HeadsTails
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rng = new Random();
            string[] headTails = new string[2] { "Tail", "Head" };
            Console.WriteLine(headTails[rng.Next(0, 2)] + " wins");
            Console.ReadKey();
        }
    }
}
