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
    public class RideController : Controller
    {
        private IRideService _rideService = new RideService();

        [HttpPost]
        public JsonResult AddRide(RideVM rideVM)
        {
            //int[] date = Array.ConvertAll(rideVM.Date.Split('-'), s => int.Parse(s));

            // TODO Map this to the right track in the service and get the track ID
            var ticks = (long.Parse(rideVM.Date) * 10000) + 621355968000000000;
            var date = new DateTime(ticks);
            var timeTicks = (long.Parse(rideVM.Time) * 10000) + 621355968000000000;
            var time = new DateTime(timeTicks);

            date.AddHours(time.Hour);
            date.AddMinutes(time.Minute);

            Ride ride = new Ride() {
                Author = rideVM.Author,
                Comment = rideVM.Comment,
                Date = date,                
            };

            Boolean savedSuccessfully = _rideService.AddRide(ride);

            return Json(savedSuccessfully);
        }

        [HttpPost]
        public JsonResult AddParticipant(long rideId, string name)
        {
            Boolean savedSuccessfully = _rideService.AddParticipantToRide(rideId, new Participant(name));

            return Json(savedSuccessfully);
        }
    }
}