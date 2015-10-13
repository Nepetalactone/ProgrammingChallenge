using System;

namespace _20BMICalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter your mass and your height in meters");
            String[] massAndHeight = Console.ReadLine().Split(' ');
            double mass = 0.0;
            double height = 0.0;
            if ((Double.TryParse(massAndHeight[0], out mass)) && (Double.TryParse(massAndHeight[1], out height)))
            {
                Console.WriteLine("BMI: " + CalculateBMI(mass, height));
            }
            else
            {
                Console.WriteLine("Couldn't parse arguments");
            }
            Console.ReadKey();
        }

        private static double CalculateBMI(double mass, double height)
        {
            return mass / (height * height);
        }
    }
}
