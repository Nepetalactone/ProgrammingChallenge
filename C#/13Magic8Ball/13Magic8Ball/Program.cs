using System;

namespace _13Magic8Ball
{
    class Program
    {
        private static readonly String[] Answers = 
        {
            "It is certain",
            "It is decidedly so",
            "Without a doubt",
            "Yes definitely",
            "You may rely on it",
            "As I see it, yes",
            "Most likely",
            "Outlook good",
            "Yes",
            "Signs point to yes",
            "Reply hazy try again",
            "Ask again later",
            "Better not tell you now",
            "Cannot predict now",
            "Concentrate and ask again",
            "Don't count on it",
            "My reply is no",
            "My sources say no",
            "Outlook not so good",
            "Very doubtful"
        };

        static void Main(string[] args)
        {
            Console.WriteLine("Enter your question");
            String question = Console.ReadLine();
            
            while (!question.EndsWith("?"))
            {
                Console.WriteLine("Please address me in the form of a question");
                question = Console.ReadLine();
            }

            Random rng = new Random();
            Console.WriteLine(Answers[rng.Next(0, Answers.Length)]);
            Console.ReadKey();
        }
    }
}
