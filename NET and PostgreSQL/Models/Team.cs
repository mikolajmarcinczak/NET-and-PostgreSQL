using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Team
    {
        public Team()
        {
            Emps = new HashSet<Emp>();
            Managers = new HashSet<Manager>();
        }

        public string TeamName { get; set; }
        public string DepartmentName { get; set; }

        public virtual Dept DepartmentNameNavigation { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
