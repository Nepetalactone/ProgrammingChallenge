using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06RockPaperScissors
{
    class Program
    {
        private enum Choice { ROCK, PAPER, SCISSORS }
        private enum Result { WIN, DRAW, LOSS }

        static void Main(string[] args)
        {
            Random rng = new Random();
            Choice computerChoice = (Choice)rng.Next(0, 3);

            Console.WriteLine("What is your choice? r for rock, p for paper, s for scissors");

            Result result;

            switch (Console.ReadLine())
            {
                case "r":
                    if (computerChoice == Choice.PAPER)
                    {
                        result = Result.LOSS;
                    }
                    else if (computerChoice == Choice.ROCK)
                    {
                        result = Result.DRAW;
                    }
                    else
                    {
                        result = Result.WIN;
                    }
                    break;

                case "p":
                    if (computerChoice == Choice.PAPER)
                    {
                        result = Result.DRAW;
                    }
                    else if (computerChoice == Choice.ROCK)
                    {
                        result = Result.WIN;
                    }
                    else
                    {
                        result = Result.LOSS;
                    }
                    break;

                case "s":
                    if (computerChoice == Choice.PAPER)
                    {
                        result = Result.WIN;
                    }
                    else if (computerChoice == Choice.ROCK)
                    {
                        result = Result.LOSS;
                    }
                    else
                    {
                        result = Result.DRAW;
                    }
                    break;

                default:
                    Console.WriteLine("Human didn't enter appropriate choice");
                    result = Result.LOSS;
                    break;
            }

            switch (result)
            {
                case Result.WIN:
                    Console.WriteLine("Human wins");
                    break;

                case Result.DRAW:
                    Console.WriteLine("Draw");
                    break;

                case Result.LOSS:
                    Console.WriteLine("Human loses");
                    break;
            }
            Console.ReadKey();
        }
    }
}
