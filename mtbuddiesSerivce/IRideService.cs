using DomainModels;
using System;
namespace mtbuddiesSerivce
{
    public interface IRideService
    {
        Boolean AddParticipantToRide(long rideId, Participant participant);
    }
}
