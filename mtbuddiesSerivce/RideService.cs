using DAO;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mtbuddiesSerivce
{
    public class RideService : IRideService
    {
        IRideDB _rideDB = new RideDB();        

        public Ride AddRide(Ride ride, long trackId)
        {           
            return _rideDB.AddRide(ride, trackId);
        }

        public Boolean AddParticipantToRide(long rideId, Participant participant)
        {
            return _rideDB.AddParticipantToRide(rideId, participant);
        }
    }
}
