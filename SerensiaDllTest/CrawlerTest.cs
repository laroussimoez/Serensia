using Microsoft.VisualStudio.TestTools.UnitTesting;
using SerensiaDll.Interfaces;
using SerensiaDll.Services;
using System;
using System.Collections.Generic;

namespace SerensiaDllTest
{
    [TestClass]
    public class CrawlerTest
    {
        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_0()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();
            
            int depth = 0;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org" };
            
            
            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            Assert.AreEqual(1, emails.Count);
        }
        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_0_values()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();
            int depth = 0;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org" };
            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            CollectionAssert.AreEqual(expectedResult, emails);
        }

        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_1()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();

            int depth = 1;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org", "ailleurs@mozilla.org" };


            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            Assert.AreEqual(2, emails.Count);
        }
        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_1_values()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();
           
            int depth = 1;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org", "ailleurs@mozilla.org" };

            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            CollectionAssert.AreEqual(expectedResult, emails);
        }

        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_2()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();

            int depth = 2;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org", "ailleurs@mozilla.org" , "loin@mozilla.org" };


            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            Assert.AreEqual(3, emails.Count);
        }
        [TestMethod]
        public void GetEmailsInPageAndChildPages_depth_2_values()
        {
            IAmTheTest crawler = new Crawler();
            IWebBrowser browser = new WebBrowser();

            int depth = 2;
            List<string> expectedResult = new List<string> { "nullepart@mozilla.org", "ailleurs@mozilla.org", "loin@mozilla.org" };

            List<string> emails = crawler.GetEmailsInPageAndChildPages(browser, "index.html", depth);

            CollectionAssert.AreEqual(expectedResult, emails);
        }



    }
}
