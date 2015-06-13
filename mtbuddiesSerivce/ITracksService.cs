using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    public interface ITracksService
    {
        IList<Tracks> GetAllTracks();
    }
}
