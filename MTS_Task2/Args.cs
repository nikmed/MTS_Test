using CommandLine;

namespace MTS_Task2
{
    class Args
    {
        [Option("dirpath", Default = "C:/", HelpText = "Путь к директории для наблюдения.")]
        public string DirectoryPathToWatch { get; set; }
    }
}
