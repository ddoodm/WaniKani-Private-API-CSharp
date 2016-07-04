using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Ddoodm.WaniKani.Client;
using Ddoodm.WaniKani.Models;

namespace Ddoodm.WaniKani.Client.Tests
{
    [TestClass]
    public class LoginTests
    {
        [TestMethod]
        public void Test_Login_Success()
        {
            WaniKaniClient wanikani = new WaniKaniClient();
            WaniKaniUser user = wanikani.Login("test", "test");
            //WaniKaniReviewQueue reviews = wanikani.GetReviewsFor(user);

            //WaniKaniVocabClient vocabClient = new WaniKaniVocabClient(user);
            //WaniKaniVocabWord word = vocabClient.GetVocabWord(100);

            WaniKaniKanjiClient kanjiClient = new WaniKaniKanjiClient(user);
            WaniKaniKanji kanji = kanjiClient.GetKanji(42);
        }
    }
}
