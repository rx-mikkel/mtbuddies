using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    class TracksService : ITracksService
    {
        public IList<Tracks> GetAllTracks()
        {
            return new List<Tracks>();
        }
    }
}
