using System;

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

            Console.WriteLine(CalculateLove(firstName, secondName) + "%");
            Console.ReadKey();
        }

        private static double CalculateLove(String firstName, String secondName)
        {
            double sum = 0;
            if (firstName.Length >= secondName.Length)
            {
                for (int i = 0; i < firstName.Length; i++)
                {
                    sum += (firstName[i] * secondName[i % secondName.Length]);
                }
            }
            else
            {
                return CalculateLove(secondName, firstName);
            }

            return sum % 100;
        }
    }
}
