using DomainModels;
using System;
using System.Collections.Generic;
namespace mtbuddiesSerivce
{
    public interface IRideService
    {
        Ride AddRide(Ride ride, long trackId);

        Boolean AddParticipantToRide(long rideId, Participant participant);
    }
}
