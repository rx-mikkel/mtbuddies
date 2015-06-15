using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    class TracksService : ITracksService
    {
        public IList<Track> GetAllTracks()
        {
            return new List<Track>();
        }
    }
}
