using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Dept
    {
        public Dept()
        {
            Emps = new HashSet<Emp>();
            Managers = new HashSet<Manager>();
            Teams = new HashSet<Team>();
        }

        public string DepartmentName { get; set; }
        public int LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<Emp> Emps { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
    }
}
