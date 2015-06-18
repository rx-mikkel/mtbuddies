using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace mtbuddies.Models
{
    public class RideVM
    {
        public long Id { get; set; }
        public DateTime Date { get; set; }
        public String Author { get; set; }
        public String Comment { get; set; }        
    }
}