using EVisa100.Enums;
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
        public string name;
        public string name_cn;
        public Dictionary<string, object> data;
        
        public string JobTitle
        {
            get
            {
                var jobType = (JobType)Convert.ToInt32(data["job_type"]);
                if (jobType != JobType.Employed) return jobType.ToString();

                if (data.ContainsKey("job_title"))
                    return data["job_title"] as string;
                return data["job_title_cn"] as string;
            }
        }
        public string Address
        {
            get
            {
                if (data.ContainsKey("address"))
                    return data["address"] as string;
                
                return data["address_cn"] as string;
            }
        }
        public string FatherName
        {
            get
            {
                if (data.ContainsKey("father_name_sur"))
                {
                    var sur = data["father_name_sur"] as string;
                    if (sur != null) return sur + ", " + data["father_name_given"] as string;
                }

                return data["father_name_sur_cn"] as string + ", " + data["father_name_given_cn"] as string;
            }
        }
        public string MotherName
        {
            get
            {
                if (data.ContainsKey("mother_name_sur"))
                {
                    var sur = data["mother_name_sur"] as string;
                    return sur + ", " + data["mother_name_given"] as string;
                }

                return data["mother_name_sur_cn"] as string + ", " + data["mother_name_given_cn"] as string;
            }
        }
        public string SurName
        {
            get
            {
                var fields = name.Split(new char[] { ' ', ',', '.', '\n', '\t' });

                return fields.FirstOrDefault();
            }
        }

        public string GivenName
        {
            get
            {
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
                var city = region[1] as string;
                if (city == "全部")
                {
                    city = region[0] as string;
                }

                return city;
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

        public int status;
        public string to_country;
        public Purpose purpose;
        public DateTime entry_date;
        public DateTime departure_date;
        public Dictionary<string, object> data;

        public string By
        {
            get
            {
                var by = Convert.ToInt32(data["by"].ToString());
                return ((TransportationBy)by).ToString();
            }
        }
        public string EntryPoint
        {
            get
            {
                var npoints = data["entry_point"] as Dictionary<string, object>;
                return npoints["name"].ToString();
            }
        }
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
