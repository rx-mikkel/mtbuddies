using DomainModels;
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
    }
}
