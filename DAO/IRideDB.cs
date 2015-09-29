using DomainModels;
using System;
using System.Collections.Generic;

namespace DAO
{
    public interface IRideDB
    {
        Ride AddRide(Ride ride, long trackId);
        Boolean AddParticipantToRide(long rideId, Participant participant);
    }
}
