using DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtbuddies.Models
{
    public class TrackVM
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public double Length { get; set; }
        public string Difficulty { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
        public string Direction { get; set; }
        public IList<RideVM> Rides { get; set; }

        public TrackVM(DomainModels.Track track)
        {
            this.Id = track.Id;
            this.Name = track.Name;
            this.Map = track.Map;
            this.Length = track.Length;
            this.Lat = track.Lat;
            this.Lon = track.Lon;
            this.Description = track.Description;
            this.Direction = Direction;

            IList<RideVM> rides = new List<RideVM>();
            foreach (Ride ride in track.Rides)
            {
                RideVM rideVM = new RideVM(ride);

                rides.Add(rideVM);
            }

            this.Rides = rides;
        }
    }
}