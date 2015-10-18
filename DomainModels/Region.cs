using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Region
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Track> Tracks { get; set; }
    }
}
