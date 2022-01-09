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
                path = PathInsert(ref args);
                Console.WriteLine(File.Exists(path) ? "File exists" : "File doesn't exist!");
            }
            while (!File.Exists(path));

            var myFile = new FileReader(path);

            var serviceCollection = new ServiceCollection();

            Console.ReadLine();
        }

        /// <summary>
        /// Get Path from cmd arguments or from user.
        /// </summary>
        /// <param name="args">cmd arguments.</param>
        /// <returns>path to file.</returns>
        public static string PathInsert(ref string[] args)
        {
            string path;
            if (args.Length > 0 && args[0] != null)
            {
                Console.WriteLine(" your path is {0}", args[0]);
                path = args[0];
                args[0] = null;
            }
            else
            {
                Console.Write("Enter Path to File: ");
                path = Console.ReadLine();
            }

            return path;
        }
    }
}
