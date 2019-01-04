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
        
    }
}
