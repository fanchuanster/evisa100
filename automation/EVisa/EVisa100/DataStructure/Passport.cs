using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EVisa100.DataStructure
{
    public class Passport
    {
        public int id;
        public string openid;
        public string passport_no;
        public Dictionary<string, object> data;

        public string SurName
        {
            get
            {
                var name = data["name"] as string;
                var fields = name.Split(new char[] { ' ', ',', '.', '\n', '\t' });

                return fields.FirstOrDefault();
            }
        }

        public string GivenName
        {
            get
            {
                var name = data["name"] as string;
                var fields = name.Split(new char[] { ' ', ',', '.', '\n', '\t' });

                return fields.LastOrDefault();
            }
        }

        public DateTime BirthDate
        {
            get
            {
                var date = DateTime.Parse(data["birth_date"] as string);
                return date;
            }
        }

        public string BirthPlace
        {
            get
            {
                string input = data["birth_place"] as string;
                string pattern = "[^a-zA-Z]";
                string replacement = "";

                Regex rgx = new Regex(pattern);
                return rgx.Replace(input, replacement);
            }
        }

        public string IssuePlace
        {
            get
            {
                string input = data["issue_place"] as string;
                string pattern = "[^a-zA-Z]";
                string replacement = "";

                Regex rgx = new Regex(pattern);
                return rgx.Replace(input, replacement);
            }
        }

        public string City
        {
            get
            {
                var region = data["region"] as System.Collections.ArrayList;
                return region[1] as string;
            }
        }
        public string CityPinyin => CitiesManager.GetCityPinyin(City);

        public DateTime IssueDate
        {
            get
            {
                var date = DateTime.Parse(data["issue_date"] as string);
                return date;
            }
        }
        public DateTime ExpiryDate
        {
            get
            {
                var date = DateTime.Parse(data["expiry_date"] as string);
                return date;
            }
        }
    }

    public class Application
    {
        public int id;
        public int passport_id;

        [NonSerialized]
        public Passport Passport;

        public int current_status;
        public string to_country;
        public string purpose;
        public DateTime entry_date;
        public DateTime departure_date;
        public Dictionary<string, object> other_info;
    }

    public class ResponseData<T>
    {
        public T[] data;
    }

    class City
    {
        public string label;
        public string name;
        public string pinyin;
        public string zip;
    }
}
