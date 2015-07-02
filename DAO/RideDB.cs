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

        public Boolean AddRide(Ride ride)
        {
            Track track = _context.Tracks
                .Include("Rides")
                .Select(x => x)
                .SingleOrDefault(x => x.Id == 4);

            track.Rides.Add(ride);

            return 0 < _context.SaveChanges();
        }

        public Boolean AddParticipantToRide(long rideId, Participant participant)
        {            
            Ride ride = _context.Rides
                .Include("Participants")
                .Select(x => x)                        
                .SingleOrDefault(x => x.Id == rideId);

            ride.Participants.Add(participant);
            
            return 0 < _context.SaveChanges();
        }
    }
}
