namespace SE1_done
{
    public class SearchService
    {
        private List<SearchData> _searchContent;

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
            _searchContent = new List<SearchData>();

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

                    _searchContent.Add(searchData);
                }
            }
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
            List<SearchData> list = new List<SearchData>();

            foreach (var searchData in _searchContent)
            {
                if (string.Equals(searchData.Word, word, StringComparison.CurrentCultureIgnoreCase))
                {
                    list.Add(searchData);
                }
            }

            return list;
        }
    }

}
