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
    public class LoginDBManger
    {
        public static readonly string connString = string.Empty;
        static LoginDBManger()
        {
            connString = ConfigurationManager.ConnectionStrings["dbString"].ConnectionString;
        }

        public static bool regUser(User c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "insert into user_register values(default,@uname,@email,@pass,@contactno,@address,@pincode)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.Parameters.Add(new MySqlParameter("@uname", c.username));
      
                    cmd.Parameters.Add(new MySqlParameter("@email", c.email));
                    cmd.Parameters.Add(new MySqlParameter("@pass", c.password));
                    cmd.Parameters.Add(new MySqlParameter("@contactno", c.contactno));
                    cmd.Parameters.Add(new MySqlParameter("@address", c.address));
                    cmd.Parameters.Add(new MySqlParameter("@pincode", c.pincode));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;

        }

        public static List<User> Getalluserdata()
        {
            List<User> allProducts = new List<User>();

            //logic to fetch all records from database
            IDbConnection conn = new MySqlConnection();
            conn.ConnectionString = connString;
            string query = "select * from user_register";
            IDbCommand cmd = new MySqlCommand();
            cmd.CommandText = query;
            cmd.Connection = conn;


            MySqlDataAdapter da = new MySqlDataAdapter(cmd as MySqlCommand);

            DataSet ds = new DataSet();

            try
            {
                da.Fill(ds);
                DataRowCollection rows = ds.Tables[0].Rows;
                foreach (DataRow row in rows)
                {
                    User theproducts = new User();
                    theproducts.userID = int.Parse(row["userID"].ToString());
                    theproducts.username = row["username"].ToString();
                    theproducts.email = row["email"].ToString();
                    //theproducts.bookspage = int.Parse(row["contact_num"].ToString());
                    theproducts.address = row["address"].ToString();
                    theproducts.contactno = row["contact_num"].ToString();
                
                    allProducts.Add(theproducts);
                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }


            return allProducts;
        }

        public static bool regAdmin(Admin ca)
        {

            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))   //DI via Constructor
                {
                    if (con.State == ConnectionState.Closed)        //if connection is closed?
                        con.Open();
                    string query = "insert into admin_register values(default,@uname,@email,@pass,@contactno,@address,@pincode)";
                    MySqlCommand cmd = new MySqlCommand(query, con);
                    //cmd.Parameters.Add(new MySqlParameter("@default", default));
                    cmd.Parameters.Add(new MySqlParameter("@uname", ca.username));

                    cmd.Parameters.Add(new MySqlParameter("@email", ca.email));
                    cmd.Parameters.Add(new MySqlParameter("@pass", ca.password));
                    cmd.Parameters.Add(new MySqlParameter("@contactno", ca.contactno));
                    cmd.Parameters.Add(new MySqlParameter("@address", ca.address));
                    cmd.Parameters.Add(new MySqlParameter("@pincode", ca.pincode));

                    cmd.ExecuteNonQuery();
                    con.Close();
                    status = true;
                }
            }
            catch (MySqlException exp)
            {
                string message = exp.Message;
            }
            return status;

        }

        public static bool login(User c)
        {
            bool status = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(connString))
                {
                    if (con.State == ConnectionState.Closed)
                        con.Open();

                    string query = "select * from user_register where password = @upass and username = @uemail";

                    MySqlCommand cmd = new MySqlCommand(query, con);
                    cmd.Parameters.Add(new MySqlParameter("@uemail", c.username));
                    cmd.Parameters.Add(new MySqlParameter("@upass", c.password));

                    object result = cmd.ExecuteScalar();

                    if (result != null)
                    {
                        status = true;
                    }
                    con.Close();


                }
            }
            catch (MySqlException e)
            {
                string message = e.Message;
            }

            return status;
        }
    }
}
