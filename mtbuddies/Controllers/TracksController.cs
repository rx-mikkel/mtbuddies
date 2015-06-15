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

        public ActionResult GetTrackDetails()
        {           
            Track track = new Track
            {
                Id = 1,
                Description = "This is a test Track",
                Difficulty = "4",
                Name = "Test Track"
            };

            return Json(track);
        }
    }
}
