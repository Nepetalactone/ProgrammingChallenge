using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _08LoveCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your own name");
            String firstName = Console.ReadLine();
            Console.WriteLine("Enter the other persons name");
            String secondName = Console.ReadLine();

            Console.WriteLine(calculateLove(firstName, secondName) + "%");
            Console.ReadKey();
        }

        private static double calculateLove(String firstName, String secondName)
        {
            double sum = 0;
            if (firstName.Length >= secondName.Length)
            {
                for (int i = 0; i < firstName.Length; i++)
                {
                    sum += ((int)firstName[i] * (int)secondName[i % secondName.Length]);
                }
            }
            else
            {
                return calculateLove(secondName, firstName);
            }

            return sum % 100;
        }
    }
}
