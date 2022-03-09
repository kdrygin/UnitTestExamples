using System.Collections.Generic;

namespace Synonyms
{
    using SynonymsDict = Dictionary<string, HashSet<string>>;

    public class Synonyms
    {
        private SynonymsDict synonyms;

        public SynonymsDict Dict
        {
            get { return synonyms; }
        }

        public Synonyms()
        {
            synonyms = new Dictionary<string, HashSet<string>>();
        }

        public void Add(string firstWord, string secondWord)
        {
            synonyms.TryAdd(firstWord, new HashSet<string>());
            synonyms[firstWord].Add(secondWord);

            synonyms.TryAdd(secondWord, new HashSet<string>());
            synonyms[secondWord].Add(firstWord);
        }

        public int GetSynonymCount(string word)
        {
            return synonyms.ContainsKey(word) ? synonyms[word].Count : 0;
        }

        public bool AreSynonyms(string firstWord, string secondWord)
        {
            return synonyms.ContainsKey(firstWord) ? synonyms[firstWord].Contains(secondWord) : false;
        }

    }
}
