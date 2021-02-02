using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using BOL;


namespace BLL
{
    public class BussinessManger
    {
        public static bool regUser(User c)
        {

            return LoginDBManger.regUser(c);
       }

        public static List<Routes> GetallRoute(string to, string from)
        {
            return RouteDBManager.GetallRoute(to, from);
        }

        public static bool Login(User c)
        {
            return LoginDBManger.login(c);
        }

        public static List<Hotel> Getallhotel(string source, string destination)
        {
            return RouteDBManager.Getallhotel(source, destination);
        }

        public static List<Petrol_Pump> GetallPetrol(string source, string destination)
        {
            return RouteDBManager.GetallPetrol(source, destination);
        }

        public static bool regAdmin(Admin ca)
        {
            return LoginDBManger.regAdmin(ca);
        }

        public static List<User> Getalluserdata()
        {
            List<User> allbooks = new List<User>();
            allbooks = LoginDBManger.Getalluserdata();

            return allbooks;
        }
    }
}
