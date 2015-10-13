using System;
using System.Linq;
using System.IO;
using System.Reflection;

namespace _16SimpleFileExplorer
{
    class Program
    {
        private static readonly String EXIT = "exit";
        private static readonly String HELP = "help";
        private static readonly String SHOW_DIRECTORY_CONTENTS = "dir";
        private static readonly String PRINT_CURRENT_DIR = "cur";
        private static readonly String CHANGE_DIRECTORY = "cd";
        private static readonly String TREE = "tree";

        private static DirectoryInfo currentDirectory;

        static void Main(string[] args)
        {
            currentDirectory = new FileInfo(Assembly.GetExecutingAssembly().Location).Directory;
            PrintCurrentLocation();

            String[] userInput = Console.ReadLine().Split(' ');

            while (userInput[0] != EXIT)
            {
                //can't use switch case with non-constant strings, doesn't matter if they are readonly
                if (userInput[0] == HELP)
                {
                    PrintHelp();
                }
                else if (userInput[0] == PRINT_CURRENT_DIR)
                {
                    PrintCurrentLocation();
                    Console.WriteLine(Environment.NewLine);
                }
                else if (userInput[0] == SHOW_DIRECTORY_CONTENTS)
                {
                    PrintDirectoryContents();
                }
                else if (userInput[0] == CHANGE_DIRECTORY)
                {
                    if (userInput.Length > 1)
                    {
                        ChangeDirectory(userInput[1]);
                    }
                    else
                    {
                        Console.WriteLine("No second argument was supplied");
                    }
                }
                else
                {
                    Console.WriteLine("Argument " + userInput[0] + " not recognized");
                }
                PrintCurrentLocation();
                userInput = Console.ReadLine().Split(' ');
            }
        }

        private static void PrintDirectoryContents()
        {
            foreach (DirectoryInfo dir in currentDirectory.GetDirectories())
            {
                Console.WriteLine(dir.LastWriteTime + "\t<DIR>\t"+ dir.Name);
            }

            foreach (FileInfo file in currentDirectory.GetFiles())
            {
                Console.WriteLine(file.LastWriteTime + "\t<FIL>\t" + file.Name);
            }
        }

        private static void ChangeDirectory(String chosenDirectory)
        {
            if (currentDirectory.GetDirectories().Any(item => item.Name == chosenDirectory) == true)
            {
                currentDirectory = new DirectoryInfo(currentDirectory.FullName + @"\" + chosenDirectory);
            }
            else if (chosenDirectory == "..")
            {
                currentDirectory = currentDirectory.Parent;
            }
            else if (Directory.Exists(chosenDirectory))
            {
                currentDirectory = new DirectoryInfo(chosenDirectory);
            }
            else
            {
                Console.WriteLine("No such directory");
            }
        }

        private static void PrintCurrentLocation()
        {
            Console.Write(currentDirectory.FullName + ">");
        }

        private static void PrintHelp()
        {
            Console.WriteLine(@"Available Commands:
-exit       closes the program
-help       shows the available commands
-dir        shows the directory contents
-cur        prints the contents of the current directory
-cd <DIR>   changes to the specified directory");
        }
    }
}
