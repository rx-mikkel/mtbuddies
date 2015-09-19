using DomainModels;
using DTO;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class TracksDB : ITracksDB
    {
        private CommonDBContext _context = MTBuddiesContext.GetContext();

        public TracksDB() { }

        public IList<Track> GetAllTracks()
        {
            return _context.Tracks.Include("Rides.Participants").ToList();                                              
        }

        public Track GetTrackDetails(long trackId)
        {
            DateTime dateNow = DateTime.Now;
            Track track = _context.Tracks.SingleOrDefault(x => x.Id == trackId);
            track.Rides = _context.Rides.Where(x => x.Date >= dateNow && x.Track.Id == trackId).Include(x => x.Participants).ToList();
            
            //return _context.Tracks.Include("Rides.Participants").Where(x => x.Id == trackId).SingleOrDefault();

            return track;
        }

        public IList<TrackOverviewDTO> GetTracksOverview()
        {
            DateTime nowDate = DateTime.Now;
            IList<TrackOverviewDTO> tracks = _context.Tracks.Select(x =>
                new TrackOverviewDTO() {
                    TrackId = x.Id, 
                    Name = x.Name, 
                    ActiveRides = x.Rides.Count(r => r.Date >= nowDate),
                    Difficulty = x.Difficulty, 
                    Length = x.Length
                }).ToList();

            return tracks;
        }
    }
}
