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

        public Track GetTrackDetails(long trackId)
        {
            DateTime dateNow = DateTime.Now;
            Track track = _context.Tracks.SingleOrDefault(x => x.Id == trackId);
            track.Rides = _context.Rides.Where(x => x.Date >= dateNow && x.Track.Id == trackId).Include(x => x.Participants).ToList();                       

            return track;
        }

        public IList<RegionDTO> GetTracksOverview()
        {
            DateTime nowDate = DateTime.Now;
            
            IList<RegionDTO> regions = _context.Regions.Select(x =>
                new RegionDTO()
                {
                    Name = x.Name,
                    Tracks = x.Tracks.Select(t => new TrackOverviewDTO()
                    {
                        TrackId = t.Id,
                        Name = t.Name,
                        ActiveRides = t.Rides.Count(r => r.Date >= nowDate),
                        Difficulty = t.Difficulty,
                        Length = t.Length
                    }).ToList()
                }).ToList();

            return regions;
        }
    }
}
