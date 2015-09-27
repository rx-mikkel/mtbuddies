using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtbuddies.Models
{
    public class RideVM
    {
        public long Id { get; set; }
        public String Date { get; set; }
        public String Time { get; set; }
        public String Author { get; set; }
        public String Comment { get; set; }
        public IList<String> Participants { get; set; }
        public long TrackId { get; set; }

        public RideVM() { }

        public RideVM(DomainModels.Ride ride)
        {
            this.Id = ride.Id;
            this.Author = ride.Author;
            this.Comment = ride.Comment;
            this.Date = ride.Date.ToShortDateString();
            this.Time = ride.Date.ToShortTimeString();
            this.Participants = new List<String>();
            foreach (DomainModels.Participant participant in ride.Participants) {
                this.Participants.Add(participant.Name);
            }            
        }
    }
}