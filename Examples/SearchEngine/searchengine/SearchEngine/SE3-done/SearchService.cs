using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SE3_done
{
    public class SearchService : ISearchService
    {
        private SearchIndex _searchIndex;
        private Levenshtein _levenshtein;
        private readonly string _path;

        private static void Main()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo solutionPath = Directory.GetParent(currentDirectory).Parent;
            string root = solutionPath?.Parent?.Parent?.Parent?.FullName;
            string folder = $"{root}\\data\\search-data-S.txt";

            var program = new SearchService(folder);
            program.CreateDataStructure();
            program._levenshtein = new Levenshtein(program._searchIndex.DataSet);
            program.UserInput();
        }

        public SearchService(string path)
        {
            _path = path;
            CreateDataStructure();
            _levenshtein = new Levenshtein(_searchIndex.DataSet);
        }

        private void CreateDataStructure()
        {
            _searchIndex = new SearchIndex();

            List<SearchData> search = new List<SearchData>();
            Dictionary<string, int> repeatedWordCount = new Dictionary<string, int>();
            string page = null;
            string title = null;

            foreach (var line in File.ReadLines(_path))
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

                    if (repeatedWordCount.ContainsKey(line))
                    {
                        int value = repeatedWordCount[line];
                        repeatedWordCount[line] = value + 1;
                    }
                    else
                    {
                        repeatedWordCount.Add(line, 1);
                    }

                    search.Add(searchData);
                }
            }

            _searchIndex.FrequencyIndex = repeatedWordCount;
            _searchIndex.SearchContent = search.ToLookup(x => x.Word, x => x);
        }

        public IEnumerable<SearchData> Find(string input)
        {
            var searchData = new List<SearchData>();

            var words = _levenshtein.SimilarExists(input);

            foreach (var word in words)
            {
                var result = _searchIndex.FindWord(word.Key);

                if (result != null)
                {
                    foreach (var data in result)
                    {
                        var item = new SearchData
                        {
                            Word = data.Word,
                            Title = data.Title,
                            Url = data.Url,
                            Distance = word.Value,
                            Frequency = data.Frequency
                        };
                        searchData.Add(item);
                    }
                }
            }

            return searchData;
        }

        private void UserInput()
        {
            string input = null;
            while (input != "exit")
            {
                Console.Write("Enter a word to search: ");

                input = Console.ReadLine();

                var words = _levenshtein.SimilarExists(input);

                foreach (var word in words)
                {
                    var result = _searchIndex.FindWord(word.Key);

                    if (result != null)
                    {
                        foreach (var searchData in result)
                        {
                            Console.WriteLine(searchData != null
                                ? $"{searchData.Word} found with title {searchData.Title} with url {searchData.Url} and distance {word.Value} and repeated {searchData.Frequency}"
                                : $"word not found");
                        }
                    }
                }

                Console.WriteLine();
            }
        }
    }

    public interface ISearchService
    {
        IEnumerable<SearchData> Find(string input);
    }
}
