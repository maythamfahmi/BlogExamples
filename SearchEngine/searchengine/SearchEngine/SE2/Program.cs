using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SE2
{
    public class Program
    {
        private ILookup<string, SearchData> _searchContent;
        //or
        //private Dictionary<string, List<SearchData>> _searchContent;

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
            var searchContent = new List<SearchData>();

            string page = null;
            string title = null;

            foreach (var line in File.ReadLines(path))
            {
                SearchData searchData = new SearchData();

                if (line.StartsWith("*PAGE:"))
                {
                    page = line.Substring(6);
                    title = null;
                }
                else
                {
                    if (title == null)
                    {
                        title = line.Trim();
                    }
                }

                if (page != null && title != null)
                {
                    searchData.Url = page;
                    searchData.Title = title;
                    searchData.Word = line.Trim();

                    searchContent.Add(searchData);
                }
            }

            //use the new data structure _searchContent
        }

        public void UserInput()
        {
            string word = null;
            while (word != "exit")
            {
                Console.Write("Enter a word to search: ");

                word = Console.ReadLine();
                List<SearchData> searchData = FindWord(word);
                foreach (var data in searchData)
                {
                    Console.WriteLine(data != null
                        ? $"{data.Word} found with title {data.Title} with url {data.Url}"
                        : "word not found");
                }
            }
        }

        public List<SearchData> FindWord(string word)
        {
            //todo change data structure
            return null;
        }
    }

}
