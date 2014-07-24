using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            printCurrentLocation();

            String[] userInput = Console.ReadLine().Split(' ');

            while (userInput[0] != EXIT)
            {
                //can't use switch case with non-constant strings, doesn't matter if they are readonly
                if (userInput[0] == EXIT)
                {
                }
                else if (userInput[0] == HELP)
                {
                    printHelp();
                }
                else if (userInput[0] == PRINT_CURRENT_DIR)
                {
                    printCurrentLocation();
                    Console.WriteLine(Environment.NewLine);
                }
                else if (userInput[0] == SHOW_DIRECTORY_CONTENTS)
                {
                    printDirectoryContents();
                }
                else if (userInput[0] == CHANGE_DIRECTORY)
                {
                    if (userInput.Length > 1)
                    {
                        changeDirectory(userInput[1]);
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
                printCurrentLocation();
                userInput = Console.ReadLine().Split(' ');
            }
            Console.ReadKey();
        }

        private static void printDirectoryContents()
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

        private static void changeDirectory(String chosenDirectory)
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

        private static void printCurrentLocation()
        {
            Console.Write(currentDirectory.FullName + ">");
        }

        private static void printHelp()
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
