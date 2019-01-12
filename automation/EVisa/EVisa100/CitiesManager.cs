using EVisa100.DataStructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace EVisa100
{
    public static class CitiesManager
    {
        static List<City> cities;
        static CitiesManager()
        {
            JavaScriptSerializer converter = new JavaScriptSerializer();
            using (StreamReader r = new StreamReader("cities.json"))
            {
                var json = r.ReadToEnd();
                cities = converter.Deserialize<List<City>>(json);
            }
        }
        public static string GetCityPinyin(string name_cn)
        {
            var city = cities.Find(c => name_cn.Contains(c.name));
            if (city == null) return string.Empty;

            return city.pinyin;
        }
    }
}
