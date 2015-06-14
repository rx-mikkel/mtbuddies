using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DomainModels
{
    public class Tracks
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Map { get; set; }
        public string Length { get; set; }
        public string Difficulty { get; set; }
        public string Lat { get; set; }
        public string Lon { get; set; }
        public string Description { get; set; }
    }
}
