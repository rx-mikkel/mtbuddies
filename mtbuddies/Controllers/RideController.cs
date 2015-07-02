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
            int[] date = Array.ConvertAll(rideVM.Date.Split('-'), s => int.Parse(s));

            Ride ride = new Ride() {
                Author = rideVM.Author,
                Comment = rideVM.Comment,
                Date = new DateTime(date[2], date[1], date[0]),                
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