using DomainModels;
using System.Data.Entity;

namespace DAO
{
    public class MTBuddiesContext : DbContext
    {           
        public virtual DbSet<Track> Tracks { get; set; }

        public MTBuddiesContext()
        {

        }
    }
}
