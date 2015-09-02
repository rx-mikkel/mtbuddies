using DomainModels;
using System;
using System.Collections.Generic;
namespace mtbuddiesSerivce
{
    public interface IRideService
    {
        Boolean AddRide(Ride ride, long trackId);

        Boolean AddParticipantToRide(long rideId, Participant participant);

        IList<Ride> GetActiveTrackRides(long trackId);
    }
}
