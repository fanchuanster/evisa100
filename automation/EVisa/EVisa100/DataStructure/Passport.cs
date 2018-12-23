using System;
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
        public Dictionary<string, string> details;
    }

    public class Application
    {
        public int id;
        public Passport Passport;
        public int current_status;
        public string to_country;
        public string visa_type;
        public DateTime entry_date;
        public DateTime exit_date;
        public Dictionary<string, string> other_info;
    }

    public class ResponseData<T>
    {
        public T[] data;
    }
}
