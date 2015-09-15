using DAO;
using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    public class TracksService : ITracksService
    {
        private ITracksDB _tracksDB = new TracksDB();

        public IList<Track> GetAllTracks()
        {
            return _tracksDB.GetAllTracks();
        }

        public Track GetTrackDetails(long trackId)
        {
            return _tracksDB.GetTrackDetails(trackId);
        }
    }
}
