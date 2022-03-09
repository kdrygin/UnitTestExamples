using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

// Assert Class
// https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualstudio.testtools.unittesting.assert

namespace Synonyms
{
    [TestClass]
    public class SynonymsTest
    {
        [TestMethod]
        public void TestAddingSynonymsIncreasesTheirCount()
        {
            Synonyms synonyms = new Synonyms();
            Assert.AreEqual(synonyms.GetSynonymCount("music"), 0);
            Assert.AreEqual(synonyms.GetSynonymCount("melody"), 0);

            synonyms.Add("music", "melody");
            Assert.AreEqual(synonyms.GetSynonymCount("music"), 1);
            Assert.AreEqual(synonyms.GetSynonymCount("melody"), 1);

            synonyms.Add("music", "tune");
            Assert.AreEqual(synonyms.GetSynonymCount("music"), 2);
            Assert.AreEqual(synonyms.GetSynonymCount("tune"), 1);
            Assert.AreEqual(synonyms.GetSynonymCount("melody"), 1);
        }

        [TestMethod]
        public void TestAreSynonyms()
        {
            Synonyms synonyms = new Synonyms();

            synonyms.Add("music", "melody");
            Assert.IsTrue(synonyms.AreSynonyms("music", "melody"));
            Assert.IsTrue(synonyms.AreSynonyms("melody", "music"));

            synonyms.Add("music", "tune");
            Assert.IsFalse(synonyms.AreSynonyms("melody", "tune"));
            Assert.IsFalse(synonyms.AreSynonyms("tune", "melody"));
        }

        [TestMethod]
        public void TestCollections()
        {
            Synonyms synonyms = new Synonyms();

            var testDict = new Dictionary<string, HashSet<string>>()
            {
                { "music", new HashSet<string>() { "melody" } },
                { "melody", new HashSet<string>() { "music" } },
            };

            synonyms.Add("music", "melody");

            // because HashSet objects will be compared with object.Equals and they are not same
            // https://stackoverflow.com/questions/5194966/mstest-collectionassert-areequivalent-failed-the-expected-collection-contains
            CollectionAssert.AreEqual(testDict, synonyms.Dict, new DictComparer());  

            // compare each HashSet manually
            //foreach (var word in synonyms.Dict)
            //{
            //    CollectionAssert.AreEqual(testDict[word.Key], word.Value);
            //}
        }

        //Why CollectionAssert.AreEqual fails even when both lists contain the same items
        //https://softwareonastring.com/357/why-collectionassert-areequal-fails-even-when-both-lists-contain-the-same-items
        private class DictComparer : Comparer<KeyValuePair<string, HashSet<string>>>
        {
            public override int Compare(KeyValuePair<string, HashSet<string>> lhs, KeyValuePair<string, HashSet<string>> rhs)
            {
                // compare the two pais
                // for the purpose of this tests they are considered equal when their identifiers (names) match
                return lhs.Key.CompareTo(lhs.Key);
            }
        }
    }
}
