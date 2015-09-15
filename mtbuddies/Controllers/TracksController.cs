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
        private ITracksService _trackService = new TracksService();

        [Obsolete("GetTrackDetails() is deprecated, Use GetTrackDetails(long) instead.")]
        public JsonResult GetTrackDetails()
        {
            IList<TrackVM> tracks = new List<TrackVM>();
            IList<Track> foundTracks = _trackService.GetAllTracks();

            foreach (Track track in foundTracks)
            {
                TrackVM trackVM = new TrackVM(track);

                tracks.Add(trackVM);
            }

            return Json(tracks);
        }

        /// <summary>
        /// Returning a trackVM as Json found by the trackId given.
        /// </summary>
        /// <param name="trackId">Id of the track to get.</param>
        /// <returns>Json string with the Tracks data.</returns>
        public JsonResult GetTrackDetails(long trackId)
        {
            Track track = _trackService.GetTrackDetails(trackId);

            TrackVM trackVM = new TrackVM(track);

            return Json(trackVM);
        }
    }
}
