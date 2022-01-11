using System;
using System.Globalization;

namespace MaxSumSearch.Application
{
    /// <summary>
    /// Search and print a Line with max sum of elements.
    /// </summary>
    public class MaxSumSearcher : IMaxSumSearcher
    {
        private double _maxSumOfLine;
        private int _indexOfMaxSumLine;
        private int[] _brokenLinesIndexes;
        private CultureInfo provider = new CultureInfo("en-Us");

        /// <summary>
        /// Print number of line, with maximal sum of elements,
        /// and "broken" lines (with non numeric symbols) aside.
        /// </summary>
        /// <param name="content">object with file content.</param>
        public void PrintMaxElementSumLine(FileContent content)
        {
            var linesNumber = content.GetFileContent.GetUpperBound(0) + 1;
            var brokenLinesCounter = 0;
            var tmpSum = 0;
            var parsed = true;

            _brokenLinesIndexes = new int[linesNumber];

            for (var i = 0; i < linesNumber; i++)
            {
                parsed = true;

                for (var j = 0; j < content.GetFileContent[i].Length && parsed == true; j++)
                {
                    if (parsed = double.TryParse(content.GetFileContent[i][j], NumberStyles.AllowDecimalPoint, provider, out double number))
                    {

                    }
                    else
                    {
                        _brokenLinesIndexes[brokenLinesCounter] = i;
                        brokenLinesCounter++;
                    }
                }

                Console.WriteLine();
            }
        }
    }
}
