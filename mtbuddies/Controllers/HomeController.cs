using DomainModels;
using DTO;
using mtbuddiesSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mtbuddies.Controllers
{
    public class HomeController : Controller
    {
        private ITracksService _trackService = new TracksService();

        public ActionResult Index()
        {
            IList<TrackOverviewDTO> tracks = _trackService.GetTracksOverview();

            return View();
        }
        public ActionResult Oversigt()
        {
            return View();
        }  
    }
}