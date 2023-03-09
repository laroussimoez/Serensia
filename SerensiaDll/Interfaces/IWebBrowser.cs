using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SerensiaDll.Interfaces
{
    public interface IWebBrowser
    {
        string GetHtml(string url);
    }
}
