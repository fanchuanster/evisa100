using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;
using EVisa100.DataStructure;
using System.Web.Script.Serialization;
using System.IO;

namespace EVisa100
{
    class Server
    {
        static Server()
        {
            OverrideValidation();
        }
        JavaScriptSerializer jsonSerializer;
        JavaScriptSerializer JsonSerializer
        {
            get
            {
                if (jsonSerializer == null)
                {
                    jsonSerializer = new JavaScriptSerializer();
                }
                return jsonSerializer;
            }
        }
        public Application GetApplication()
        {
            var url = "https://fan.blockai.me/get_application.php";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";

            httpRequest.ContentType = "application/json; charset=UTF-8";

            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var stream = httpResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var response = reader.ReadToEnd();

                // string ot object.
                response = response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\"");

                var application = JsonSerializer.Deserialize<Application>(response);
                
                return application;                
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        void UpdateApplicationStatus(Application application)
        {
            //var url = "https://fan.blockai.me/get_application.php";

            //String bodys = string.Empty;

            //var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            //httpRequest.Method = "GET";

            //httpRequest.ContentType = "application/json; charset=UTF-8";
            //byte[] data = Encoding.UTF8.GetBytes(bodys);
            //using (Stream stream = httpRequest.GetRequestStream())
            //{
            //    stream.Write(data, 0, data.Length);
            //}

            //HttpWebResponse httpResponse = null;
            //try
            //{
            //    httpResponse = (HttpWebResponse)httpRequest.GetResponse();
            //    var stream = httpResponse.GetResponseStream();

            //    var file = File.Create("response.txt");
            //    stream.CopyTo(file);
            //    file.Close();
            //}
            //catch (WebException ex)
            //{
            //    Console.WriteLine(ex.ToString());
            //}
        }

        static private void OverrideValidation()
        {
            ServicePointManager.ServerCertificateValidationCallback = OnValidateCertificate;
            ServicePointManager.Expect100Continue = true;
        }
        static private bool OnValidateCertificate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
        {
            return true;
        }
        static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true;
        }
    }
}
