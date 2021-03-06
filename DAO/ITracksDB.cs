﻿using DomainModels;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public interface ITracksDB
    {
        Track GetTrackDetails(long trackId);
        IList<RegionDTO> GetTracksOverview();
        void CreateTrack(long regionId, Track track);
        Dictionary<long, String> GetRegions();
    }
}
