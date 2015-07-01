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
using mtbuddies.Models;

namespace mtbuddies.Controllers
{
    public class TracksController : Controller
    {
        private ITracksService _service = new TracksService();

        public JsonResult GetTrackDetails()
        {
            IList<TrackVM> tracks = new List<TrackVM>();
            IList<Track> foundTracks = _service.GetAllTracks();

            foreach (Track track in foundTracks)
            {
                TrackVM trackVM = new TrackVM(track);

                tracks.Add(trackVM);
            }


            return Json(tracks);
        }
    }
}
