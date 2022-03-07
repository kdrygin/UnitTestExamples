using System.Diagnostics;

namespace Synonyms
{
    class TestSynonyms
    {
        public static void Run()
        {
            TestAddingSynonymsIncreasesTheirCount();
            TestAreSynonyms();
        }

        static void TestAddingSynonymsIncreasesTheirCount()
        {
            Synonyms synonyms = new Synonyms();
            Debug.Assert(synonyms.GetSynonymCount("music") == 0);
            Debug.Assert(synonyms.GetSynonymCount("melody") == 0);

            synonyms.Add("music", "melody");
            Debug.Assert(synonyms.GetSynonymCount("music") == 1);
            Debug.Assert(synonyms.GetSynonymCount("melody") == 1);

            synonyms.Add("music", "tune");
            Debug.Assert(synonyms.GetSynonymCount("music") == 2);
            Debug.Assert(synonyms.GetSynonymCount("tune") == 1);
            Debug.Assert(synonyms.GetSynonymCount("melody") == 1);
        }

        static void TestAreSynonyms()
        {
            Synonyms synonyms = new Synonyms();

            synonyms.Add("music", "melody");
            Debug.Assert(synonyms.AreSynonyms("music", "melody"));
            Debug.Assert(synonyms.AreSynonyms("melody", "music"));

            synonyms.Add("music", "tune");
            Debug.Assert(!synonyms.AreSynonyms("melody", "tune"));
            Debug.Assert(!synonyms.AreSynonyms("tune", "melody"));
        }

    }
}
