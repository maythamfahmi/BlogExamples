namespace SE3_done
{
    public class Levenshtein
    {
        private int[,] _wordMatrix;
        private readonly HashSet<string> _data;

        public Levenshtein(HashSet<string> data)
        {
            _data = data;
        }

        public Dictionary<string, int> SimilarExists(string searchWord)
        {
            // preventing double words on returning list
            Dictionary<string, int> fuzzyWordList = new Dictionary<string, int>();

            foreach (string wordList in _data)
            {
                int distance = Compute(searchWord, wordList);
                if (2 >= distance && wordList.Length >= searchWord.Length)
                {
                    fuzzyWordList.Add(wordList, distance);
                }
            }
            return fuzzyWordList;
        }

        private int Compute(string inputWord, string checkWord)
        {
            int n = inputWord.Length;
            int m = checkWord.Length;

            if (n == 0)
            {
                return m;
            }

            if (m == 0)
            {
                return n;
            }

            _wordMatrix = new int[n + 1, m + 1];

            for (int i = 0; i <= n; i++)
            {
                _wordMatrix[i, 0] = i;
            }

            for (int j = 0; j <= m; j++)
            {
                _wordMatrix[0, j] = j;
            }

            for (int i = 1; i <= n; i++)
            {
                for (int j = 1; j <= m; j++)
                {
                    if (inputWord[i - 1] == checkWord[j - 1])
                    {
                        _wordMatrix[i, j] = _wordMatrix[i - 1, j - 1];
                    }
                    else
                    {
                        int minimum = int.MaxValue;
                        if ((_wordMatrix[i - 1, j]) + 1 < minimum)
                        {
                            minimum = (_wordMatrix[i - 1, j]) + 1;
                        }

                        if ((_wordMatrix[i, j - 1]) + 1 < minimum)
                        {
                            minimum = (_wordMatrix[i, j - 1]) + 1;
                        }

                        if ((_wordMatrix[i - 1, j - 1]) + 1 < minimum)
                        {
                            minimum = (_wordMatrix[i - 1, j - 1]) + 1;
                        }

                        _wordMatrix[i, j] = minimum;
                    }
                }
            }

            return _wordMatrix[inputWord.Length, checkWord.Length];
        }

    }
}
