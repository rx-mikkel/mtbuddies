using DomainModels;
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

        public JsonResult AddParticipant(long rideId, string name)
        {
            Boolean savedSuccessfully = _rideService.AddParticipantToRide(rideId, new Participant(name));

            return Json(savedSuccessfully);
        }
    }
}