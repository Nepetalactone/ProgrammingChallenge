using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace _09PseudoRandomSentenceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            String[] text;
            using (WebClient client = new WebClient())
            {
                text = client.DownloadString(@"http://www.gutenberg.org/ebooks/45862.txt.utf-8")
                        .Replace("  ", " ")
                        .Replace('\n', ' ')
                        .Replace('(', ' ')
                        .Replace(')', ' ')
                        .Split(' ');
            }
            Dictionary<Tuple<String, String>, List<String>> dict = new Dictionary<Tuple<string,string>, List<string>>();
            for (int i = 0; i < text.Length - 2; i++)
            {
                if (dict.ContainsKey(new Tuple<string,string>(text[i], text[i+1])))
                {
                    dict[new Tuple<string,string>(text[i], text[i+1])].Add(text[i+2]);
                } else 
                {
                    dict.Add(new Tuple<string, string>(text[i], text[i+1]), new List<string>(){text[i+2]});
                }
            }

            StringBuilder randomSentence = new StringBuilder();

            Random rng = new Random();
            String firstSeed = text[0];
            String secondSeed = text[1];

            for (int i = 0; i < 600; i++)
            {
                List<String> tempList = dict[new Tuple<string, string>(firstSeed, secondSeed)];
                string wordToAppend = tempList[rng.Next(0, tempList.Count)];
                randomSentence.Append(wordToAppend).Append(' ');

                firstSeed = secondSeed;
                secondSeed = wordToAppend;

                if (i%10 == 0)
                {
                    randomSentence.Append("\n");
                }
            }
            Console.WriteLine(randomSentence);
            Console.ReadKey();
        }
    }
}
