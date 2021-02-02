using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace Trip_Web.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        
        public ActionResult register_admin(string name, string email, string pass, string contactno, string address, string pincode)
        {


            Admin ca = new Admin
            {
                username = name,
                email = email,
                password = pass,
                contactno = contactno,
                address = address,
                pincode = pincode
            };
            bool status = BussinessManger.regAdmin(ca);
            if (status)
            {
                return RedirectToAction("ShowUser", "admin");
            }


            return View();

        }


        // GET: Admin
        public ActionResult ShowUser()
        {
            List<User> user = BussinessManger.Getalluserdata();
            this.ViewData["user"] = user;
            return View();
        }
    }
}