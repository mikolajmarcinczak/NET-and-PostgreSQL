using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NET_and_PostgreSQL.Models
{
    public class LocationWithTeamsDTO
    {
        public Location Location { get; set; }
        public int TeamCount { get; set; }
    }
}
