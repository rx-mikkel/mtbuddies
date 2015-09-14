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
    class MySQLMTBuddiesContext : CommonDBContext
    {           
        public MySQLMTBuddiesContext(String connectionString) :
            base(connectionString) 
        {

        }                
    }
}
