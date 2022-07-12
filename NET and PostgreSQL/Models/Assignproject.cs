using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Assignproject
    {
        public int EmployeeId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? DateFrom { get; set; }
        public DateTime? DateTo { get; set; }
        public string Role { get; set; }

        public virtual Emp Employee { get; set; }
        public virtual Proj ProjectNameNavigation { get; set; }
    }
}
