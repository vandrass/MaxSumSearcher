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
            int linesNumber = content.GetFileContent.GetUpperBound(0) + 1;
            int brokenLinesCounter = 0;
            double tmpSum;
            bool parsed;
            _brokenLinesIndexes = new int[linesNumber];

            for (var i = 0; i < linesNumber; i++)
            {
                parsed = true;
                tmpSum = 0;

                for (var j = 0; j < content.GetFileContent[i].Length && parsed == true; j++)
                {
                    if (parsed = double.TryParse(content.GetFileContent[i][j], NumberStyles.AllowDecimalPoint, provider, out double number))
                    {
                        tmpSum += number;
                    }
                    else
                    {
                        _brokenLinesIndexes[brokenLinesCounter] = i + 1;
                        brokenLinesCounter++;
                    }
                }

                if (tmpSum > _maxSumOfLine)
                {
                    _maxSumOfLine = tmpSum;
                    _indexOfMaxSumLine = i + 1;
                }
            }

            PrintMaxLineAndBrokenLines();
        }

        private void PrintMaxLineAndBrokenLines()
        {
            Console.WriteLine("Line with maximal Sum of numbers is: " + _indexOfMaxSumLine);

            Console.Write("Broken Lines Numbers: ");

            for (int i = 0; i < _brokenLinesIndexes.Length; i++)
            {
                if (_brokenLinesIndexes[i] != 0)
                {
                    Console.Write(_brokenLinesIndexes[i]);
                }

                if ( i + 1 != _brokenLinesIndexes.Length && _brokenLinesIndexes[i + 1] != 0)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
