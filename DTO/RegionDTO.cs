using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class RegionDTO
    {
        public string Name { get; set; }
        public ICollection<TrackOverviewDTO> Tracks { get; set; }
    }
}
