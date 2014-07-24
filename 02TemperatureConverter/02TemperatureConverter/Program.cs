using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02TemperatureConverter
{
    class Program
    {

        //Enter 
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter a temperature to convert and the type of temperature seperated by a space, for example \"100 Celsius\". Currently only Celsius, Fahrenheit and Kelvin are supported");
            String entry = Console.ReadLine();
            double temperature;
            while ((double.TryParse(entry.Split(' ')[0], out temperature) == false) && ((entry.Split(' ')[1] != "Celsius") || (entry.Split(' ')[1] != "Fahrenheit") || (entry.Split(' ')[1] != "Kelvin")))
            {
                Console.WriteLine("Format not correct, please try again");
                entry = Console.ReadLine();
            }

            string temperatureType = entry.Split(' ')[1];

            if (temperatureType == "Celsius")
            {
                printTemperature(temperature, temperature + 273.15, (9 / 5) * temperature + 32);
            }
            else if (temperatureType == "Kelvin")
            {
                printTemperature(temperature - 273.15, temperature, (temperature - 273.15) * 1.8 + 32);
            }
            else if (temperatureType == "Fahrenheit")
            {
                printTemperature((temperature - 32) * 5 / 9, (temperature - 32) * 5 / 9 + 273.15, temperature);
            }
            Console.ReadKey();
        }

        static void printTemperature(double celsius, double kelvin, double fahrenheit)
        {
            Console.WriteLine("Celsius\tKelvin\tFahrenheit");
            Console.WriteLine("{0}\t{1}\t{2}", celsius, kelvin, fahrenheit);
        }
    }
}
