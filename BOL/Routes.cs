using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOL
{
    // rest_id | rest_name    | address | image            | route_id | route_id | from_city | to_city
    public class Routes
    {
         public int rest_d { get; set; }
        public string rest_name { get; set; }

        public string address { get; set; }
        public string image { get; set; }
        public int route_id { get; set; }
        public string from_city { get; set; }
        public string to_city { get; set; }
    }
}
