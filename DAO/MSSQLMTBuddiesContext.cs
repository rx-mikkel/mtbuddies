using DomainModels;
using MySql.Data.Entity;
using System.Data.Entity;

namespace DAO
{
    public class MSSQLMTBuddiesContext : CommonDBContext
    {                  
        public MSSQLMTBuddiesContext() : base("ConnectionString")
        {

        }
    }
}
