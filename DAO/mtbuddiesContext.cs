using DomainModels;
using System.Data.Entity;

namespace DAO
{
    public class MTBuddiesContext : DbContext
    {           
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }

        public MTBuddiesContext()
        {

        }
    }
}
