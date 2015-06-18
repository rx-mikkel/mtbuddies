using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModels;
using mtbuddiesSerivce;

namespace mtbuddies.Controllers
{
    public class TracksController : Controller
    {
        private ITracksService _service = new TracksService();

        public ActionResult GetTrackDetails()
        {           
            IList<Track> tracks = _service.GetAllTracks();

            return Json(tracks);
        }
    }
}
