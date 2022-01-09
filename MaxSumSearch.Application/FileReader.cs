using System.IO;

namespace MaxSumSearch.Application
{
    /// <summary>
    /// Class Read file and save each line to array.
    /// </summary>
    public class FileReader
    {
        private string _path;
        private int _fileLinesCount;

        public FileReader(string path)
        {
            _path = path;
            _fileLinesCount = File.ReadAllLines(_path).Length;
            FillInfo();
        }

        private void FillInfo()
        {
            string[][] file = new string[_fileLinesCount][];
            using (var streamReader = new StreamReader(_path))
            {
                for (int i = 0; i < file.GetUpperBound(0) + 1; i++)
                {
                    file[i] = streamReader.ReadLine().Split(",");
                }
            }

            GetFile = file;
        }

        public string[][] GetFile { get; private set; }
    }
}
