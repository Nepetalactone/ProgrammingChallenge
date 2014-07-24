using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03CalculateAgeInSeconds
{
    class Program
    {
        static void Main(string[] args)
        {
            TimeSpan date = DateTime.Now - new DateTime(Int32.Parse(args[2]), Int32.Parse(args[1]), Int32.Parse(args[0]));
            Console.WriteLine(date.TotalSeconds);
            Console.ReadKey();
        }
    }
}
