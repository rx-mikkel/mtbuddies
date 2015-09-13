using DomainModels;
using MySql.Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    class MySQLMTBuddiesContext: DbContext
    {           
        public virtual DbSet<Track> Tracks { get; set; }
        public virtual DbSet<Ride> Rides { get; set; }
        public virtual DbSet<Participant> Participants { get; set; }

        public MySQLMTBuddiesContext()
        {

        }
    }
}
