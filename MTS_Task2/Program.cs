using CommandLine;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

namespace MTS_Task2
{
    class Program
    {
        private static string _resultPath = "result.txt";

        private static readonly Dictionary<string, Func<string, int>> _handlers = new Dictionary<string, Func<string, int>>
            {
                { ".html", HtmlHandler },
                { ".css", CssHandler }
            };

        static void Main(string[] args)
        {
            Parser.Default.ParseArguments<Args>(args)
                .MapResult((Args opts) =>
                {
                    try
                    {
                        FileSystemWatcher fileSystemWatcher = new FileSystemWatcher(opts.DirectoryPathToWatch);
                        fileSystemWatcher.Created += FileSystemWatcher_Created;
                        fileSystemWatcher.EnableRaisingEvents = true;
                        Console.ReadKey();
                        return 0;
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Error!");
                        return -3; 
                    }
                },
                errs => -1);
        }

        private static void FileSystemWatcher_Created(object sender, FileSystemEventArgs e)
        {
            var fileInfo = new FileInfo(e.Name);


            var result = _handlers.GetValueOrDefault(fileInfo.Extension, DefaultHandler)(File.ReadAllText(e.FullPath));
            File.AppendAllText(_resultPath, $"{e.Name}-CREATE-{result}\n");
        }

        private static int HtmlHandler(string fileValue)
        {
            return Regex.Matches(fileValue, @"div").Count;
        }

        private static int CssHandler(string fileValue)
        {
            return Convert.ToInt32((Regex.Matches(fileValue, @"{").Count == Regex.Matches(fileValue, @"}").Count));
        }

        private static int DefaultHandler(string fileValue)
        {
            return Regex.Matches(fileValue, @"[.,!?]").Count;
        }
    }
}
