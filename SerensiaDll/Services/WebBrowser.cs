using SerensiaDll.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerensiaDll.Services
{
    public class WebBrowser : IWebBrowser
    {
        public string GetHtml(string url)
        {
            string path = Path.Combine("WebPages", url); 
            string html = File.ReadAllText(path);
            return html; 
        }
    }
}
