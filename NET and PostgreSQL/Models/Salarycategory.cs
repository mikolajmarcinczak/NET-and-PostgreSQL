using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Salarycategory
    {
        public Salarycategory()
        {
            Emps = new HashSet<Emp>();
        }

        public string CategoryName { get; set; }
        public decimal MinSalary { get; set; }
        public decimal? MaxSalary { get; set; }

        public virtual ICollection<Emp> Emps { get; set; }
    }
}
