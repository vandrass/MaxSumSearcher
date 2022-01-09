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
        public void PrintMaxElementSumLine(FileContent content);
    }
}
