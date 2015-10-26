using DomainModels;
using mtbuddies.Models;
using mtbuddiesSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mtbuddies.Controllers
{
    public class AdminToolsController : Controller
    {
        ITracksService _service = new TracksService();

        [HttpGet]
        public ActionResult CreateTrack()
        {           
            var regions = new SelectList(_service.GetRegions(), "key", "value");

            ViewBag.regions = regions;

            return View();
        }

        [HttpPost]
        public ActionResult CreateTrack(long regionId, TrackVM track)
        {
            if (ModelState.IsValid)
            {
                Track newTrack = new Track() {
                    Description = track.Description,
                    Difficulty = track.Difficulty,
                    Direction = track.Direction,
                    Lat = track.Lat,
                    Length = track.Length,
                    Lon = track.Lon,
                    Map = track.Map,
                    Name = track.Name,                   
                };


                _service.CreateTrack(regionId, newTrack);

                return RedirectToAction("CreateTrack");
            }


            return View(track);
        }
    }
}