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
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace EVisa100
{
    class Program
    {
        static void test()
        {
            OverrideValidation();
            //String url = "http://fan.blockai.me/save_passport.php";
            //String url = "http://fan.blockai.me/get_passports.php?id=1";
            //String url = "http://fan.blockai.me/submit_application.php";
            String url = "https://fan.blockai.me/get_application.php";

            String bodys = string.Empty;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.ContentType = "application/json; charset=UTF-8";
            if (0 < bodys.Length)
            {
                byte[] data = Encoding.UTF8.GetBytes(bodys);
                using (Stream stream = httpRequest.GetRequestStream())
                {
                    stream.Write(data, 0, data.Length);
                }
            }

            HttpWebResponse httpResponse = null;
            try
            {
                httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var stream = httpResponse.GetResponseStream();

                var file = File.Create("response.txt");
                stream.CopyTo(file);
                file.Close();
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private static bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain,
                                                      SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        public static void OverrideValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback =
                OnValidateCertificate;
            ServicePointManager.Expect100Continue = true;
        }

        public static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }

        static void Main(string[] args)
        {
            test();

            // Create a new instance of the Firefox driver.
            // Note that it is wrapped in a using clause so that the browser is closed 
            // and the webdriver is disposed (even in the face of exceptions).

            // Also note that the remainder of the code relies on the interface, 
            // not the implementation.

            // Further note that other drivers (InternetExplorerDriver,
            // ChromeDriver, etc.) will require further configuration 
            // before this example will work. See the wiki pages for the
            // individual drivers at http://code.google.com/p/selenium/wiki
            // for further information.
            
            }

        }
    }
}
