using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Manager
    {
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int EmployeeId { get; set; }
        public string DepartmentName { get; set; }
        public string TeamName { get; set; }

        public virtual Dept DepartmentNameNavigation { get; set; }
        public virtual Emp Employee { get; set; }
        public virtual Team TeamNameNavigation { get; set; }
    }
}
