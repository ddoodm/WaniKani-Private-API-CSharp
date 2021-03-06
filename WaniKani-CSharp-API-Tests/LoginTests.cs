﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Configuration;

using Ddoodm.WaniKani.Client;
using Ddoodm.WaniKani.Models;

using System.Linq;
using System.IO;
using Nini.Config;

namespace Ddoodm.WaniKani.Client.Tests
{
    /// <summary>
    /// I know this isn't really a test class just yet.
    /// If anything, it's more of a really crummy integration test.
    /// 
    /// I can't invest too much time in making an easily testable
    /// HTTP interface, because I'd end up needing to mock a web server.
    /// 
    /// For now, this is just an automated integration test thingo
    /// that I run the debugger on to figure stuff out. 
    /// </summary>
    [TestClass]
    public class LoginTests
    {
        private string username, password;

        [TestInitialize]
        public void SetupCredentials()
        {
            // Load user credentials from a super secret file
            // that isn't tracked by Git. :P
            string credFilePath = ConfigurationManager.AppSettings["testCredentialsFilePath"];
            var credIni = new IniConfigSource(credFilePath);
            var creds = credIni.Configs["WaniKani"];
            this.username = creds.Get("Username");
            this.password = creds.Get("Password");
        }

        [TestMethod]
        public void Test_Login_Success()
        {
            var wanikani = new WaniKaniClient();
            var user = wanikani.Login(username, password);

            // Lessons
            var lessonClient = new WaniKaniLessonClient(user);
            var lesson = lessonClient.GetLessonQueue();
            //lessonClient.CompleteItem(lesson.Queue[0]);

            // Get radical information
            //var radicalClient = new WaniKaniRadicalClient(user);
            //var radical = radicalClient.GetRadical(20);

            // Reviews
            //var reviewClient = new WaniKaniReviewClient(user);
            //var reviews = reviewClient.GetReviews();

            //foreach(var item in reviews.Queue)
            //    reviewClient.UpdateItemProgress(item, 0, 0);

            //var vocabClient = new WaniKaniVocabClient(user);
            //var word = vocabClient.GetVocabWord(100);

            //var kanjiClient = new WaniKaniKanjiClient(user);
            //var kanji = kanjiClient.GetKanji(10);
        }
    }
}
