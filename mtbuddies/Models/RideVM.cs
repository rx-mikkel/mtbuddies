using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace mtbuddies.Models
{
    public class RideVM
    {
        //TODO convert the date and time to DateTime.
        public long Id { get; set; }
        [Required]
        public String Date { get; set; }
        [Required]
        public String Time { get; set; }
        [Required]
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