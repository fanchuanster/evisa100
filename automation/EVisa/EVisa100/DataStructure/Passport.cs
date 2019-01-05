﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                if (data.ContainsKey("name")) return string.Empty;

                var name = data["name"] as string;
                var fields = name.Split(new char[] { ' ', ',', '.', '\n', '\t' });

                return fields.FirstOrDefault();
            }
        }

        public string GivenName
        {
            get
            {
                if (data.ContainsKey("name")) return string.Empty;

                var name = data["name"] as string;
                var fields = name.Split(new char[] { ' ', ',', '.', '\n', '\t' });

                return fields.LastOrDefault();
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
}
