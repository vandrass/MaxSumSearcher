using System.IO;

namespace MaxSumSearch.Application
{
    /// <summary>
    /// Class Read file and save each line to array.
    /// </summary>
    public class FileContent
    {
        private readonly string _path;
        private readonly int _fileLinesCount;

        /// <summary>
        /// Initializes a new instance of the <see cref="FileContent"/> class.
        /// </summary>
        /// <param name="path">path to file for reading.</param>
        public FileContent(string path)
        {
            _path = path;
            _fileLinesCount = File.ReadAllLines(_path).Length;
            FillContentFromFile();
        }

        /// <summary>
        /// Gets array from file, each index - the array of line, separated by comma.
        /// </summary>
        public string[][] GetFileContent { get; private set; }

        private void FillContentFromFile()
        {
            string[][] file = new string[_fileLinesCount][];
            using (var streamReader = new StreamReader(_path))
            {
                for (int i = 0; i < file.GetUpperBound(0) + 1; i++)
                {
                    file[i] = streamReader.ReadLine().Split(",");
                }
            }

            GetFileContent = file;
        }
    }
}
