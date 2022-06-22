using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Address_Book
{
    public class Address_Book_Model
    {
        public int s_no { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public int pin { get; set; }
        public float phone { get; set; }
        public string email { get; set; }
        public string group { get; set; }
    }
}
