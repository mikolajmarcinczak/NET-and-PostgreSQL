using System;
using System.Collections.Generic;

#nullable disable

namespace NET_and_PostgreSQL.Models
{
    public partial class Emp
    {
        public Emp()
        {
            Assignprojects = new HashSet<Assignproject>();
            Managers = new HashSet<Manager>();
        }

        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public DateTime HireDate { get; set; }
        public DateTime ContractEndDate { get; set; }
        public DateTime? BirthDate { get; set; }
        public string DepartmentName { get; set; }
        public string TeamName { get; set; }
        public string CategoryName { get; set; }

        public virtual Salarycategory CategoryNameNavigation { get; set; }
        public virtual Dept DepartmentNameNavigation { get; set; }
        public virtual Team TeamNameNavigation { get; set; }
        public virtual ICollection<Assignproject> Assignprojects { get; set; }
        public virtual ICollection<Manager> Managers { get; set; }
    }
}
