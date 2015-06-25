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
        private MTBuddiesContext _context = new MTBuddiesContext();

        public TracksDB() { }

        public IList<Track> GetAllTracks()
        {
            return _context.Tracks.Include(x => x.Rides).ToList();
        }
    }
}
