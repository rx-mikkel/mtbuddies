using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Country
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public ICollection<Region> Regions { get; set; }
    }
}
