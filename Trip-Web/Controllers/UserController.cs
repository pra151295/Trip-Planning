using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace Trip_Web.Controllers
{
    public class UserController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        // GET: User
        [HttpPost]
        public ActionResult Index(string username, string upassword)
        {

            User c = new User
            {
                username = username,
                password = upassword,

            };
            bool status = BussinessManger.Login(c);
            if (status)
            {
                return RedirectToAction("welcome", "user");
            }


            return View();
        }

        //[HttpPost]
        //public ActionResult Login(string username, string upassword)
        //{


        //    User c = new User
        //    {
        //        username = username,
        //        password = upassword,

        //    };
        //    bool status = BussinessManger.Login(c);
        //    if (status)
        //    {
        //        return RedirectToAction("index", "route");
        //    }


        //    return View();
        //}

        [HttpPost]
        [ActionName("Register")]
        public ActionResult Register_Post(string name , string email, string pass, string contactno, string address, string pincode)
        {
       
           
                User c = new User
                {
                    username = name,
                    email = email,
                    password = pass,
                    contactno = contactno,
                    address = address,
                    pincode = pincode
                };
                bool status = BussinessManger.regUser(c);
                if (status)
                {
                    return RedirectToAction("index", "user");
                }
            

            return View();
        }

        public ActionResult Welcome()
        {
            return View();
        }

        public ActionResult Planned()
        {
            return View();
        }

        public ActionResult Unplanned()
        {
            return View();
        }
        public ActionResult AboutUs()
        {
            return View();
        }
        public ActionResult ContactUs()
        {
            return View();
        }
    }
}