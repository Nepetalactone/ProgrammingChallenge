using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace _09PseudoRandomSentenceGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            String[] text = new WebClient().DownloadString(@"http://www.gutenberg.org/ebooks/45862.txt.utf-8").Replace('.', ' ').Replace(',', ' ').Replace("  ", " ").Split(' ');
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
            int seedNr = rng.Next(0, text.Length - 3);
            String firstSeed = text[seedNr];
            String secondSeed = text[seedNr+1];

            for (int i = 0; i < 30; i++)
            {
                List<String> tempList = dict[new Tuple<string, string>(firstSeed, secondSeed)];
                randomSentence.Append(tempList[rng.Next(0, tempList.Count)]).Append(' ');
                seedNr = rng.Next(0, text.Length - 3);
                firstSeed = text[seedNr];
                secondSeed = text[seedNr + 1];
            }

            Console.WriteLine(randomSentence);
            Console.ReadKey();
        }
    }
}
