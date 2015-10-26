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
        Track GetTrackDetails(long trackId);
        IList<RegionDTO> GetTracksOverview();
        void CreateTrack(long regionId, Track track);
        Dictionary<long, String> GetRegions();
    }
}
