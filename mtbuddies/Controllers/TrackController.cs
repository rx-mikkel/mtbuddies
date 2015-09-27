using DomainModels;
using DTO;
using mtbuddies.Models;
using mtbuddiesSerivce;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace mtbuddies.Controllers
{
    public class TrackController : ApiController
    {
        private ITracksService _trackService = new TracksService();

        public TrackVM GetTrackDetailsById(long trackId)
        {
            Track track = _trackService.GetTrackDetails(trackId);

            TrackVM trackVM = new TrackVM(track);

            return trackVM;
        }

        public IList<TrackOverviewDTO> GetTracksOverview()
        {
            IList<TrackOverviewDTO> tracks = _trackService.GetTracksOverview();

            return tracks;
        }        
    }
}
