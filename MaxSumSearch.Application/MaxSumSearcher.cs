namespace MaxSumSearch.Application
{
    /// <summary>
    /// Search and print a Line with max sum of elements.
    /// </summary>
    public class MaxSumSearcher : IMaxSumSearcher
    {
        /// <summary>
        /// Print number of line, with maximal sum of elements,
        /// and "broken" lines (with non numeric symbols) aside.
        /// </summary>
        /// <param name="content">object with file content.</param>
        public void PrintMaxElementSumLine(FileContent content)
        {
            for (var i = 0; i < content.GetFileContent.GetUpperBound(0) + 1; i++)
            {
                foreach (var cont in content.GetFileContent[i])
                {
                    System.Console.Write(cont + "\t");
                }

                System.Console.WriteLine();
            }
        }
    }
}
