using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    /// <summary>
    /// Class used to hold information about a ride.
    /// </summary>
    public class Ride
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String Author { get; set; }
        public String Comment { get; set; }
        public Track Track { get; set; }
        public ICollection<Participant> Participants { get; set; }

        /// <summary>
        /// Default constructor used by EF.
        /// </summary>
        public Ride() { }
    }
}
