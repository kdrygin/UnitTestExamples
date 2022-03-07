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
    }
}
