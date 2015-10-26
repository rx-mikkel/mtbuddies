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

        public IList<RegionDTO> GetTracksOverview()
        {
            return _tracksDB.GetTracksOverview();
        }

        public void CreateTrack(long regionId, Track track)
        {
            _tracksDB.CreateTrack(regionId, track);
        }

        public Dictionary<long, string> GetRegions() 
        {
            return _tracksDB.GetRegions();
        }
    }
}
