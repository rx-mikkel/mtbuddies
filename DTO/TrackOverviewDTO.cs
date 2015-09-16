using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class TrackOverviewDTO
    {
        public long TrackId { get; set; }
        public String Name { get; set; }
        public int ActiveRides { get; set; }
        public String Difficulty { get; set; }
        public double Length { get; set; }        
    }
}
