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
                IList<RideVM> rides = new List<RideVM>();
                foreach (Ride ride in track.Rides)
                {
                    RideVM rideVM = new RideVM()
                    {
                        Author = ride.Author,
                        Comment = ride.Comment,
                        Date = ride.Date
                    };

                    rides.Add(rideVM);
                }

                TrackVM trackVM = new TrackVM()
                {
                    Name = track.Name,
                    Description = track.Name,
                    Difficulty = track.Difficulty,
                    Direction = track.Direction,
                    Lat = track.Lat,
                    Lon = track.Lon,
                    Map = track.Map,
                    Length = track.Length,
                    Rides = rides
                };

                tracks.Add(trackVM);
            }

            return Json(tracks);
        }
    }
}
