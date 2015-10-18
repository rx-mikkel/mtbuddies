using DomainModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CommonDBContext : DbContext
    {
        public DbSet<Track> Tracks { get; set; }
        public DbSet<Ride> Rides { get; set; }
        public DbSet<Participant> Participants { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Region> Regions { get; set; }

        public CommonDBContext(String connectionString) : base (connectionString)
        {
            
        }
    }
}
