using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Proj
    {
        public Proj()
        {
            Assignprojects = new HashSet<Assignproject>();
        }

        public string ProjectName { get; set; }
        public DateTime? DeadlineDate { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Assignproject> Assignprojects { get; set; }
    }
}
