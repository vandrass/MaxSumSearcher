using System;
using System.IO;
using MaxSumSearch.Application;
using Microsoft.Extensions.DependencyInjection;

namespace MaxSumSearch.UI
{
    /// <summary>
    /// Start program class with console User Interface.
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Main UI Method.
        /// </summary>
        /// <param name="args">path to file.</param>
        public static void Main(string[] args)
        {
            string path;

            do
            {
                if (args.Length > 0 && File.Exists(args[0]))
                {
                    path = args[0];
                }
                else
                {
                    Console.Write("Enter Path to File: ");
                    path = Console.ReadLine();
                    Console.WriteLine(File.Exists(path) ? "File exists" : "File doesn't exist!");
                }
            }
            while (!File.Exists(path));

            var content = new FileContent(path);

            var serviceCollection = new ServiceCollection();
            serviceCollection.AddScoped<IMaxSumSearcher, MaxSumSearcher>();
            var provider = serviceCollection.BuildServiceProvider();
            var service = provider.GetRequiredService<IMaxSumSearcher>();

            service.PrintMaxElementSumLineAndBrokenLines(content);

            Console.ReadLine();
        }
    }
}
