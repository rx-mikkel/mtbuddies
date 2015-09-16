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
        public JsonResult AddRide(RideVM rideVM, long trackId)
        {
            var date = DateTime.Parse(rideVM.Date);
            var time = DateTime.Parse(rideVM.Time);

            date = date.AddHours(time.Hour);
            date = date.AddMinutes(time.Minute);

            Ride ride = new Ride() {
                Author = rideVM.Author,
                Comment = rideVM.Comment,
                Date = date,                
            };

            Boolean savedSuccessfully = _rideService.AddRide(ride, trackId);

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