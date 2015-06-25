using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Participant
    {
        public long Id { get; private set; }
        public String Name { get; private set; }

        public Participant(string name)
        {
            this.Name = name;
        }
    }
}
