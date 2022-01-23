using System;
using System.Globalization;

namespace MaxSumSearch.Application
{
    /// <summary>
    /// Search and print a Line with max sum of elements.
    /// </summary>
    public class MaxSumSearcher : IMaxSumSearcher
    {
        private readonly CultureInfo _provider = new CultureInfo("en-Us");
        private double _maxSumOfLine;
        private int _indexOfMaxSumLine;
        private int[] _brokenLinesIndexes;

        /// <summary>
        /// Print number of line, with maximal sum of elements,
        /// and "broken" lines (with non numeric symbols) aside.
        /// </summary>
        /// <param name="content">object with file content.</param>
        public void PrintMaxElementSumLineAndBrokenLines(FileContent content)
        {
            int linesNumber = content.GetFileContent.GetUpperBound(0) + 1;
            int brokenLinesCounter = 0;
            double tmpSum;
            bool parsed;
            var numbStyle = NumberStyles.AllowDecimalPoint;
            _brokenLinesIndexes = new int[linesNumber];

            for (var i = 0; i < linesNumber; i++)
            {
                parsed = true;
                tmpSum = 0;

                for (var j = 0; j < content.GetFileContent[i].Length && parsed; j++)
                {
                    if (double.TryParse(content.GetFileContent[i][j], numbStyle, _provider, out double number))
                    {
                        tmpSum += number;
                    }
                    else
                    {
                        _brokenLinesIndexes[brokenLinesCounter] = i + 1;
                        brokenLinesCounter++;
                        tmpSum = 0;
                        parsed = false;
                    }
                }

                if (tmpSum > _maxSumOfLine)
                {
                    _maxSumOfLine = tmpSum;
                    _indexOfMaxSumLine = i + 1;
                }
            }

            Array.Resize(ref _brokenLinesIndexes, brokenLinesCounter);

            PrintMaxAndBrokenLines();
        }

        /// <summary>
        /// Method for unit test, check if method PrintMaxElementSumLine() print right Max sum numbers line.
        /// </summary>
        /// <param name="content">File content.</param>
        /// <returns>number of line with max sum of numbers.</returns>
        public int GetMaxSumLineTest(FileContent content)
        {
            PrintMaxElementSumLineAndBrokenLines(content);
            return _indexOfMaxSumLine;
        }

        /// <summary>
        /// Method for unit test, check if method PrintMaxElementSumLine() print right number of broken lines.
        /// </summary>
        /// <param name="content">File content.</param>
        /// <returns>array with numbers of broken lines(include non numeric symbols).</returns>
        public int[] GetBrokenLinesTest(FileContent content)
        {
            PrintMaxElementSumLineAndBrokenLines(content);
            return _brokenLinesIndexes;
        }

        private void PrintMaxAndBrokenLines()
        {
            Console.WriteLine("Line with maximal Sum of numbers is: " + _indexOfMaxSumLine);

            Console.Write("Broken Lines Numbers: ");

            if (_brokenLinesIndexes.Length == 0)
            {
                Array.Resize(ref _brokenLinesIndexes, 1);
                _brokenLinesIndexes[0] = 0;
            }

            for (int i = 0; i < _brokenLinesIndexes.Length; i++)
            {
                Console.Write(_brokenLinesIndexes[i]);

                if (i + 1 != _brokenLinesIndexes.Length)
                {
                    Console.Write(", ");
                }
            }
        }
    }
}
