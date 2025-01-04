using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlaySel.Modal
{
    public class Appconfig_DTO
    {
        public String Url { get; set; }
        public String Browser {  get; set; }
        public String Base_url { get; set; }
        public Endpoint Endpoint { get; set; }
    }

    public class Endpoint
    { 
        public String Booking { get; set; }
    }

    public class root {
        public int bookingid { get; set; }
    }
}
