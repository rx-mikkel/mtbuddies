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
        private ITracksDB tracksDB = new TracksDB();

        public IList<Track> GetAllTracks()
        {
            return tracksDB.GetAllTracks();
        }
    }
}
