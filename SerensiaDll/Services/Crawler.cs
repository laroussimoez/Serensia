using HtmlAgilityPack;
using SerensiaDll.Interfaces;
using SerensiaDll.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerensiaDll.Services
{
    public class Crawler : IAmTheTest
    { 
        List<string> emails = new List<string>();   
        Queue<WebPage> pages = new Queue<WebPage>();
        List<string> crawledPages = new List<string>();
        public List<string> GetEmailsInPageAndChildPages(IWebBrowser browser, string url, int maximumDepth)
        {
            WebPage startingPage = new WebPage { Url = url, Depth = 0};
         
            pages.Enqueue(startingPage);
            WebPage current;
            
            while (pages.Count >0)
            {
                current = pages.Dequeue();
               
                if (crawledPages.Contains(current.Url) || current.Depth > maximumDepth)
                    continue;
                crawledPages.Add(current.Url);
                string html = browser.GetHtml(current.Url);
                HtmlDocument doc = new HtmlDocument();
                doc.LoadHtml(html);

                List<string> all = new List<string>();
                var nodes = doc.DocumentNode.Descendants("a").Where(x=> x.Attributes["href"] != null).ToList();
                if (nodes.Any())
                {
                    all = nodes.Select(x => x.Attributes["href"].Value)
                    .ToList<string>();
                }
                //List<string> all = doc.DocumentNode.SelectNodes("//a[@href]")
                //     .Select(x => x.Attributes["href"].Value)
                //     .ToList<string>();

                List<string> mails = all.Where(x => x.StartsWith("mailto:")).Select(x => x.Replace("mailto:", "")).ToList();
                emails.AddRange(mails);
                var newpages = all.Where(x => !x.StartsWith("mailto:")).ToList();
                foreach (string p in newpages)
                {
                    pages.Enqueue(new WebPage
                    {
                        Url = p,
                        Depth = current.Depth + 1
                    });
                }

            }


            return emails.Distinct().ToList();
        }
    }
}
