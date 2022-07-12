using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Location
    {
        public Location()
        {
            Depts = new HashSet<Dept>();
        }

        public int LocationId { get; set; }
        public string Country { get; set; }
        public string State { get; set; }
        public string City { get; set; }
        public string PostalCode { get; set; }
        public string StreetAndNumber { get; set; }

        public virtual ICollection<Dept> Depts { get; set; }
    }
}
