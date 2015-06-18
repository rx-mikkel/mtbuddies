using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Ride
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String Author { get; set; }
        public String Comment { get; set; }
        public Track Track { get; set; }
    }
}
