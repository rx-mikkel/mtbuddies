using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtbuddies.Models
{
    public class RideVM
    {
        public long Id { get; private set; }
        public String Date { get; private set; }
        public String Time { get; private set; }
        public String Author { get; private set; }
        public String Comment { get; private set; }
        public IList<String> Participant { get; private set; }

        public RideVM(DomainModels.Ride ride)
        {
            this.Id = ride.Id;
            this.Author = ride.Author;
            this.Comment = ride.Comment;
            this.Date = ride.Date.ToShortDateString();
            this.Time = ride.Date.ToShortTimeString();
            this.Participant = new List<String>();
            foreach (DomainModels.Participant participant in ride.Participants) {
                this.Participant.Add(participant.Name);
            }            
        }
    }
}