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
    /// <summary>
    /// Controller handling Rides.
    /// </summary>
    public class RideController : ApiController
    {
        private IRideService _rideService = new RideService();

        //TODO change this model to it's own.
        public long AddRide([FromBody]RideVM rideVM)
        {
            long rideId = -1;

            if (ModelState.IsValid)
            {
                var date = DateTime.Parse(rideVM.Date);
                var time = DateTime.Parse(rideVM.Time);

                date = date.AddHours(time.Hour);
                date = date.AddMinutes(time.Minute);

                Ride ride = new Ride()
                {
                    Author = rideVM.Author,
                    Comment = rideVM.Comment,
                    Date = date,
                };

                Ride newRide = _rideService.AddRide(ride, rideVM.TrackId);
                rideId = ride.Id;
            }

            return rideId;
        }

        /// <summary>
        /// Adds a participant to a Ride.
        /// </summary>
        /// <param name="rideId">Id of the Ride to add the participant.</param>
        /// <param name="name">Name of the participant.</param>
        /// <returns>True if the participant is created correctly else false.</returns>
        public bool AddParticipant([FromUri]long rideId, [FromUri]string name)
        {
            bool result = false;
            
            if (rideId != null && rideId != 0 && !String.IsNullOrWhiteSpace(name))
            {
                result = _rideService.AddParticipantToRide(rideId, new Participant(name));
            }

            return result;
        }
    }
}