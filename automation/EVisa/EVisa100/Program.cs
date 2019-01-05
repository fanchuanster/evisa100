using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Web;
using System.Net.Http;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Firefox;
using EVisa100.DataStructure;
using System.Text.RegularExpressions;

namespace EVisa100
{
    class Program
    {
        static void Main(string[] args)
        {
            var server = new Server();

            var application = server.GetApplication();
            
            var automation = Automations.AutomationsFactory.GetAutomation("ke");
            automation.Run(application);
        }

        public static string Unicode2String(string source)
        {
            return new Regex(@"\\u([0-9A-F]{4})", RegexOptions.IgnoreCase | RegexOptions.Compiled).Replace(
                         source, x => string.Empty + Convert.ToChar(Convert.ToUInt16(x.Result("$1"), 16)));
        }
    }
}
