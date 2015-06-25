using DomainModels;
using System;

namespace DAO
{
    public interface IRideDB
    {
        bool AddParticipantToRide(long rideId, Participant participant);
    }
}
