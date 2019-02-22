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
using System.Diagnostics;
using EVisa100.Enums;

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
                response = response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\"").StripSlashes();

                var application = JsonSerializer.Deserialize<Application[]>(response)[0];
                var e = application.EntryPoint;
                application.Passport = GetPassport(application.passport_id);

                return application;
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.ToString());
            }

            return null;
        }

        public Passport GetPassport(int id)
        {
            var url = "https://fan.blockai.me/get_passports.php";

            UriBuilder urlBuilder = new UriBuilder(url);
            urlBuilder.Query = $"id={id}";

            var httpRequest = (HttpWebRequest)WebRequest.Create(urlBuilder.ToString());
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json; charset=UTF-8";

            try
            {
                var httpResponse = (HttpWebResponse)httpRequest.GetResponse();
                var stream = httpResponse.GetResponseStream();
                var reader = new StreamReader(stream);
                var response = reader.ReadToEnd();

                // string ot object.
                response = response.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\"").StripSlashes();

                var parsports = JsonSerializer.Deserialize<Passport[]>(response);
                Debug.Assert(parsports.Length > 0);

                return parsports[0];
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
