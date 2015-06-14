using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DomainModels;
using mtbuddies.Models;

namespace mtbuddies.Controllers
{
    public class TracksController : Controller
    {
        private mtbuddiesContext db = new mtbuddiesContext();

        public ActionResult GetAllTrackDetails(long trackId)
        {
            Tracks track = db.Tracks.Where(x => x.Id == trackId).SingleOrDefault();
            
            return Json(new { trackDetails = track });
        }
    }
}
