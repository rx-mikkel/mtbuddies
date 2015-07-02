using DomainModels;
using System;

namespace DAO
{
    public interface IRideDB
    {
        Boolean AddRide(Ride ride);

        Boolean AddParticipantToRide(long rideId, Participant participant);
    }
}
