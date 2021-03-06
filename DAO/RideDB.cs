﻿using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DAO
{
    public class RideDB : IRideDB
    {
        private CommonDBContext _context = MTBuddiesContext.GetContext();

        public RideDB() { }

        public Ride AddRide(Ride ride, long trackId)
        {
            Track track = _context.Tracks.Include("Rides").SingleOrDefault(x => x.Id == trackId);

            track.Rides.Add(ride);

            _context.SaveChanges();

            return ride;
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
