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
    }
}