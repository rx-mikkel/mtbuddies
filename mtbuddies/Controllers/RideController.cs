using DomainModels;
using mtbuddies.Models;
using mtbuddiesSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace mtbuddies.Controllers
{
    public class RideController : ApiController
    {
        private IRideService _rideService = new RideService();
        
        public long AddRide([FromBody]RideVM rideVM)
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

            Ride newRide = _rideService.AddRide(ride, rideVM.TrackId);

            return ride.Id;
        }

        public bool AddParticipant([FromUri]long rideId, [FromUri]string name)
        {
            return _rideService.AddParticipantToRide(rideId, new Participant(name));
        }
    }
}