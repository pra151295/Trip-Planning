using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BOL;
using BLL;

namespace Trip_Web.Controllers
{
    public class RouteController : Controller
    {
        [HttpPost]
        // GET: Route
        public ActionResult Index(string source , string destination)
        {

            List<Routes> routes = BussinessManger.GetallRoute(source,destination);
            List<Petrol_Pump> petrol = BussinessManger.GetallPetrol(source, destination);
            List<Hotel> hotel = BussinessManger.Getallhotel(source, destination);
            this.ViewData["hotel"] = hotel;
            this.ViewData["petrol"] = petrol;
            return View(routes);
        }


    }
}