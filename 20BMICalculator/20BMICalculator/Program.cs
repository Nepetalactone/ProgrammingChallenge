using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                Console.WriteLine("BMI: " + calculateBMI(mass, height));
            }
            else
            {
                Console.WriteLine("Couldn't parse arguments");
            }
            Console.ReadKey();
        }

        private static double calculateBMI(double mass, double height)
        {
            return mass / (height * height);
        }
    }
}
