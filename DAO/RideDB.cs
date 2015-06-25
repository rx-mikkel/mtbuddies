using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class RideDB : IRideDB
    {
        private MTBuddiesContext _context = new MTBuddiesContext();

        public RideDB() { }

        public Boolean AddParticipantToRide(long rideId, Participant participant)
        {
            Ride ride = _context.Rides.Where(x => x.Id == rideId).SingleOrDefault();

            ride.Participants.Add(participant);

            return 0 < _context.SaveChanges();
        }
    }
}
