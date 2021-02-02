using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    //| pump_id | pump_name | address | route_id | | from_city | to_city |
    public class Petrol_Pump
    {
        public int pump_id { get; set; }
        public int route_id { get; set; }
        public string pump_name { get; set; }

        public string address { get; set; }
        public string image { get; set; }

        public string location { get; set; }

        public string from_city { get; set; }
        public string to_city { get; set; }
    }
}
