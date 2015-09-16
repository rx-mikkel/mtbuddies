using DomainModels;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mtbuddiesSerivce
{
    public interface ITracksService
    {
        IList<Track> GetAllTracks();
        Track GetTrackDetails(long trackId);
        IList<TrackOverviewDTO> GetTracksOverview();
    }
}
