﻿namespace SE2_done
{
    public class Program
    {
        private ILookup<string, SearchData> _searchContent;

        public static void Main(string[] args)
        {
            Run();
        }

        public static void Run()
        {
            var program = new Program();
            string folder = $"./data/search-data-L.txt";
            program.CreateDataStructure(folder);
            program.UserInput();
        }

        public void CreateDataStructure(string path)
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

            _searchContent = searchContent.ToLookup(x => x.Word, x => x);
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
            IGrouping<string, SearchData> result = _searchContent.FirstOrDefault(e => e.Key.ToLower() == word.ToLower());
            return result?.ToList();
        }
    }

}
