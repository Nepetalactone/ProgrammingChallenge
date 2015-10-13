using System;
using System.Net;

namespace _11TimeFromWeb
{
    class Program
    {
        static void Main(string[] args)
        {
            WebClient client = new WebClient();
            String[] time = client.DownloadString(@"http://atomicclock.abundanttech.com/AtomicClock.asmx/GetUniversalTime").Split('<', '>');
            Console.WriteLine(time[4].Replace(" ", "").Replace("\r\n", ""));
            Console.ReadKey();
        }
    }
}
