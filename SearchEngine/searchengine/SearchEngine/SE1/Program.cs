using System.Collections.Generic;
using System.IO;

namespace SE1
{
    public class Program
    {
        List<SearchData> _searchContent;

        public static void Main(string[] args)
        {
            var program = new Program();

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo solutionPath = Directory.GetParent(currentDirectory).Parent;
            string root = solutionPath?.Parent?.Parent?.Parent?.FullName;
            string folder = $"{root}\\data\\search-data-L.txt";

            program.CreateDataStructure(folder);

            program.UserInput();
        }

        private void CreateDataStructure(string path)
        {
            //todo: write parser and build data structure to _searchContent
        }

        public void UserInput()
        {
            //todo: console UI
        }

        public List<SearchData> FindWord(string word)
        {
            //todo: search a word in _searchContent and return all possible founds.
            return null;
        }
    }

}
