namespace MaxSumSearch.Application
{
    /// <summary>
    /// Search and print a Line with max sum of elements.
    /// </summary>
    public interface IMaxSumSearcher
    {
        /// <summary>
        /// Print number of line, with maximal sum of elements,
        /// and "broken" lines (with non numeric symbols) aside.
        /// </summary>
        /// <param name="content">object with file content.</param>
        public void PrintMaxElementSumLineAndBrokenLines(FileContent content);

        /// <summary>
        /// Method for unit test, check if method PrintMaxElementSumLine() print right Max sum numbers line.
        /// </summary>
        /// <param name="content">File content.</param>
        /// <returns>number of line with max sum of numbers.</returns>
        public int GetMaxSumLineTest(FileContent content);

        /// <summary>
        /// Method for unit test, check if method PrintMaxElementSumLine() print right number of broken lines.
        /// </summary>
        /// <param name="content">File content.</param>
        /// <returns>array with numbers of broken lines(include non numeric symbols).</returns>
        public int[] GetBrokenLinesTest(FileContent content);
    }
}
