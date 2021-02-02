using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using BOL;


namespace DAL
{
   public class RouteDBManager
    {
        public static readonly string connString = string.Empty;
        static RouteDBManager()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }

        public static List<Routes> GetallRoute(string to, string from)
        {
            List<Routes> wishlists = new List<Routes>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();
                    
                    string query = "select * from rastaurant join routes on rastaurant.route_id = routes.route_id where from_city = @to and to_city = @from or  from_city = @to and to_city = @from";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@to", to));
                    cmd.Parameters.Add(new MySqlParameter("@from", from));
                    //Wishlist wlist = new Wishlist();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //bookIds.Add(int.Parse(reader["book_id"].ToString()));
                            Routes theproducts = new Routes();
                            theproducts.rest_d = int.Parse(reader["rest_id"].ToString());
                            theproducts.rest_name = reader["rest_name"].ToString();
                            theproducts.address = reader["address"].ToString();

                            theproducts.image = reader["image"].ToString();
                            theproducts.route_id = int.Parse(reader["route_id"].ToString());
                            
                            theproducts.from_city = reader["from_city"].ToString();
                            theproducts.to_city = reader["to_city"].ToString();
                            wishlists.Add(theproducts);
                        }
                    }

                    con.Close();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return wishlists;
        }

        //select * from hotel join routes on hotel.route_id = routes.route_id where from_city = "pune" and to_city = "mumbai" or  from_city = "mumbai" and to_city = "Pune";
        public static List<Hotel> Getallhotel(string source, string destination)
        {

            List<Hotel> wishlists = new List<Hotel>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "select * from hotel join routes on hotel.route_id = routes.route_id where from_city = @from and to_city = @to or  from_city = @from and to_city = @to";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@to", source));
                    cmd.Parameters.Add(new MySqlParameter("@from", destination));
                    //Wishlist wlist = new Wishlist();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //| pump_id | pump_name | address | route_id | route_id | from_city | to_city |
                            //| hotel_id | hotel_name               | address  | image                                                                                                | route_id |
                            Hotel theproducts = new Hotel();
                            theproducts.hotel_id = int.Parse(reader["hotel_id"].ToString());
                            theproducts.hotel_name = reader["hotel_name"].ToString();
                            theproducts.address = reader["address"].ToString();
                            theproducts.image = reader["image"].ToString();

                            //theproducts.image = reader["image"].ToString();
                            theproducts.route_id = int.Parse(reader["route_id"].ToString());
                            wishlists.Add(theproducts);
                        }
                    }

                    con.Close();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return wishlists;

        }

        public static List<Petrol_Pump> GetallPetrol(string source, string destination)
        {
            List<Petrol_Pump> wishlists = new List<Petrol_Pump>();

            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "select * from petrol_pump join routes on petrol_pump.route_id = routes.route_id where from_city = @to and to_city = @from or  from_city = @to and to_city = @from";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@to", source));
                    cmd.Parameters.Add(new MySqlParameter("@from", destination));
                    //Wishlist wlist = new Wishlist();

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            //| pump_id | pump_name | address | route_id | route_id | from_city | to_city |
                            Petrol_Pump theproducts = new Petrol_Pump();
                            theproducts.pump_id = int.Parse(reader["pump_id"].ToString());
                            theproducts.pump_name = reader["pump_name"].ToString();
                            theproducts.address = reader["address"].ToString();
                            theproducts.location = reader["location"].ToString();

                            //theproducts.image = reader["image"].ToString();
                            theproducts.route_id = int.Parse(reader["route_id"].ToString());

                            theproducts.from_city = reader["from_city"].ToString();
                            theproducts.to_city = reader["to_city"].ToString();
                            wishlists.Add(theproducts);
                        }
                    }

                    con.Close();
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }
            return wishlists;

        }
    }
}
