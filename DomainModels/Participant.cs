using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Participant
    {
        public long Id { get; set; }
        public String Name { get; set; }

        public Participant() { }

        public Participant(string name)
        {
            this.Name = name;
        }
    }
}
