using DAO;
using DomainModels;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    public class TracksService : ITracksService
    {
        private ITracksDB _tracksDB = new TracksDB();

        public Track GetTrackDetails(long trackId)
        {
            return _tracksDB.GetTrackDetails(trackId);
        }

        public IList<TrackOverviewDTO> GetTracksOverview()
        {
            return _tracksDB.GetTracksOverview();
        }
    }
}
