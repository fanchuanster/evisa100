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
using System.Net;

namespace EVisa100
{
    class Program
    {
        static void test()
        {
            var temp = Path.GetTempPath();
            //var url = "http://evisa.oss-cn-shanghai.aliyuncs.com/passport/E06279103.jpg";
            var url = "http://evisa.oss-cn-shanghai.aliyuncs.com/photo/opini5GNX-N6JKq6aqutfPHCxUDc_E06279103_photo.jpg";
            //var url2 = "http://evisa.oss-cn-shanghai.aliyuncs.com/photo/opini5GNX-N6JKq6aqutfPHCxUDc_E06279103_id_front.jpg";
            using (var client = new WebClient())
            {
                client.DownloadFile(url, temp + "passport1.jpg");
            }
        }
        static void Main(string[] args)
        {
            test();

            var server = new Server();

            var application = server.GetApplication();
            
            var automation = Automations.AutomationsFactory.GetAutomation("ke");
            automation.Run(application);
        }
    }
}
