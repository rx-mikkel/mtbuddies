using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public static class MTBuddiesContext
    {
        public static CommonDBContext GetContext()
        {
            CommonDBContext context = new MSSQLMTBuddiesContext();
#if MySQL
            context = new MySQLMTBuddiesContext("productionMySQL");
#endif

            return context;
        }
    }
}
