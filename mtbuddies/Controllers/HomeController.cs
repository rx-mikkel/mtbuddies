using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mtbuddies.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Rides()
        {
            return PartialView();
        }

        public ActionResult Reviews()
        {
            return PartialView();
        }
    }
}