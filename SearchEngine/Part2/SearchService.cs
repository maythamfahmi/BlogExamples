namespace SE2_done
{
    public class SearchService
    {
        private ILookup<string, SearchData> _searchContent;

        public static void Main(string[] args)
        {
            var program = new SearchService("./data/search-data-L.txt");
            program.UserInput();
        }

        public SearchService(string path)
        {
            CreateDataStructure(path);
        }

        public void CreateDataStructure(string path)
        {
            var searchContent = new List<SearchData>();

            string? page = null;
            string? title = null;

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
            string? word = null;
            while (word != "exit")
            {
                Console.Write("Enter a word to search: ");

                word = Console.ReadLine();
                List<SearchData>? searchData = FindWord(word);
                if (searchData == null) continue;
                foreach (var data in searchData)
                {
                    Console.WriteLine($"{data.Word} found with title {data.Title} with url {data.Url}");
                }
            }
        }

        public List<SearchData>? FindWord(string? word)
        {
            IGrouping<string, SearchData>? result = _searchContent.FirstOrDefault(e => string.Equals(e.Key, word, StringComparison.CurrentCultureIgnoreCase));
            return result?.ToList();
        }
    }

}
