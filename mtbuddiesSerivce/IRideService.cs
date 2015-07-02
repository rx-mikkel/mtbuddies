using DomainModels;
using System;
namespace mtbuddiesSerivce
{
    public interface IRideService
    {
        Boolean AddRide(Ride ride);

        Boolean AddParticipantToRide(long rideId, Participant participant);
    }
}
