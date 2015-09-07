using DomainModels;
using MySql.Data.Entity;
using System.Data.Entity;

namespace DAO
{
    //[DbConfigurationType(typeof(MySqlEFConfiguration))]
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
