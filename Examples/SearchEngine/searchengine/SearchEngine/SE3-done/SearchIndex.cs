using System;
using System.Collections.Generic;
using System.Linq;

namespace SE3_done
{
    public class SearchIndex
    {
        public ILookup<string, SearchData> SearchContent { get; set; }
        public Dictionary<string, int> FrequencyIndex { get; set; }
        public HashSet<string> DataSet => this.SearchContent
            .Select(e => e.Key)
            .ToHashSet();
        public List<SearchData> FindWord(string word)
        {
            var result = SearchContent
                .FirstOrDefault(e => string.Equals(e.Key, word, StringComparison.CurrentCultureIgnoreCase));
                
            if (result != null)
            {
                foreach (var searchData in result)
                {
                    searchData.Frequency = FrequencyIndex[word];
                }
            }

            return result?.ToList();
        }
    }
}
