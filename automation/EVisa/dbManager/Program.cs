using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Script.Serialization;
namespace testcsharp
{
    class city
    {
        public string label;
        public string name;
        public string pinyin;
        public string zip;
    }
    class CnName
    {
        public string name_cn;
        public string name;
    }
    class TransportationBy
    {
        public string by;
        public CnName[] data;
    }
    class entrypoint
    {
        public int id;
        public string country;
        public TransportationBy[] data;
    }
    class country
    {
        public string name;
        public string name_cn;
        public string name_short;
        public string continent;
    }
    class productData
    {
        public string time_required;
        public string name;
        public int price;
    }
    class product
    {
        public int country_id;
        public int store_id;
        public productData data;
    }
    class Program
    {
        static void SaveCountries()
        {
            JavaScriptSerializer converter = new JavaScriptSerializer();
            using (StreamReader r = new StreamReader("../../../../../doc/country.json", Encoding.UTF8))
            {
                var json = r.ReadToEnd();
                var items = converter.Deserialize<List<country>>(json);
                
                var url = "https://php.evisa100.com/save_country.php";

                foreach (var item in items)
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.Method = "POST";

                    var data = converter.Serialize(item);
                    var t = Encoding.UTF8.GetBytes(data);
                    httpRequest.ContentType = "application/json; charset=UTF-8";
                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(t, 0, t.Length);
                    }

                    var response = (HttpWebResponse)httpRequest.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }

            }
        }
        static void SaveProducts()
        {
            JavaScriptSerializer converter = new JavaScriptSerializer();
            using (StreamReader r = new StreamReader("../../../../../doc/products.json", Encoding.UTF8))
            {
                var json = r.ReadToEnd();
                var items = converter.Deserialize<List<product>>(json);

                //var url = "https://php.evisa100.com/save_entrypoints.php";
                var url = "https://php.evisa100.com/save_product.php";
                
                foreach (var item in items)
                {
                    var httpRequest = (HttpWebRequest)WebRequest.Create(url);
                    httpRequest.Method = "POST";

                    var data = converter.Serialize(item);
                    var t = Encoding.UTF8.GetBytes(data);
                    httpRequest.ContentType = "application/json; charset=UTF-8";
                    using (var stream = httpRequest.GetRequestStream())
                    {
                        stream.Write(t, 0, t.Length);
                    }

                    var response = (HttpWebResponse)httpRequest.GetResponse();
                    var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
                }
                
            }
        }
        static void GetEntryPoint(string country)
        {
            JavaScriptSerializer converter = new JavaScriptSerializer();
            var url = "https://php.evisa100.com/get_entrypoint.php?country=" + country;

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);
            httpRequest.Method = "GET";
            httpRequest.ContentType = "application/json; charset=UTF-8";

            var response = (HttpWebResponse)httpRequest.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();

            responseString = responseString.Replace("\"{", "{").Replace("}\"", "}").Replace("\\\"", "\"");
        }
        static void Main(string[] args)
        {
            OverrideValidation();

            //SaveCountries();
            SaveProducts();

            return;
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
